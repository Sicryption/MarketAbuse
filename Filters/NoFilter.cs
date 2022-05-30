using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAbuse.Filters
{
    public class NoFilter : AbstractFilter
    {
        public NoFilter() :
            base("No Filter")
        {

        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return list;
        }
    }
}
