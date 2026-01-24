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
        var coke = new SubSku(Guid.Parse("ACE57827-9163-43B5-A928-A5325DF0D3E8"), "Кола 0.5л", new HistoryY0(1_000, 80m), new PlanningY1(1_200, 85.00m));
        var water = new SubSku(Guid.Parse("6903EC64-BA3D-4247-8F09-391AAC12A7B9"),"Вода 1.5л", new HistoryY0(2_000, 40m), new PlanningY1(2_100, 42.00m));
        
        var sku = new Sku(Guid.Parse("0B1BAB69-C3D8-45A7-9264-AE590EB65E84"),"Напитки");
        sku.Add(coke);
        sku.Add(water);

        return sku;
    }
    
    private Sku FoodsSubSku()
    {
        var coke = new SubSku(Guid.Parse("EC095083-F006-4323-94C7-D467E3637CB7"),"Бургер", new HistoryY0(1_000, 600m), new PlanningY1(1_200, 700m ));
        var water = new SubSku(Guid.Parse("ADF2C8C4-9BC4-47FE-B66C-49DFFEB71915"),"Картофель-фри", new HistoryY0(2_000, 190m), new PlanningY1(2_100, 210m));
        
        var sku = new Sku(Guid.Parse("451F4F7A-010D-485B-B90E-6C23B8E65305"),"Еда");
        sku.Add(coke);
        sku.Add(water);

        return sku;
    }
    
    private Total TotalSku()
    {
        var drinks = DrinksSubSku();
        var foods = FoodsSubSku();

        var sku = new Total();
        sku.Add(drinks);
        sku.Add(foods);
        
        return sku;
    }
    */
}