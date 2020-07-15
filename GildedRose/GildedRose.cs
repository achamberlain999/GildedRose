using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        private static int QualityChange_BackstagePass(int sellIn)
        {
            const int firstIncrease = 10;
            const int secondIncrease = 5;
            const int thirdIncrease = 0;
            
            if (sellIn > firstIncrease)
            {
                return 1;
            }

            if (sellIn > secondIncrease)
            {
                return 2;
            }

            if (sellIn > thirdIncrease)
            {
                return 3;
            }

            return -MaxQuality;
        }

        private static int QualityChange_AgedBrie(int sellIn)
        {
            return sellIn <= 0 ? 2 : 1;
        }
        
        private static int QualityChange_Normal(int sellIn)
        {
            return sellIn <= 0 ? -2 : -1;
        }

        private static int QualityChange_Conjured(int sellIn)
        {
            return 2 * QualityChange_Normal(sellIn);
        }

        private static int RestrictQuality(int quality)
        {
            if (quality > MaxQuality)
            {
                return MaxQuality;
            }
            
            return quality < MinQuality ? MinQuality : quality;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                switch (item.Name)
                {
                    case "Backstage passes to a TAFKAL80ETC concert":
                        item.Quality = RestrictQuality(item.Quality + QualityChange_BackstagePass(item.SellIn));
                        item.SellIn--;
                        break;
                    case "Aged Brie":
                        item.Quality = RestrictQuality(item.Quality + QualityChange_AgedBrie(item.SellIn));
                        item.SellIn--;
                        break;
                    case "Conjured Mana Cake":
                        item.Quality = RestrictQuality(item.Quality + QualityChange_Conjured(item.SellIn));
                        item.SellIn--;
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        item.Quality = RestrictQuality(item.Quality + QualityChange_Normal(item.SellIn));
                        item.SellIn--;
                        break;
                }
            }
        }
    }
}
