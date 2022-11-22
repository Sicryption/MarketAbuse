using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarketAbuse.Filters
{
    public abstract class AbstractFilter
    {
        public AbstractFilter(string filterName)
        {
            Name = filterName;
        }

        public abstract IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list);

        public string Name { get; set; }
    }
}
