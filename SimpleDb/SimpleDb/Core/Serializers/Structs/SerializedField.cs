using SimpleDb.Core.Serializers.Enums;

namespace SimpleDb.Core.Serializers.Structs;

public readonly struct SerializedField
{
    public readonly FieldFlags Flags;
    private readonly byte[] payload;

    public SerializedField(FieldFlags flags, byte[] payload)
    {
        this.Flags = flags;
        this.payload = payload ??  throw new ArgumentNullException(nameof(payload));
    }
    
    public readonly ReadOnlySpan<byte> Payload => payload;
}