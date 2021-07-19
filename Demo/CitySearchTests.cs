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
            var searcher = new Searcher(new KeywordCheck(3));
            var result = searcher.Search("test");
            result.Should().BeEquivalentTo(A.EmptyList);
        }

        [Fact]
        public void CityFound()
        {
            var searcher = new Searcher(new KeywordCheck(3));
            var result = searcher.Search("ber");
            result.Should().BeEquivalentTo("Nuernberg");
        }
        
        [Fact]
        public void AnotherCityFound()
        {
            var searcher = new Searcher(new KeywordCheck(3));
            var result = searcher.Search("rth");
            result.Should().BeEquivalentTo("Fuerth");
        }

        [Fact]
        public void MultipleCitiesFound()
        {
            var searcher = new Searcher(new KeywordCheck(3));
            var result = searcher.Search("new");
            result.Should().BeEquivalentTo("New York", "Newark");
        }

        [Fact]
        public void QueryTooShort()
        {
            var searcher = new Searcher(new KeywordCheck(3));
            var result = searcher.Search("ne");
            result.Should().BeEquivalentTo(A.EmptyList);
        }
    }

    public class Searcher
    {
        private readonly KeywordCheck _keywordCheck;
        private readonly CitiesCatalog _citiesCatalog;

        public Searcher(KeywordCheck keywordCheck)
        {
            _keywordCheck = keywordCheck;
            _citiesCatalog = new CitiesCatalog();
        }

        public List<string> Search(string keyword)
        {
            if (_keywordCheck.HasSufficientLength(keyword))
            {
                var matches = _citiesCatalog.CitiesContaining(keyword);
                return matches;
            }

            return A.EmptyList;
        }
    }

    public class CitiesCatalog
    {
        public List<string> CitiesContaining(string keyword)
        {
            var cities = new List<string> {"Nuernberg", "Fuerth", "New York", "Newark"};
            var matches = cities.Where(x => x.ToLower().Contains(keyword)).ToList();
            return matches;
        }
    }

    public class KeywordCheck
    {
        private readonly int _minRequiredLength;

        public KeywordCheck(int minRequiredLength)
        {
            _minRequiredLength = minRequiredLength;
        }

        public bool HasSufficientLength(string keyword)
        {
            return keyword.Length >= _minRequiredLength;
        }
    }
}