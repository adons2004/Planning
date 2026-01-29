using Planning.Domain.Attributes;

namespace Planning.Application.Queries.Results;

public class FieldMetadataResult
{
    public FieldMetadataResult(MetadataAttribute metadata)
    {
        IsEditable = metadata.IsEditable;
        Type = metadata.Type;
        Color = metadata.Color;
    }
    public bool IsEditable { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
}