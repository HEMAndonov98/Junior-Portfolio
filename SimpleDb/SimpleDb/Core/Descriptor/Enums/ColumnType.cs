namespace SimpleDb.Core.Descriptor.Enums;

public enum ColumnType
{
    //Exact numeric
    Integer,
    Decimal,
    //Datetime
    Datetime,
    Date,
    Time,
    //Strings
    Varchar,
    //Other
    Blob,
    //Special
    Nullable = -1
}