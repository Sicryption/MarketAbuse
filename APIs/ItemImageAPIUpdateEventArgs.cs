using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    class ItemImageAPIUpdateEventArgs : EventArgs
    {

        private readonly ObservableCollection<OSRSItemImage> itemList;

        public ItemImageAPIUpdateEventArgs(ObservableCollection<OSRSItemImage> itemList)
        {
            this.itemList = itemList;
        }

        public ObservableCollection<OSRSItemImage> ItemList
        {
            get
            {
                return itemList;
            }
        }
    }
}
