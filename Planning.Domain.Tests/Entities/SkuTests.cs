using FluentAssertions;
using Planning.Domain.Entities;
using Xunit;

namespace Planning.Domain.Tests.Entities;

public class SkuTests
{
    [Fact]
    public void UpdateSubSku()
    {
        // arrange
        var sku = DrinksSubSku();
        var subSku = sku.Children.First() as SubSku;
        
        var expectedUnits = 1234;
        var expectedAmount = 1123454m;
        // act
        sku.UpdateSubSku(subSku.Uid, expectedUnits, expectedAmount);
            
        // assert
        var actual = sku.Children.First() as SubSku;
        actual.PlanningY1.Units.Should().Be(expectedUnits);
        actual.PlanningY1.Amount.Should().Be(expectedAmount);
    }
    
    [Theory]
    [MemberData(nameof(InvalidUpdateSubSkuData))]
    public void ThrowsIfInvalidUpdateSubSku(int? units, decimal? amount)
    {
        // arrange
        var sku = DrinksSubSku();
        var subSku = sku.Children.First() as SubSku;
        
        // act
        Action action = () => sku.UpdateSubSku(subSku.Uid, units, amount);
            
        // assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    public static IEnumerable<object?[]> InvalidUpdateSubSkuData =>
        new List<object?[]>
        {
            new object?[] { -1234, 1123454m },
            new object?[] { 1234, -1123454m },
            new object?[] { -1234, -1123454m }
        };
    
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
}