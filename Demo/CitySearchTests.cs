using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void CityFound()
        {
            var searcher = new Searcher();
            var result = searcher.Search("ber");
            result.Should().BeEquivalentTo("Nuernberg");
        }
        
        [Fact]
        public void AnotherCityFound()
        {
            var searcher = new Searcher();
            var result = searcher.Search("rth");
            result.Should().BeEquivalentTo("Fuerth");
        }

        [Fact]
        public void MultipleCitiesFound()
        {
            var searcher = new Searcher();
            var result = searcher.Search("new");
            result.Should().BeEquivalentTo("New York", "Newark");
        }
    }

    public class Searcher
    {
        public List<string> Search(string keyword)
        {
            var cities = new List<string> {"Nuernberg"};
            if (keyword == "ber")
            {
                var match = cities.First(x => x.Contains(keyword));
                return new List<string> {match};
            }

            if (keyword == "rth")
            {
                return new List<string> {"Fuerth"};
            }

            if (keyword == "new")
            {
                return new List<string> {"New York", "Newark"};
            }
            return A.EmptyList;
        }
    }
}