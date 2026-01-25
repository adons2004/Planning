using FluentAssertions;
using Planning.Infrastructure.Tests.Host;
using Xunit;

namespace Planning.Infrastructure.Tests.Repositories;

public class SkuRepositoryTests : IClassFixture<InfrastructureTestHost>
{
    private readonly InfrastructureTestHost _testHost;

    public SkuRepositoryTests(InfrastructureTestHost testHost)
    {
        _testHost = testHost;
    }
    
    [Fact]
    public async Task SeedSuccessful()
    {
        // act
        var skus = await _testHost.SkuRepository.Get(CancellationToken.None);

        // assert
        skus.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task GetByUidSuccessful()
    {
        // arrange
        var uid = Guid.Parse("ACE57827-9163-43B5-A928-A5325DF0D3E8");
        
        // act
        var sku = await _testHost.SkuRepository.Get(uid, CancellationToken.None);
        
        // assert

        sku.Should().NotBeNull();
    }
    
    [Fact]
    public async Task UpdateSuccessful()
    {
        // arrange
        var uid = Guid.Parse("ACE57827-9163-43B5-A928-A5325DF0D3E8");
        var sku = await _testHost.SkuRepository.Get(uid, CancellationToken.None);
        var subSku = sku.SubSkus.First();
        
        // act
        subSku.PlanningY1.SetAmount(300);
        subSku.PlanningY1.SetUnits(1_300);
        
        _testHost.SkuRepository.Update(sku);
        _testHost.SkuRepository.SaveChanges();
        
        // assert
        var actualSku = await _testHost.SkuRepository.Get(uid, CancellationToken.None);
        var actualSubSku = actualSku.SubSkus.First();

        subSku.Should().BeEquivalentTo(actualSubSku);
        actualSubSku.PlanningY1.Amount.Should().Be(300);
        actualSubSku.PlanningY1.Units.Should().Be(1_300);
    }
}