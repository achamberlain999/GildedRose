using System.Collections.Generic;
using Xunit;

namespace csharpcore.Tests
{
    public class AgedBrieTests
    {
        [Fact]
        public void AgedBrieIncreasesInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20}};
            var app = new GildedRose(items);
            app.DailyUpdate();
            Assert.Equal(21, items[0].Quality);
        }
    }
}