using FluentAssertions;
using Planning.Domain.Contracts;
using Xunit;

namespace Planning.Domain.Tests.Calculations;

public class SkuCalculationTests
{
    [Fact]
    public void SubSkuCalculationHistoryY0Successful()
    {
        //arrange
        var sku = DrinksSubSku();
        
        //act
        var units = sku.HistoryY0Params.Units;
        var amount = sku.HistoryY0Params.Amount;
        var price = sku.HistoryY0Params.Price;

        //assert
        units.Should().Be(3_000);
        amount.Should().Be(160_000);
        price.Should().Be(53.333333333333333333333333333m);
    }
    
    [Fact]
    public void SubSkuCalculationPlanningY1Successful()
    {
        //arrange
        var sku = DrinksSubSku();
        
        //act
        var units = sku.PlanningY1Params.Units;
        var amount = sku.PlanningY1Params.Amount;
        var price = sku.PlanningY1Params.Price;

        //assert
        units.Should().Be(3_300);
        amount.Should().Be(190_200);
        price.Should().Be(57.636363636363636363636363636m);
    }
   
    [Fact]
    public void SubSkuCalculationContributionGrowthSuccessful()
    {
        //arrange
        var sku = DrinksSubSku();
        
        //act
        var contributionGrowth = sku.ContributionGrowth;

        //assert
        contributionGrowth.Should().Be(18.875m);
    }
    
    [Fact]
    public void SkuCalculationHistoryY0Successful()
    {
        //arrange
        var sku = TotalSku();
        
        //act
        var units = sku.HistoryY0Params.Units;
        var amount = sku.HistoryY0Params.Amount;
        var price = sku.HistoryY0Params.Price;

        //assert
        units.Should().Be(6_000);
        amount.Should().Be(1_140_000m);
        price.Should().Be(190m);
    }
    
    [Fact]
    public void SkuCalculationPlanningY1Successful()
    {
        //arrange
        var sku = TotalSku();
        
        //act
        var units = sku.PlanningY1Params.Units;
        var amount = sku.PlanningY1Params.Amount;
        var price = sku.PlanningY1Params.Price;

        //assert
        units.Should().Be(6_600);
        amount.Should().Be(1_471_200m);
        price.Should().Be(222.90909090909090909090909091m);
    }

    [Fact]
    public void SkuCalculationContributionGrowthSuccessful()
    {
        //arrange
        var sku = TotalSku();
        
        //act
        var contributionGrowth = sku.ContributionGrowth;

        //assert
        contributionGrowth.Should().Be(29.052631578947368421052631580m);
    }

    private Sku DrinksSubSku()
    {
        var coke = new SubSku("Кола 0.5л", new HistoryY0(1_000, 80_000m), new PlanningY1(1_200, 102_000m));
        var water = new SubSku("Вода 1.5л", new HistoryY0(2_000, 80_000m), new PlanningY1(2_100, 88_200m));
        
        var sku = new Sku("Напитки");
        sku.Add(coke);
        sku.Add(water);

        return sku;
    }
    
    private Sku FoodsSubSku()
    {
        var coke = new SubSku("Бургер", new HistoryY0(1_000, 600_000m), new PlanningY1(1_200, 840_000m ));
        var water = new SubSku("Картофель-фри", new HistoryY0(2_000, 380_000m), new PlanningY1(2_100, 441_000m));
        
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