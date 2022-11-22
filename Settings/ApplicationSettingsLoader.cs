using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MarketAbuse.Settings
{
    public class ApplicationSettingsLoader : IDisposable
    {
        public ApplicationSettingsLoader(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            applicationSettings.loadFromFile();
        }

        public void setFilterOption(string filterOption)
        {
            applicationSettings.FilterOption = filterOption;
        }

        public void setSortOption(string sortOption)
        {
            applicationSettings.SortOption = sortOption;
        }

        public void applySettings()
        {
            applyFilter();
            applySort();
        }

        private void applyFilter()
        {
            mainWindow.FilterMenu.SetActiveFilter(applicationSettings.FilterOption);
        }

        private void applySort()
        {
            mainWindow.SortMenu.SetActiveSort(applicationSettings.SortOption);
        }

        public void Dispose()
        {
            applicationSettings.saveToFile();
        }

        private MainWindow mainWindow;
        private ApplicationSettings applicationSettings = new ApplicationSettings();
    }
}
