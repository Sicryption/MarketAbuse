using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MarketAbuse.OSRSObjects;

namespace MarketAbuse
{
    public class OSRSItemViewModel : INotifyPropertyChanged
    {
        private OSRSItemPrices prices;
        public OSRSItemPrices Prices
        {
            get
            {
                return prices;
            }
            set
            {
                prices = value;
                OnPropertyChanged(nameof(Prices));
                OnPropertyChanged(nameof(ProfitAmount));
                OnPropertyChanged(nameof(MaxPotentialProfit));
            }
        }

        private OSRSItemAveragePrices averagePrices;
        public OSRSItemAveragePrices AveragePrices
        {
            get
            {
                return averagePrices;
            }
            set
            {
                averagePrices = value;
                OnPropertyChanged(nameof(AveragePrices));
            }
        }

        private OSRSItemInformation information;
        public OSRSItemInformation Information
        {
            get
            {
                return information;
            }
            set
            {
                information = value;
                OnPropertyChanged(nameof(Information));
            }
        }
        private OSRSItemImage image;
        public OSRSItemImage Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private bool favorited;
        public bool IsFavorited
        { 
            get
            {
                return favorited;
            }
            set
            {
                favorited = value;
                OnPropertyChanged(nameof(IsFavorited));
            }
        }

        public int ProfitAmount 
        { 
            get
            {
                if(Prices == null)
                {
                    return 0;
                }

                int preTaxAmount = Prices.BuyPrice - Prices.SellPrice;
                int taxAmount = (int)(Prices.BuyPrice * 0.01);
                if(taxAmount > 5000000)
                {
                    taxAmount = 5000000;
                }

                int profit = preTaxAmount - taxAmount;

                if(Prices.Id == BOND_ID)
                {
                    profit -= (int)(Prices.BuyPrice * 0.1);
                }

                return profit;
            }
        }

        public int MaxPotentialProfit
        {
            get
            {
                return ProfitAmount * (int)Information.BuyLimit;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private const int BOND_ID = 13190;
    }
}
