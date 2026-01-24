using FluentAssertions;
using Planning.Domain.Contracts;
using Xunit;

namespace Planning.Domain.Tests.Calculations;

public class SkuCalculationTests
{
    /*
    [Fact]
    public void SubSkuCalculationHistoryY0Successful()
    {
        //arrange
        var sku = DrinksSubSku();
        
        //act
        var units = sku.GetHistoryY0Parameters().Units;
        var amount = sku.GetHistoryY0Parameters().Amount;
        var price = sku.GetHistoryY0Parameters().Price;

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
        var units = sku.GetPlanningY1Parameters().Units;
        var amount = sku.GetPlanningY1Parameters().Amount;
        var price = sku.GetPlanningY1Parameters().Price;

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
        var contributionGrowth = sku.GetContributionGrowth();

        //assert
        contributionGrowth.Should().Be(18.875m);
    }
    
    [Fact]
    public void SkuCalculationHistoryY0Successful()
    {
        //arrange
        var sku = TotalSku();
        
        //act
        var units = sku.GetHistoryY0Parameters().Units;
        var amount = sku.GetHistoryY0Parameters().Amount;
        var price = sku.GetHistoryY0Parameters().Price;

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
        var units = sku.GetPlanningY1Parameters().Units;
        var amount = sku.GetPlanningY1Parameters().Amount;
        var price = sku.GetPlanningY1Parameters().Price;

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
        var contributionGrowth = sku.ContributionGrouth;

        //assert
        contributionGrowth.Should().Be(29.052631578947368421052631580m);
    }

    private Sku DrinksSubSku()
    {
        var coke = new SubSku("Кола 0.5л", new Parameters(1_000, 80m), new Parameters(1_200, 85.00m));
        var water = new SubSku("Вода 1.5л", new Parameters(2_000, 40m), new Parameters(2_100, 42.00m));
        
        var sku = new Sku("Напитки");
        sku.Add(coke);
        sku.Add(water);

        return sku;
    }
    
    private Sku FoodsSubSku()
    {
        var coke = new SubSku("Бургер", new Parameters(1_000, 600m), new Parameters(1_200, 700m ));
        var water = new SubSku("Картофель-фри", new Parameters(2_000, 190m), new Parameters(2_100, 210m));
        
        var sku = new Sku("Еда");
        sku.Add(coke);
        sku.Add(water);

        return sku;
    }
    
    private Sku TotalSku()
    {
        var drinks = DrinksSubSku();
        var foods = FoodsSubSku();

        var sku = new Sku("TOTAL");
        sku.Add(drinks);
        sku.Add(foods);
        
        return sku;
    }
    */
}