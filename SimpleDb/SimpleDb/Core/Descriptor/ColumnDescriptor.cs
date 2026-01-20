using SimpleDb.Core.Descriptor.Enums;
using SimpleDb.Core.Serializers.Contracts;

namespace SimpleDb.Core.Descriptor;

public sealed class ColumnDescriptor
{
  public ColumnType ColumnType { get; private set; }
  public bool IsNullable { get; private set; }
  public IColumnSerializer Serializer { get; private set; }

  public ColumnDescriptor(ColumnType columnType, bool isNullable, IColumnSerializer serializer)
  {
    ColumnType = columnType;
    IsNullable = isNullable;
    Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
  }
}