using AutoFixture;
using FluentAssertions;
using Planning.Application.Queries.Results;
using Planning.Domain;
using Planning.Mapping;
using Planning.Models.Responses;
using Xunit;

namespace Planning.Api.Tests.Mappers;

public class CalculationResultMappingsTests
{
    private readonly Fixture _fixture;
    public CalculationResultMappingsTests()
    {
        _fixture = new Fixture();
    }
    [Fact]
    public void CalculationResultMappingSuccessful()
    {
        // arrange
        var resultData = CreateResult(CreateResult(CreateResult(), CreateResult()), CreateResult());
        var result = new CalculationResult([resultData], []);
        // act
        var response = result.ToApi();
        
        // assert
        response.Should().BeEquivalentTo(result, options => options.WithStrictOrdering());
    }

    private CalculationDataResult CreateResult(params CalculationDataResult[] children)
    {
        return new CalculationDataResult()
        {
            HistoryY0 = new HistoryCalculationResult()
            {
                Units = _fixture.Create<int>(),
                Amount = _fixture.Create<decimal>(),
                Price = _fixture.Create<decimal>()
            },
            PlanningY1 = new PlanningCalculationResult()
            {
                Units = _fixture.Create<int>(),
                Amount = _fixture.Create<decimal>(),
                Price = _fixture.Create<decimal>()
            },
            Children = children
        };
    }
}