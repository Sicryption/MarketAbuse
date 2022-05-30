using System.Collections.Generic;
using System.Linq;

namespace MarketAbuse.Filters
{
    public class LargeMarginsFilter : TimeBasedFilter
    {
        public LargeMarginsFilter() : 
            base(30, "Large Margins")
        {

        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return base.filter(list)
                .Where(a => a.ProfitAmount >= 10000);
        }
    }
}
