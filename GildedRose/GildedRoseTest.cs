using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void QualityDecreasesWithTime()
        {
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(19, items[0].Quality);
        }

        [Fact]
        public void SellInDecreasesWithTime()
        {
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
        }
        
        [Fact]
        public void QualityDecreasesTwiceAsFastPastSellByDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(18, items[0].Quality);
        }
        
        [Fact]
        public void QualityIsNeverNegative()
        {
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }
        
        [Fact]
        public void AgedBrieIncreasesInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(21, items[0].Quality);
        }
        
                
        [Fact]
        public void QualityNeverExceedsFifty()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 20, Quality = 50}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }
        
        [Fact]
        public void SulfurasNeedsNotToBeSold()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(10, items[0].SellIn);
        }
        
        [Fact]
        public void SulfurasDoesNotDecreaseInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 15, Quality = 20}};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(20, items[0].Quality);
        }
        
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
        
        [Fact]
        public void SulfurasAllowedQualityEighty()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(80, items[0].Quality);
        }
        
        [Fact]
        public void ConjuredItemsDegradeFaster()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 40}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(38, items[0].Quality);
        }
    }
}