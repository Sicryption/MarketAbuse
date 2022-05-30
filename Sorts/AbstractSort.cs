using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MarketAbuse.Sorts
{
    public abstract class AbstractSort
    {
        public AbstractSort(string sortName)
        {
            Name = sortName;
        }

        public abstract IEnumerable<OSRSItemViewModel> sort(IEnumerable<OSRSItemViewModel> list);

        public string Name { get; set; }
    }
}
