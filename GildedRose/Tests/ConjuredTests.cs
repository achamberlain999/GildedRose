using System.Collections.Generic;
using Xunit;

namespace csharpcore.Tests
{
    public class ConjuredTests
    {
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