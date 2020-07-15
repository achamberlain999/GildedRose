using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTests
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
    }
}