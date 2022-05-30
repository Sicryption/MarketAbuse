using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MarketAbuse.Filters
{
    public class ValidPricingFilter : AbstractFilter
    {
        protected ValidPricingFilter(string filterName) :
            base(filterName)
        {

        }

        bool hasValidPricing(OSRSItemViewModel item)
        {
            if(item.Prices == null || item.AveragePrices == null)
            {
                return false;
            }

            if(item.Prices.BuyPrice == 0 || item.Prices.SellPrice == 0)
            {
                return false;
            }

            int outlierAmount = (int)(item.AveragePrices.AverageHighPrice * 0.50);

            if (Math.Abs(item.Prices.BuyPrice - item.AveragePrices.AverageHighPrice) > outlierAmount)
            {
                return false;
            }
            if (Math.Abs(item.Prices.SellPrice - item.AveragePrices.AverageLowPrice) > outlierAmount)
            {
                return false;
            }

            return true;
        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return list.Where(a => hasValidPricing(a));
        }
    }
}
