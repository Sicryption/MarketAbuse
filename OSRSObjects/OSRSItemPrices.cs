using System;
using System.Collections.Generic;
using System.Text;

namespace MarketAbuse.OSRSObjects
{
    public class OSRSItemPrices
    {
        public int Id { get; set; }
        public int BuyPrice { get; set; }
        public long BuyPriceTimestamp { get; set; }
        public int SellPrice { get; set; }
        public long SellPriceTimestamp { get; set; }
    }
}
