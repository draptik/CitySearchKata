using FluentAssertions;
using Xunit;
using A = Demo.Helper;

namespace Demo
{
    public class CitySearchTests
    {
        [Fact]
        public void NoCitiesFound()
        {
            var result = searcher.Search("test");
            result.Should().BeEquivalentTo(A.EmptyList);
        }
    }
}