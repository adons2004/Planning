using AutoFixture;
using BenchmarkDotNet.Attributes;
using Planning.Domain.Calculations;
using Planning.Domain.Entities;

namespace Planning.Domain.Benchmarks.Calculations;

public class SkuCalculationBenchmarks
{
    public SkuCalculationBenchmarks()
    {
        _fixture = new Fixture();
        _totalSku = TotalSku();
    }
    [Benchmark]
    public void Calculate()
    {
        var history = _totalSku.HistoryY0Params;
        var planning = _totalSku.PlanningY1Params;
        var contributionGrowth = _totalSku.ContributionGrowth;
    }
    
    private Sku DrinksSubSku()
    {
        var sku = new Sku("Напитки");

        var count = 0;
        while (count < 1000)
        {
            var drink = new SubSku(
                _fixture.Create<string>(),
                new HistoryY0(_fixture.Create<int>(), _fixture.Create<decimal>()),
                new PlanningY1(_fixture.Create<int>(), _fixture.Create<decimal>()),
                _fixture.Create<decimal>(),
                _fixture.Create<decimal>());
            sku.Add(drink);
            count++;
        }
        
        return sku;
    }
    
    private Sku FoodsSubSku()
    {
        var sku = new Sku("Еда");

        var count = 0;
        while (count < 1000)
        {
            var drink = new SubSku(
                _fixture.Create<string>(),
                new HistoryY0(_fixture.Create<int>(), _fixture.Create<decimal>()),
                new PlanningY1(_fixture.Create<int>(), _fixture.Create<decimal>()),
                _fixture.Create<decimal>(),
                _fixture.Create<decimal>());
            sku.Add(drink);
            count++;
        }
        
        return sku;
    }
    
    private TotalSku TotalSku()
    {
        var drinks = DrinksSubSku();
        var foods = FoodsSubSku();

        var sku = new TotalSku(drinks, foods);
        
        return sku;
    }
    
    private TotalSku _totalSku;
    private Fixture _fixture;
}