using System.Reflection;
using Planning.Domain.Attributes;
using Planning.Domain.Contracts;

namespace Planning.Application.Queries.Results;

public class HistoryMetadataResult
{
    public HistoryMetadataResult(IHistoryY0Parameters parameters)
    {
        var properties = parameters.GetType().GetProperties()
            .ToDictionary(p => p.Name, p => p.GetCustomAttribute<MetadataAttribute>());

        Units = new FieldMetadataResult(properties[nameof(IHistoryY0Parameters.Units)]!);
        Amount = new FieldMetadataResult(properties[nameof(IHistoryY0Parameters.Amount)]!);
        Price = new FieldMetadataResult(properties[nameof(IHistoryY0Parameters.Price)]!);
    }
    public FieldMetadataResult Units { get; set; }
    public FieldMetadataResult Amount { get; set; }
    public FieldMetadataResult Price { get; set; }
}