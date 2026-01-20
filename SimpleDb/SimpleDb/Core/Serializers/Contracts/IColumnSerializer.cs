using SimpleDb.Core.Descriptor.Enums;

namespace SimpleDb.Core.Serializers.Contracts;

public interface IColumnSerializer
{
    byte[] Serialize(object? value);
    object? Deserialize(ReadOnlySpan<byte> data);
    int GetSize(object? value);
}