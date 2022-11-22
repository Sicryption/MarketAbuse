using System.Collections.Generic;
using System.Linq;

namespace MarketAbuse.Filters
{
    public class FavoritedItemFilter : AbstractFilter
    {
        public FavoritedItemFilter() :
            base("Favorited Items")
        {

        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return list.Where(a => a.IsFavorited);
        }
    }
}
