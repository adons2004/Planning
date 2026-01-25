using System.Text.Json.Serialization;

namespace Planning.Models.Requests;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LevelRequest
{
    SubSku = 0,
    Sku = 1,
    Total = 2
}