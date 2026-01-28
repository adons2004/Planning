namespace Planning.Domain.Attributes;

public class MetadataAttribute : Attribute
{
    public bool IsEditable { get; }
    public string Type { get; }

    public MetadataAttribute(bool isEditable, string type)
    {
        IsEditable = isEditable;
        Type = type;
    }
}