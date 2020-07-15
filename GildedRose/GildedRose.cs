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

        private static int BackstageQualityIncrease(int sellIn)
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

        private static int NormalQualityDecrease(int sellIn)
        {
            const int normalDecrease = 1;
            const int outOfDateMultiplier = 2;
            return sellIn <= 0 ? outOfDateMultiplier*normalDecrease : normalDecrease;
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
                        item.Quality = RestrictQuality(item.Quality + BackstageQualityIncrease(item.SellIn));
                        item.SellIn--;
                        break;
                    case "Aged Brie":
                        item.Quality = RestrictQuality(item.Quality + NormalQualityDecrease(item.SellIn));
                        item.SellIn--;
                        break;
                    case "Conjured Mana Cake":
                        item.Quality = RestrictQuality(item.Quality - 2 * NormalQualityDecrease(item.SellIn));
                        item.SellIn--;
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        item.Quality = RestrictQuality(item.Quality - NormalQualityDecrease(item.SellIn));
                        item.SellIn--;
                        break;
                }
            }
        }
    }
}
