using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Generic;
using MarketAbuse.Converters;

namespace MarketAbuse.Filters
{
    public class TimeBasedFilter : ValidPricingFilter
    {
        protected TimeBasedFilter(double withinXMinutes, string filterName) : 
            base(filterName)
        {
            this.withinXMinutes = withinXMinutes;
        }

        bool isWithinTimeFrame(OSRSItemViewModel item)
        {
            var now = DateTime.Now;
            var buyTime = utcToLocalDateTimeConverter.RawConvert(item.Prices.BuyPriceTimestamp);
            var sellTime = utcToLocalDateTimeConverter.RawConvert(item.Prices.SellPriceTimestamp);

            return (now - buyTime).TotalMinutes <= withinXMinutes && (now - sellTime).TotalMinutes <= withinXMinutes;
        }

        public override IEnumerable<OSRSItemViewModel> filter(IEnumerable<OSRSItemViewModel> list)
        {
            return base.filter(list)
                .Where(a => isWithinTimeFrame(a));
        }

        private double withinXMinutes;
        UtcToLocalDateTimeConverter utcToLocalDateTimeConverter = new UtcToLocalDateTimeConverter();
    }
}
