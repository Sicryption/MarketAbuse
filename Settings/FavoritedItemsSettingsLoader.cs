using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.Settings
{
    public class FavoritedItemsSettingsLoader : IDisposable
    {
        public FavoritedItemsSettingsLoader(OSRSItemViewModelList viewModelList)
        {
            this.viewModelList = viewModelList;
            settings.loadFromFile();
        }

        public void applySettings()
        {
            foreach(var itemId in settings.FavoritedItems)
            {
                foreach(var item in viewModelList.getRawItemList())
                {
                    if(item.Information.Id == itemId)
                    {
                        item.IsFavorited = true;
                    }
                }
            }
        }

        public void ChangeFavoritedState(bool favorited, uint itemId)
        {
            if(favorited)
            {
                settings.FavoritedItems.Remove(itemId);
                settings.FavoritedItems.Add(itemId);
            }
            else
            {
                settings.FavoritedItems.Remove(itemId);
            }
        }

        public void Dispose()
        {
            settings.saveToFile();
        }

        OSRSItemViewModelList viewModelList;
        private FavoritedItemsSettings settings = new FavoritedItemsSettings();
    }
}
