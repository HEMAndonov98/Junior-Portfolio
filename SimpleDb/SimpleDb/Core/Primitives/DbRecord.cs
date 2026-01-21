using System.Text;
using SimpleDb.Core.Serializers.Enums;
using SimpleDb.Core.Serializers.Structs;

namespace SimpleDb.Core.Primitives;

public sealed class DbRecord
{
    public int TableId { get; private set; }

    public IReadOnlyList<SerializedField> Fields { get; private set; }

    public byte[] Encode()
    {
        //Encoding the header
        int headerSize = sizeof(int) + sizeof(int); // TableId + FieldCount
        int nullBitmapSize = (int)Math.Ceiling(this.Fields.Count / 8.0);
        int totalPayloadSize = headerSize + nullBitmapSize + this.Fields
            .Where(f => f.Flags != FieldFlags.IsNull)
            .Sum(f => f.Payload.Length);

        //Buffer allocation
        byte[] buffer = new byte[totalPayloadSize];
        int offset = 0;

        //Writing the header
        BitConverter.GetBytes(this.TableId).CopyTo(buffer, offset);
        offset += sizeof(int);
        BitConverter.GetBytes(this.Fields.Count).CopyTo(buffer, offset);
        offset += sizeof(int);

        //Writing the null bitmap
        byte[] nullBitmap = new byte[nullBitmapSize];
        for (int i = 0; i < this.Fields.Count; i++)
        {
            if (this.Fields[i].Flags == FieldFlags.IsNull)
            {
                nullBitmap[i / 8] |= (byte)(1 << (i % 8));
            }
        }
        nullBitmap.CopyTo(buffer, offset);
        offset += nullBitmapSize;

        //Write non null field payloads
        for (int fieldIndex = 0; fieldIndex < this.Fields.Count; fieldIndex++)
        {
            int byteIndex = fieldIndex / 8;
            int bitIndex = fieldIndex % 8;
            int mask = 1 << bitIndex;

            if ((nullBitmap[byteIndex] & mask) == 0)
            {
                SerializedField field = this.Fields[fieldIndex];
                field.Payload.ToArray().CopyTo(buffer, offset);
                offset += field.Payload.Length;
            }
            else
                continue;
        }

        return buffer;
    }

    public DbRecord Decode(ReadOnlySpan<byte> data)
    {
        throw new NotImplementedException();
    }
}
