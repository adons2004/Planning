using Planning.Application.Queries.Request;
using Planning.Models.Requests;

namespace Planning.Mapping;

public static class LevelMappings
{
    public static Level ToApplicationLevel(this LevelRequest levelRequest)
    {
        return levelRequest switch
        {
            LevelRequest.SubSku => Level.SubSku,
            LevelRequest.Sku => Level.Sku,
            LevelRequest.Total => Level.Total,
            _ => throw new ArgumentOutOfRangeException(nameof(levelRequest), levelRequest, null)
        };
    }
}