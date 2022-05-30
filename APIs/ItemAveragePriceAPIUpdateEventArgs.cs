using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    public class ItemAveragePriceAPIUpdateEventArgs : EventArgs
    {
        private readonly ObservableCollection<OSRSItemAveragePrices> itemList;

        public ItemAveragePriceAPIUpdateEventArgs(ObservableCollection<OSRSItemAveragePrices> itemList)
        {
            this.itemList = itemList;
        }

        public ObservableCollection<OSRSItemAveragePrices> ItemList
        { 
            get 
            { 
                return itemList; 
            }
        }
    }
}
