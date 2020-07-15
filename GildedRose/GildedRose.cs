using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        private int BackstageQualityIncrease(int sellIn)
        {
            if (sellIn > 10)
            {
                return 1;
            }

            if (sellIn > 5)
            {
                return 2;
            }

            if (sellIn > 0)
            {
                return 3;
            }

            return -50;
        }
        
        private int BrieQualityIncrease(int sellIn)
        {
            return sellIn <= 0 ? 2 : 1;
        }

        private int GenericQualityDecrease(int sellIn)
        {
            return sellIn <= 0 ? 2 : 1;
        }

        public void UpdateQuality()
        {
            const string brie = "Aged Brie";
            const string backstage = "Backstage passes to a TAFKAL80ETC concert";
            const string sulfuras = "Sulfuras, Hand of Ragnaros";

            foreach (var item in Items)
            {
                if (item.Name == backstage)
                {
                    item.Quality += BackstageQualityIncrease(item.SellIn);
                }
                else if (item.Name == brie)
                {
                    item.Quality += BrieQualityIncrease(item.SellIn);
                }
                else if (item.Name != sulfuras)
                {
                    item.Quality -= GenericQualityDecrease(item.SellIn);
                }

                if (item.Name != sulfuras)
                {
                    item.SellIn--;
                }

                if (item.Quality > 50 && item.Name != sulfuras)
                {
                    item.Quality = 50;
                }
                
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}
