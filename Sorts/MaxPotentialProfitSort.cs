using System.Collections.Generic;
using System.Linq;

namespace MarketAbuse.Sorts
{
    public class MaxPotentialProfitSort : AbstractSort
    {
        public  MaxPotentialProfitSort() :
            base("Max potential profit")
        {

        }

        public override IEnumerable<OSRSItemViewModel> sort(IEnumerable<OSRSItemViewModel> list)
        {
            return list.OrderByDescending(a => a.MaxPotentialProfit);
        }
    }
}
