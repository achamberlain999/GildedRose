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
            foreach (var item in Items)
            {
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality--;
                    }
                }
                else
                {
                    item.Quality++;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
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

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
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
