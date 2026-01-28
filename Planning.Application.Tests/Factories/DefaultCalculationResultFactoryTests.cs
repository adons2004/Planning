using AutoFixture;
using FluentAssertions;
using Planning.Application.Factories;
using Planning.Application.Queries.Request;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Domain.Calculations;
using Planning.Domain.Entities;
using Xunit;

namespace Planning.Application.Tests.Factories;

public class DefaultCalculationResultFactoryTests
{
    private readonly Fixture _fixture;
    public DefaultCalculationResultFactoryTests()
    {
        _fixture = new Fixture();
    }
    
    [Fact]
    public void AllLevelsImplemented()
    {
        // arrange
        var total = TotalSku();
        var factory = new DefaultCalculationResultFactory();
        
        // act
        var actions = Enum.GetValues<Level>()
            .Select(level => new Action(() => factory.Create(level, total)))
            .ToList();

        // assert
        actions.ForEach(action => action.Should().NotThrow<ArgumentOutOfRangeException>());
    }
    private Sku DrinksSubSku()
    {
        var coke = new SubSku("Кола 0.5л", new HistoryY0(1_000, 80_000m), new PlanningY1(1_200, 102_000m), 85m, 1);
        var water = new SubSku("Вода 1.5л", new HistoryY0(2_000, 80_000m), new PlanningY1(2_100, 88_200m), 42m, 1);
        
        var sku = new Sku("Напитки");
        sku.Add(coke);
        sku.Add(water);

        return sku;
    }
    
    private Sku FoodsSubSku()
    {
        var coke = new SubSku("Бургер", new HistoryY0(1_000, 600_000m), new PlanningY1(1_200, 840_000m ), 700m, 1);
        var water = new SubSku("Картофель-фри", new HistoryY0(2_000, 380_000m), new PlanningY1(2_100, 441_000m), 210m, 1);
        
        var sku = new Sku("Еда");
        sku.Add(coke);
        sku.Add(water);

        return sku;
    }

    private TotalSku TotalSku()
    {
        var drinks = DrinksSubSku();
        var foods = FoodsSubSku();

        var sku = new TotalSku(drinks, foods);
        
        return sku;
    }
}