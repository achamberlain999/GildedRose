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
        
        private static int RestrictQuality(int quality)
        {
            if (quality > MaxQuality)
            {
                return MaxQuality;
            }
            
            return quality < MinQuality ? MinQuality : quality;
        }

        // These 4 functions could go in the subclasses corresponding to that item
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
        
        // These two functions would be replaced with the identifyItem method
        private static int QualityChange(string name, int sellIn, int quality)
        {
            return name switch
            {
                "Backstage passes to a TAFKAL80ETC concert" => RestrictQuality(
                    quality + QualityChange_BackstagePass(sellIn)),
                "Aged Brie" => RestrictQuality(quality + QualityChange_AgedBrie(sellIn)),
                "Conjured Mana Cake" => RestrictQuality(quality + QualityChange_Conjured(sellIn)),
                "Sulfuras, Hand of Ragnaros" => quality,
                _ => RestrictQuality(quality + QualityChange_Normal(sellIn)),
            };
        }
        
        private static int SellInChange(string name, int sellIn)
        {
            return name switch
            {
                "Sulfuras, Hand of Ragnaros" => sellIn,
                _ => sellIn - 1,
            };
        }
        
        public void DailyUpdate()
        {
            foreach (var item in _items)
            {
                item.Quality = QualityChange(item.Name, item.SellIn, item.Quality);
                item.SellIn = SellInChange(item.Name, item.SellIn);
            }
        }
    }
}