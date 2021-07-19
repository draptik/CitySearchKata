using System.Collections.Generic;
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
            var searcher = new Searcher();
            var result = searcher.Search("test");
            result.Should().BeEquivalentTo(A.EmptyList);
        }
    }

    public class Searcher
    {
        public List<string> Search(string keyword)
        {
            throw new System.NotImplementedException();
        }
    }
}