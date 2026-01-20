using SimpleDb.Core.Constants;

namespace SimpleDb.Core.Primitives;

public class DbPage
{
    private byte[] data;
    
    

    public DbPage(byte[] encodedData)
    {
        if (encodedData.Length != 4096)
        {
            throw new ArgumentException("encodedData must be of size 4096");
        }

        this.data = encodedData;
    }

    public Span<byte> Header => this.data.AsSpan(0, PageConstants.HeaderSize);

    public Span<byte> Data => this.data.AsSpan(71, 309 * 13);

    public Span<byte> Slots => this.data.AsSpan(32, PageConstants.BitMapSize);


    private void WriteToHeader(int offset, int value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        for (int i = 0; i < 4; i++)
        {
            this.data[offset + i] = bytes[i];
        }
    }
    
    private void WriteBytesToHeader(int offset, byte value)
    {
        this.data[offset] = value;
    }

    public int ReadInt32FromHeader(int offset)
    {
        byte[] bytes = this.data[offset..(offset + 3)];
        return BitConverter.ToInt32(bytes, 0);
    }
    
    public byte ReadByteFromHeader(int offset) =>  this.data[offset];

    public bool IsSlotFree(int slotIndex)
    {
        //replace with constants
        if (slotIndex < 0 || slotIndex >= PageConstants.MaximumSlotNumber)
        {
            throw new ArgumentOutOfRangeException(nameof(slotIndex) ,"SlotIndexes are int the range of 32 to 70");
        }

        int byteIndex = slotIndex / 8;
        int bitIndex = slotIndex % 8;
        int mask = 1 << bitIndex;

        byte bitmapByte = this.ReadByteFromHeader(PageConstants.HeaderSize  + byteIndex);
        return (bitmapByte & mask) == 0;
    }

    public void FreeSlot(int slotIndex)
    {
        //replace with constants
        if (slotIndex < 0 || slotIndex >=PageConstants.MaximumSlotNumber)
        {
            throw new ArgumentOutOfRangeException(nameof(slotIndex) ,"SlotIndexes are int the range of 32 to 70");
        }
        
        int byteIndex = slotIndex / 8;
        int bitIndex = slotIndex % 8;
        int mask = 1 << bitIndex;
        
        this.data[PageConstants.HeaderSize + byteIndex] &= (byte)~mask;
    }

    public void MarkSlotUsed(int slotIndex)
    {
        //replace with constants
        if (slotIndex < 0 || slotIndex >= PageConstants.MaximumSlotNumber)
        {
            throw new ArgumentOutOfRangeException(nameof(slotIndex) ,"SlotIndexes are int the range of 32 to 70");
        }
        
        int byteIndex = slotIndex / 8;
        int bitIndex = slotIndex % 8;
        int mask = 1 << bitIndex;
        
        this.data[PageConstants.HeaderSize + byteIndex] |= (byte)mask;
    }

    public int FindNextFreeSlot()
    {
        for (int byteIndex = 0; byteIndex < PageConstants.BitMapSize; byteIndex++)
        {
            byte bitmapByte = this.Slots[byteIndex];
            for (int bitIndex = 0; bitIndex < 8; bitIndex++)
            {
                int mask = 1 << bitIndex;
                int slotIndex = byteIndex * 8 + bitIndex;
                if (slotIndex >= PageConstants.MaximumSlotNumber) break;
                if((bitmapByte & (byte)mask) == 0) return slotIndex;
            }
        }
        return -1;
    }
}