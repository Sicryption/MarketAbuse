using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

using MarketAbuse.Sorts;
using MarketAbuse.Filters;

namespace MarketAbuse.OSRSObjects
{
    public class OSRSItemViewModelList : INotifyPropertyChanged
    {
        public OSRSItemViewModelList(AbstractSort sortingMethod, AbstractFilter filterMethod)
        {
            this.sortingMethod = sortingMethod;
            this.filterMethod = filterMethod;
            itemList = new ObservableCollection<OSRSItemViewModel>();
        }

        public void setSortingMethod(AbstractSort sortingMethod)
        {
            this.sortingMethod = sortingMethod;
            forceRefresh();
        }

        public void setFilterMethod(AbstractFilter filterMethod)
        {
            this.filterMethod = filterMethod;
            forceRefresh();
        }

        public void toggleFavoriteState(uint id)
        {
            var viewModel = getViewModelById(id);

            if(viewModel != null)
            {
                viewModel.IsFavorited = !viewModel.IsFavorited;
            }

            forceRefresh();
        }
        
        public void setSearchFilterText(string searchTerm)
        {
            searchFilter.setSearchTerm(searchTerm);
            forceRefresh();
        }

        public void forceRefresh()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemList"));
        }

        public OSRSItemViewModel getViewModelById(uint id)
        {
            foreach(var item in itemList)
            {
                if(item.Information.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public void updateViewModelInformation(ObservableCollection<OSRSItemInformation> itemList)
        {
            this.itemList = new ObservableCollection<OSRSItemViewModel>();
            foreach (var item in itemList)
            {
                OSRSItemViewModel viewModel = new OSRSItemViewModel();
                viewModel.Information = item;
                this.itemList.Add(viewModel);
            }

            forceRefresh();
        }

        public void updateViewModelPrices(ObservableCollection<OSRSItemPrices> prices)
        {
            foreach (var existingItem in itemList)
            {
                foreach (var item in prices)
                {
                    if (existingItem.Information.Id == item.Id)
                    {
                        existingItem.Prices = item;
                    }
                }
            }

            forceRefresh();
        }

        public void updateViewModelAveragePrices(ObservableCollection<OSRSItemAveragePrices> prices)
        {
            foreach (var existingItem in itemList)
            {
                foreach (var item in prices)
                {
                    if (existingItem.Information.Id == item.Id)
                    {
                        existingItem.AveragePrices = item;
                    }
                }
            }

            forceRefresh();
        }

        public void updateViewModelImages(ObservableCollection<OSRSItemImage> images)
        {
            foreach (var existingItem in itemList)
            {
                foreach (var item in images)
                {
                    if (item != null && existingItem.Information.Name == item.itemName)
                    {
                        existingItem.Image = item;
                    }
                }
            }

            forceRefresh();
        }

        private ObservableCollection<OSRSItemViewModel> getSortedItemList()
        {
            var searchFiltered = searchFilter.filter(itemList);
            var filtered = filterMethod.filter(searchFiltered);
            var sorted = sortingMethod.sort(filtered);

            return new ObservableCollection<OSRSItemViewModel>(sorted);
        }

        private AbstractSort sortingMethod;
        private AbstractFilter filterMethod;
        private SearchFilter searchFilter = new SearchFilter();
        private ObservableCollection<OSRSItemViewModel> itemList;

        public ObservableCollection<OSRSItemViewModel> getRawItemList()
        {
            return itemList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<OSRSItemViewModel> ItemList
        {
            get { return getSortedItemList(); }
            set { itemList = value; }
        }
    }
}
