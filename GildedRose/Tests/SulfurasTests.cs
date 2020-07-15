using System.Collections.Generic;
using Xunit;

namespace csharpcore.Tests
{
    public class SulfurasTests
    {
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
        public void SulfurasAllowedQualityEighty()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(80, items[0].Quality);
        }
    }
}