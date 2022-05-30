using System.Collections.Generic;
using System.Linq;

namespace MarketAbuse.Filters
{
    public class SearchFilter : AbstractFilter
    {
        public SearchFilter() :
            base("Search")
        {

        }

        public void setSearchTerm(string searchTerm)
        {
            this.searchTerm = searchTerm.ToLower();
        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return list.Where(a => a.Information.Name.ToLower().Contains(searchTerm));
        }

        string searchTerm = "";
    }
}
