using System.Collections.Generic;
using System.Linq;

namespace MarketAbuse.Filters
{
    class HighVolumeFilter : BestFlipsFilter
    {
        public HighVolumeFilter() :
            base("High Volume")
        {

        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return base.filter(list)
                .Where(a => a.AveragePrices.HighPriceVolume >= 1000 && a.AveragePrices.LowPriceVolume >= 1000);
        }
    }
}
