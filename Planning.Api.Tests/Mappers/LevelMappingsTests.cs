using FluentAssertions;
using Planning.Application.Queries.Request;
using Planning.Mapping;
using Planning.Models.Requests;
using Xunit;

namespace Planning.Api.Tests.Mappers;

public class LevelMappingsTests
{
    [Fact]
    public void LevelMappingSuccessful()
    {
        // arrange
        var levelsApi = Enum.GetValues<LevelRequest>();
        var expectedLevels = Enum.GetValues<Level>();
        
        // act
        var actualLevels = levelsApi.Select(level => level.ToApplicationLevel()).ToArray();
        
        //assert
        levelsApi.Length.Should().Be(expectedLevels.Length);
        actualLevels.Should().BeEquivalentTo(expectedLevels, options => options.WithStrictOrdering());
    }
}