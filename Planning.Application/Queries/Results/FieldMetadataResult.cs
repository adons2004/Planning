using Planning.Domain.Attributes;

namespace Planning.Application.Queries.Results;

public class FieldMetadataResult
{
    public FieldMetadataResult(MetadataAttribute metadata)
    {
        IsEditable = metadata.IsEditable;
        Type = metadata.Type;
    }
    public bool IsEditable { get; set; }
    public string Type { get; set; }
}