using System.Collections.Generic;
using Xunit;

namespace csharpcore.Tests
{
    public class BackstagePassesTests
    {
        [Fact]
        public void BackstagePassesIncreaseAtRateOneWithMoreThanTenDays()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesIncreaseAtRateTwoBetweenFiveAndTenDays()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(22, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesIncreaseAtRateThreeBetweenZeroAndFiveDays()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(23, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQualityIsZeroAfterEvent()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 25}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }
    }
}