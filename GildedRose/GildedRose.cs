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

        public void UpdateQuality()
        {
            const string brie = "Aged Brie";
            const string backstage = "Backstage passes to a TAFKAL80ETC concert";
            const string sufluras = "Sulfuras, Hand of Ragnaros";

            foreach (var item in Items)
            {
                if (item.Name != brie && item.Name != backstage)
                {
                    if (item.Name != sufluras)
                    {
                        item.Quality--;
                    }
                }
                else
                {
                    item.Quality++;

                    if (item.Name == backstage)
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality++;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality++;
                        }
                    }
                }

                if (item.Name != sufluras)
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != brie)
                    {
                        if (item.Name != backstage)
                        {
                            if (item.Name != sufluras)
                            {
                                item.Quality--;
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        item.Quality++;
                    }
                }
                
                if (item.Quality > 50)
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
