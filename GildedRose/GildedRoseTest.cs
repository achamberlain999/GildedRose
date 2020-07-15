using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void Foo()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
        }

        [Fact]
        public void QualityDecreasesWithTime_DexterityVest()
        {
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}};
            GildedRose app = new GildedRose(items);
            for (var i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal(15, items[0].Quality);
        }

        [Fact]
        public void SellInDecreasesWithTime_AgedBrie()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20}};
            GildedRose app = new GildedRose(items);
            for (var i = 0; i < 8; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal(2, items[0].SellIn);
        }
        
        [Fact]
        public void QualityDegradesTwiceAsFastPastSellByDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Dexterity Vest", SellIn = 5, Quality = 20}};
            GildedRose app = new GildedRose(items);
            for (var i = 0; i < 10; i++)
            {
                app.UpdateQuality();
            }

            Assert.Equal(5, items[0].Quality);
        }
        
        [Fact]
        public void QualityIsNeverNegative()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Dexterity Vest", SellIn = 10, Quality = 5}};
            GildedRose app = new GildedRose(items);
            for (var i = 0; i < 15; i++)
            {
                app.UpdateQuality();
            }

            Assert.Equal(0, items[0].Quality);
        }
    }
}