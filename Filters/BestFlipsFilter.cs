using System.Collections.Generic;
using System.Linq;

namespace MarketAbuse.Filters
{
    public class BestFlipsFilter : TimeBasedFilter
    {
        public BestFlipsFilter() :
            base(30, "Best Flips")
        {

        }

        public BestFlipsFilter(string filterName) : 
            base(30, filterName)
        {

        }

        bool goodQuantitySold(OSRSItemViewModel item)
        {
            if(item.AveragePrices == null)
            {
                return false;
            }

            uint quantityInFourHours = item.AveragePrices.HighPriceVolume + item.AveragePrices.LowPriceVolume;
            quantityInFourHours /= (item.AveragePrices.ItemAverageTimeframe_min / (60 * 4));

            return quantityInFourHours >= item.Information.BuyLimit;
        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return base.filter(list)
                .Where(a => goodQuantitySold(a))
                .Where(a => a.ProfitAmount > 100)
                .Where(a => a.MaxPotentialProfit > 50000)
                .Where(a =>
                {
                    uint volumePerHour = (uint)((a.AveragePrices.HighPriceVolume + a.AveragePrices.LowPriceVolume) / ((double)a.AveragePrices.ItemAverageTimeframe_min / 60));


                    return volumePerHour > (a.Information.BuyLimit / 4);
                });
        }
    }
}
