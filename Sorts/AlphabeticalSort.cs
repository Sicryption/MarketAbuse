using System.Collections.Generic;
using System.Linq;

namespace MarketAbuse.Sorts
{
    public class AlphabeticalSort : AbstractSort
    {
        public AlphabeticalSort() :
            base("Alphabetical")
        {

        }

        public override IEnumerable<OSRSItemViewModel> sort(IEnumerable<OSRSItemViewModel> list)
        {
            return list.OrderBy(a => a.Information.Name);
        }
    }
}
