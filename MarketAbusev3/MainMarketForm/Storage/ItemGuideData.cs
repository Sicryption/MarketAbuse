using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMarketForm
{
    public class ItemGuideData
    {
        [JsonProperty("overall")]
        public int averagePrice { get; set; }

        [JsonProperty("buying")]
        public int buyPrice { get; set; }

        [JsonProperty("buyingQuantity")]
        public int buyingQuantity { get; set; }

        [JsonProperty("selling")]
        public int sellPrice { get; set; }

        [JsonProperty("sellingQuantity")]
        public int sellQuantity { get; set; }
       
        public int margin { get { return buyPrice - sellPrice; } }
    }
}
