using SimpleDb.Core.Enums;

namespace SimpleDb.Core.Primitives;

public class RecordPointer
{
    private readonly byte pointerType; // 1 byte long
    
    private readonly byte[] positionReg; // 8 bytes long
    
    private readonly byte[] chunkReg; // 4 bytes long

    public PointerType PointerType => (PointerType)this.pointerType;
    public ulong Position => BitConverter.ToUInt64(this.positionReg, 0);
    public uint Chunk => BitConverter.ToUInt32(this.chunkReg, 0);

    public RecordPointer(PointerType pointerType, ulong positionReg, uint chunkReg)
    {
        this.pointerType = (byte)pointerType;
        this.positionReg = BitConverter.GetBytes(positionReg);
        this.chunkReg = BitConverter.GetBytes(chunkReg);
        
        if (!BitConverter.IsLittleEndian)
        {
            Array.Reverse(this.positionReg);
            Array.Reverse(this.chunkReg);
        }
    }

    public RecordPointer(byte typeByte, byte[] positionRegBytes, byte[] chunkRegBytes)
    {
        if (positionRegBytes.Length != 8 || positionRegBytes == null)
        {
            throw new ArgumentException("Position must be exactly 8 bytes!");
        }
        
        if(chunkRegBytes.Length != 4 || chunkRegBytes == null)
        {
            throw new ArgumentException("Chunk must be exactly 4 bytes!");
            
        }

        pointerType = typeByte;
        positionReg = (byte[])positionRegBytes.Clone();
        chunkReg = (byte[])chunkRegBytes.Clone();
    }

    public byte[] Encode()
    {
        byte[] encodedBytes = new byte[13];
        encodedBytes[0] = pointerType;
        Array.Copy(positionReg, 0, encodedBytes, 1, 8);
        Array.Copy(chunkReg, 0, encodedBytes, 9, 4);
        
        return encodedBytes;
    }
    
    public static RecordPointer Decode(byte[] bytes)
    {
        if (bytes == null || bytes.Length != 13)
        {
            throw new ArgumentException("Input must be exactly 13 bytes!");
        }

        byte typeInBytes = bytes[0];
        byte[] posInBytes = new byte[8];
        byte[] chunkInBytes = new Byte[4];
        
        Array.Copy(bytes, 1, posInBytes, 0, 8);
        Array.Copy(bytes, 9, chunkInBytes, 0, 4);
        
        return new RecordPointer(typeInBytes, posInBytes, chunkInBytes);
    }
}