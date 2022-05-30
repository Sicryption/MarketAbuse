using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAbuse.OSRSObjects
{
    public class OSRSItemTimeSeries
    {
        public long timestamp { get; set; }
        public long duration_min { get; set; }
        public int averageLowPrice { get; set; }
        public int averageHighPrice { get; set; }
        public int lowPriceVolume { get; set; }
        public int highPriceVolume { get; set; }
    }
}
