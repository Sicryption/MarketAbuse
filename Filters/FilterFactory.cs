using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAbuse.Filters
{
    public class FilterFactory
    {
        public static void Initialize()
        {
            Filters = new List<AbstractFilter>()
            {
                new BestFlipsFilter(),
                new HighVolumeFilter(),
                new LargeMarginsFilter(),
                new NoFilter(),
                new RecentlyUpdatedFilter(),
                new FavoritedItemFilter()
            };
        }

        public static AbstractFilter createFilter(string filterName)
        {
            foreach (var filter in Filters)
            {
                if (filter.Name == filterName)
                {
                    return filter;
                }
            }

            return null;
        }

        public static List<AbstractFilter> Filters;
    }
}
