using System.Windows;
using System.Windows.Controls;
using System.Linq;
using MarketAbuse.Sorts;

namespace MarketAbuse.Forms.Menus
{
    public class SortMenu : IMenu
    {
        public SortMenu()
        {
            SortFactory.Initialize();

            sortMenu.Header = "Sorts";

            foreach (var sort in SortFactory.Sorts.OrderBy(a=>a.Name))
            {
                MenuItem sortMenuItem = new MenuItem();
                sortMenuItem.Header = sort.Name;
                sortMenuItem.Click += (object sender, RoutedEventArgs e) =>
                {
                    InvokeSortEvent(sort);
                };

                sortMenu.Items.Add(sortMenuItem);
            }
        }

        public void AddToMenu(Menu menu)
        {
            menu.Items.Add(sortMenu);
        }

        public void SetActiveSort(string sortName)
        {
            foreach (var sort in SortFactory.Sorts)
            {
                if (sort.Name == sortName)
                {
                    InvokeSortEvent(sort);
                }
            }
        }

        private void InvokeSortEvent(AbstractSort sort)
        {
            OnSort?.Invoke(new SortEventArgs(sort));
        }

        MenuItem sortMenu = new MenuItem();

        public delegate void SortEventHandler(SortEventArgs args);
        public event SortEventHandler OnSort;
    }
}
