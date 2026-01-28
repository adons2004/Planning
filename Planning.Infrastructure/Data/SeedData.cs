namespace Planning.Infrastructure.Data;

public static class SeedData
{
    private static Guid drinksSkuUid = Guid.Parse("0B1BAB69-C3D8-45A7-9264-AE590EB65E84");
    private static Guid foodsSkuUid = Guid.Parse("451F4F7A-010D-485B-B90E-6C23B8E65305");
    private static Guid cokeUid = Guid.Parse("ACE57827-9163-43B5-A928-A5325DF0D3E8");
    private static Guid waterUid = Guid.Parse("6903EC64-BA3D-4247-8F09-391AAC12A7B9");
    private static Guid burgerUid = Guid.Parse("EC095083-F006-4323-94C7-D467E3637CB7");
    private static Guid friesUid = Guid.Parse("ADF2C8C4-9BC4-47FE-B66C-49DFFEB71915");
    
    public static IEnumerable<object> SkuSeed()
    {
        yield return new { Uid = drinksSkuUid, Name = "Напитки" };
        yield return new { Uid = foodsSkuUid, Name = "Еда" };
    }

    public static IEnumerable<object> SubSkuSeed()
    {
        yield return new
        {
            Uid = cokeUid,
            Name = "Кола 0.5л",
            SkuUid = drinksSkuUid,
            Price = 80m,
            Ratio = 0.4m
        };
        yield return new
        {
            Uid = waterUid,
            Name = "Вода 1.5л",
            SkuUid = drinksSkuUid,
            Price = 40m,
            Ratio = 0.8m
        };
        yield return new
        {
            Uid = burgerUid,
            Name = "Бургер",
            SkuUid = foodsSkuUid,
            Price = 600m,
            Ratio = 0.7m
        };
        yield return new
        {
            Uid = friesUid,
            Name = "Картофель-фри",
            SkuUid = foodsSkuUid,
            Price = 190m,
            Ratio = 0.5m
        };
    }

    public static IEnumerable<object> SkuHistorySeed()
    {
        yield return new { SubSkuUid = cokeUid, Units = 1_000, Amount = 80_000m };
        yield return new { SubSkuUid = waterUid, Units = 2_000, Amount = 20_000m };
        yield return new { SubSkuUid = burgerUid, Units = 1_000, Amount = 600_000m };
        yield return new { SubSkuUid = friesUid, Units = 2_000, Amount = 380_000m };
    }
    
    public static IEnumerable<object> SkuPlanningSeed()
    {
        yield return new { SubSkuUid = cokeUid, Units = 1_200, Amount = 102_000m };
        yield return new { SubSkuUid = waterUid, Units = 2_100, Amount = 88_200m };
        yield return new { SubSkuUid = burgerUid, Units = 1_200, Amount = 840_000m };
        yield return new { SubSkuUid = friesUid, Units = 2_100, Amount = 441_000m };
    }
}