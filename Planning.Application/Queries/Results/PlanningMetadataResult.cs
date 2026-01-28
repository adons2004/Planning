using System.Reflection;
using Planning.Domain.Attributes;
using Planning.Domain.Contracts;

namespace Planning.Application.Queries.Results;

public class PlanningMetadataResult
{
    public PlanningMetadataResult(IPlanningY1Parameters parameters)
    {
        var properties = parameters.GetType().GetProperties()
            .ToDictionary(p => p.Name, p => p.GetCustomAttribute<MetadataAttribute>());

        Units = new FieldMetadataResult(properties[nameof(IPlanningY1Parameters.Units)]!);
        Amount = new FieldMetadataResult(properties[nameof(IPlanningY1Parameters.Amount)]!);
        Price = new FieldMetadataResult(properties[nameof(IPlanningY1Parameters.Price)]!);
    }
    public FieldMetadataResult Units { get; set; }
    public FieldMetadataResult Amount { get; set; }
    public FieldMetadataResult Price { get; set; }
}