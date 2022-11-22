using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    public class ItemTimeSeriesAPIUpdateEventArgs : EventArgs
    {
        private readonly ObservableCollection<OSRSItemTimeSeries> itemList;
        private readonly uint itemId;

        public ItemTimeSeriesAPIUpdateEventArgs(uint itemId, ObservableCollection<OSRSItemTimeSeries> itemList)
        {
            this.itemList = itemList;
            this.itemId = itemId;
        }

        public ObservableCollection<OSRSItemTimeSeries> ItemList
        { 
            get 
            { 
                return itemList; 
            }
        }

        public uint ItemId 
        { 
            get 
            { 
                return itemId; 
            } 
        }

    }
}
