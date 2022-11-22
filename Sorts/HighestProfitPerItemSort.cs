using System.Collections.Generic;
using System.Linq;

namespace MarketAbuse.Sorts
{
    public class HighestProfitPerItemSort : AbstractSort
    {
        public  HighestProfitPerItemSort() :
            base("Highest profit per item")
        {

        }

        public override IEnumerable<OSRSItemViewModel> sort(IEnumerable<OSRSItemViewModel> list)
        {
            return list.OrderByDescending(a => a.ProfitAmount);
        }
    }
}
