using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    class ItemPriceAPIUpdateEventArgs : EventArgs
    {
        private readonly ObservableCollection<OSRSItemPrices> itemList;

        public ItemPriceAPIUpdateEventArgs(ObservableCollection<OSRSItemPrices> itemList)
        {
            this.itemList = itemList;
        }

        public ObservableCollection<OSRSItemPrices> ItemList
        { 
            get 
            { 
                return itemList; 
            }
        }
    }
}
