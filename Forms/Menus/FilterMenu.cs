using System.Windows;
using System.Windows.Controls;
using System.Linq;
using MarketAbuse.Filters;

namespace MarketAbuse.Forms.Menus
{
    public class FilterMenu : IMenu
    {
        public FilterMenu()
        {
            FilterFactory.Initialize();

            filterMenu.Header = "Filters";

            foreach (var filter in FilterFactory.Filters.OrderBy(a => a.Name))
            {
                MenuItem filterMenuItem = new MenuItem();
                filterMenuItem.Header = filter.Name;
                filterMenuItem.Click += (object sender, RoutedEventArgs e) =>
                {
                    InvokeFilterEvent(filter);
                };

                filterMenu.Items.Add(filterMenuItem);
            }
        }

        public void AddToMenu(Menu menu)
        {
            menu.Items.Add(filterMenu);
        }

        public void SetActiveFilter(string filterName)
        {
            foreach (var filter in FilterFactory.Filters)
            {
                if(filter.Name == filterName)
                {
                    InvokeFilterEvent(filter);
                }
            }
        }

        private void InvokeFilterEvent(AbstractFilter filter)
        {
            OnFilter?.Invoke(new FilterEventArgs(filter));
        }

        MenuItem filterMenu = new MenuItem();

        public delegate void FilterEventHandler(FilterEventArgs args);
        public event FilterEventHandler OnFilter;
    }
}
