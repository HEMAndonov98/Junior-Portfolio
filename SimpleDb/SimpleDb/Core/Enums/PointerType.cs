namespace SimpleDb.Core.Enums;

public enum PointerType : byte
{
    RawRecord = 0x01,
    LeafNode = 0x02,
    InternalNode = 0x03,
    Reserved = 0x04
}