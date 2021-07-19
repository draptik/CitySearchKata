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
            result.Should().BeEquivalentTo(A.EmptyList);
        }
    }
}