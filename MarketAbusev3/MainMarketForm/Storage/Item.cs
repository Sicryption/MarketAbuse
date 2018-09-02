using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMarketForm
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void SetChanges()
        {
            OnPropertyChanged("buyPrice");
            OnPropertyChanged("sellPrice");
            OnPropertyChanged("buyPriceFormatted");
            OnPropertyChanged("sellPriceFormatted");
            OnPropertyChanged("marginFormatted");
            OnPropertyChanged("buyQuantity");
            OnPropertyChanged("sellQuantity");
            OnPropertyChanged("buyAverage");
            OnPropertyChanged("sellAverage");
            OnPropertyChanged("overallAverage");
            OnPropertyChanged("overallPrice");
            OnPropertyChanged("showAdvancedOptions");
        }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("sell_average")]
        public int sellAverage { get; set; }

        [JsonProperty("sp")]
        public int shopBuyPrice { get; set; }

        [JsonProperty("buy_average")]
        public int buyAverage { get; set; }

        [JsonProperty("overall_average")]
        public int overallAverage { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("members")]
        public bool members { get; set; }

        private int buyValue = 0;
        public int buyPrice { get { return buyValue; }
            set
            {
                SetChanges();
                buyValue = value;
            } }
        private int sellValue = 0;
        public int sellPrice
        {
            get { return sellValue; }
            set
            {
                SetChanges();
                sellValue = value;
            }
        }
        public int overallPrice { get; set; }
        private int buyQuantityValue = 0;
        public int buyQuantity
        {
            get { return buyQuantityValue; }
            set
            {
                SetChanges();
                buyQuantityValue = value;
            }
        }
        private int sellQuantityValue = 0;
        public int sellQuantity
        {
            get { return sellQuantityValue; }
            set
            {
                SetChanges();
                sellQuantityValue = value;
            }
        }

        public string shortHand = "";
        public string shortHandName { get { return shortHand; } set { shortHand = value; } }

        public int highAlch { get { return (int)(shopBuyPrice * 0.6); } }
        public int lowAlch { get { return (int)(shopBuyPrice * 0.3); } }
        public int shopSellPrice { get { return (int)(shopBuyPrice * 0.55); } }

        public int buyPriceFormatted { get { return buyQuantity == 0 ? buyAverage : buyPrice; } set { } }
        public int sellPriceFormatted { get { return sellQuantity == 0 ? sellAverage : sellPrice; } set { } }
        public int marginFormatted { get { return sellPriceFormatted - buyPriceFormatted; } set { } }


        public bool shouldBeVisible { get { return buyPriceFormatted != 0 && sellPriceFormatted != 0 && sellQuantity != 0 && buyQuantity != 0; } }
        private bool advancedOptions = false;
        public bool showAdvancedOptions { get { return advancedOptions; } set { advancedOptions = value; } }

        public string imageDirectory
        {
            get { return Directory.GetCurrentDirectory() + "\\Images\\" + id + ".png"; }
        }
    }
}
