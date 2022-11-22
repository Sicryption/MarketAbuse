using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

using MarketAbuse.APIs;
using MarketAbuse.OSRSObjects;
using MarketAbuse.Filters;
using MarketAbuse.Sorts;
using MarketAbuse.Settings;
using MarketAbuse.Forms.Menus;

namespace MarketAbuse
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            itemViewModelList = new OSRSItemViewModelList(new AlphabeticalSort(), new NoFilter());
            settingsLoader = new ApplicationSettingsLoader(this);

            FilterMenu.AddToMenu(Menu);
            FilterMenu.OnFilter += OnFilter;

            SortMenu.AddToMenu(Menu);
            SortMenu.OnSort += OnSort;

            Closed += OnMainWindowClosed;

            settingsLoader.applySettings();

            ItemListbox.DataContext = this;

            getItemInformation();
        }

        private void OnMainWindowClosed(object sender, EventArgs e)
        {
            settingsLoader.Dispose();
            favoritedItemsSettingsLoader.Dispose();
        }

        private void getItemInformation()
        {
            OSRSWikiItemInformationAPI wikiItemInformationAPI = new OSRSWikiItemInformationAPI();
            wikiItemInformationAPI.OnItemAPIUpdate += onItemInformationAPIComplete;
            wikiItemInformationAPI.run();
        }

        private void onItemInformationAPIComplete(object sender, ItemInformationAPIUpdateEventArgs e)
        {
            itemViewModelList.updateViewModelInformation(e.ItemList);

            getItemPrices();
            getItemAveragePrices();
            getItemImages(e.ItemList);

            favoritedItemsSettingsLoader = new FavoritedItemsSettingsLoader(itemViewModelList);
            favoritedItemsSettingsLoader.applySettings();
        }

        private void OnItemImageAPIComplete(object sender, ItemImageAPIUpdateEventArgs e)
        {
            itemViewModelList.updateViewModelImages(e.ItemList);
        }

        private void getItemPrices()
        {
            wikiItemPricesAPI = new OSRSWikiItemPriceAPI();
            wikiItemPricesAPI.OnItemAPIUpdate += OnItemPricesAPIUpdate;
            wikiItemPricesAPI.run();
        }

        private void getItemAveragePrices()
        {
            wikiItemAveragePricesAPI = new OSRSWikiItemAveragePriceAPI(OSRSWikiItemAveragePriceAPI.TimeframeInterval.OneDay);
            wikiItemAveragePricesAPI.OnItemAPIUpdate += OnItemAveragePricesAPIUpdate;
            wikiItemAveragePricesAPI.run();
        }
        
        private void getItemImages(ObservableCollection<OSRSItemInformation> itemInformationList)
        {
            OSRSWikiItemImageAPI wikiItemImageAPI = new OSRSWikiItemImageAPI();
            wikiItemImageAPI.OnItemAPIUpdate += OnItemImageAPIComplete;
            wikiItemImageAPI.run(itemInformationList);
        }

        private void OnItemPricesAPIUpdate(object sender, ItemPriceAPIUpdateEventArgs e)
        {
            itemViewModelList.updateViewModelPrices(e.ItemList);
        }

        private void OnItemAveragePricesAPIUpdate(object sender, ItemAveragePriceAPIUpdateEventArgs e)
        {
            itemViewModelList.updateViewModelAveragePrices(e.ItemList);
        }

        private void OnSort(SortEventArgs e)
        {
            itemViewModelList.setSortingMethod(e.Sort);
            settingsLoader.setSortOption(e.Sort.Name);
        }

        private void OnFilter(FilterEventArgs e)
        {
            itemViewModelList.setFilterMethod(e.Filter);
            settingsLoader.setFilterOption(e.Filter.Name);
        }

        private void FavoriteItemClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = (OSRSItemViewModel)((Image)sender).Tag;

            if(item != null)
            {
                itemViewModelList.toggleFavoriteState(item.Information.Id);
                favoritedItemsSettingsLoader.ChangeFavoritedState(item.IsFavorited, item.Information.Id);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = ((TextBox)sender).Text;
            if (searchText == "Search")
            {
                return;
            }

            itemViewModelList.setSearchFilterText(searchText);
        }

        private void ShowLongTermGraphClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = (OSRSItemViewModel)ItemListbox.SelectedItem;

            if(viewModel == null)
            {
                return;
            }

            OSRSWikiItemTimeSeriesAPI timeSeriesAPI = new OSRSWikiItemTimeSeriesAPI(OSRSWikiItemTimeSeriesAPI.SupportedDurations.OneDay, viewModel.Information.Id);
            timeSeriesAPI.OnItemAPIUpdate += showTimeSeriesGraph;
            timeSeriesAPI.run();
        }

        private void ShowShortTermGraphClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = (OSRSItemViewModel)ItemListbox.SelectedItem;

            if (viewModel == null)
            {
                return;
            }

            OSRSWikiItemTimeSeriesAPI timeSeriesAPI = new OSRSWikiItemTimeSeriesAPI(OSRSWikiItemTimeSeriesAPI.SupportedDurations.OneHour, viewModel.Information.Id);
            timeSeriesAPI.OnItemAPIUpdate += showTimeSeriesGraph;
            timeSeriesAPI.run();
        }

        private void showTimeSeriesGraph(object sender, ItemTimeSeriesAPIUpdateEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                TimeSeriesDisplay timeSeriesDisplay = new TimeSeriesDisplay(itemViewModelList.getViewModelById(e.ItemId), e.ItemList);

                timeSeriesDisplay.Show();
            }));
        }

        public static OSRSItemViewModelList itemViewModelList;
        public static OSRSItemViewModelList ItemViewModelList
        {
            get { return itemViewModelList; }
            set { itemViewModelList = value; }
        }

        private OSRSWikiItemPriceAPI wikiItemPricesAPI;
        private OSRSWikiItemAveragePriceAPI wikiItemAveragePricesAPI;

        private ApplicationSettingsLoader settingsLoader;
        private FavoritedItemsSettingsLoader favoritedItemsSettingsLoader;
        public FilterMenu FilterMenu = new FilterMenu();
        public SortMenu SortMenu = new SortMenu();
    }
}
