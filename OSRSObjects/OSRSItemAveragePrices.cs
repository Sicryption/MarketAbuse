using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarketAbuse.OSRSObjects
{
    public class OSRSItemAveragePrices
    {
        public uint Id { get; set; }

        public int AverageHighPrice { get; set; }

        public int AverageLowPrice { get; set; }

        public uint LowPriceVolume { get; set; }

        public uint HighPriceVolume { get; set; }
        public uint ItemAverageTimeframe_min { get; set; }
    }
}
