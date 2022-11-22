using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MarketAbuse.Filters
{
    public class RecentlyUpdatedFilter : TimeBasedFilter
    {
        public RecentlyUpdatedFilter() : 
            base(10, "Recently Updated")
        {

        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return base.filter(list)
                .Where(a => a.ProfitAmount > 1000)
                .OrderByDescending(a => a.MaxPotentialProfit);
        }
    }
}
