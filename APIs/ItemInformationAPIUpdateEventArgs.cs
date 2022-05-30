using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    class ItemInformationAPIUpdateEventArgs : EventArgs
    {
        private readonly ObservableCollection<OSRSItemInformation> itemList;

        public ItemInformationAPIUpdateEventArgs(ObservableCollection<OSRSItemInformation> itemList)
        {
            this.itemList = itemList;
        }

        public ObservableCollection<OSRSItemInformation> ItemList
        { 
            get 
            { 
                return itemList; 
            }
        }
    }
}
