namespace SimpleDb.Core.Serializers.Enums;

public enum FieldFlags : byte
{
    None     = 0,
    IsNull   = 1 << 0,
    Fixed    = 1 << 1,
    Variable = 1 << 2,
}