using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MarketAbuse.Sorts
{
    public class SortFactory
    {
        public static void Initialize()
        {
            Sorts = new List<AbstractSort>()
            { 
                new AlphabeticalSort(),
                new HighestProfitPerItemSort(),
                new MaxPotentialProfitSort()
            };
        }

        public static AbstractSort createSort(string sortName)
        {
            foreach(var sort in Sorts)
            {
                if (sort.Name == sortName)
                {
                    return sort;
                }
            }

            return null;
        }

        public static List<AbstractSort> Sorts;
    }
}
