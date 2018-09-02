using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Data;

namespace MainMarketForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region DLL Imports
        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }
            return (IntPtr)0;
        }

        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
            if (monitor != IntPtr.Zero)
            {
                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }
            Marshal.StructureToPtr(mmi, lParam, true);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>x coordinate of point.</summary>
            public int x;
            /// <summary>y coordinate of point.</summary>
            public int y;
            /// <summary>Construct a point of coordinates (x,y).</summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            public RECT rcMonitor = new RECT();
            public RECT rcWork = new RECT();
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public static readonly RECT Empty = new RECT();
            public int Width { get { return Math.Abs(right - left); } }
            public int Height { get { return bottom - top; } }
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
            public RECT(RECT rcSrc)
            {
                left = rcSrc.left;
                top = rcSrc.top;
                right = rcSrc.right;
                bottom = rcSrc.bottom;
            }
            public bool IsEmpty { get { return left >= right || top >= bottom; } }
            public override string ToString()
            {
                if (this == Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }
            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode() => left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2) { return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom); }
            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2) { return !(rect1 == rect2); }
        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
        #endregion

        DateTime lastRefreshed = DateTime.Now;
        DateTime lastUpdated = DateTime.Now;
        private int secondsPerRefresh = 30;
        private Thread ListRefreshThread;
        private StackPanel selectedItemsPanel;
        private List<Item> SelectedItemsList = new List<Item>();
        
        public bool listInNeedOfRefresh = true;
        
        public ItemHandler IH;
        public SplashScreen SS;
        public ListSettings LS;
        public ProgramSettings PS;

        public List<Item> Items { get { if (IH != null) return IH.Items; else return null; } }

        public MainWindow(SplashScreen ss, ItemHandler ih)
        {
            SS = ss;
            IH = ih;
            IH.MW = this;

            InitializeComponent();
            LS = new ListSettings(this);
            PS = new ProgramSettings(this);
            SourceInitialized += (s, e) =>
            {
                IntPtr handle = (new WindowInteropHelper(this)).Handle;
                HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowProc));
            };
            MinimizeButton.Click += (s, e) => WindowState = WindowState.Minimized;
            MaximizeButton.Click += (s, e) => WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            CloseButton.Click += (s, e) => Environment.Exit(0);
            SortSettings.Click += (s, e) => LS.Show();
            SortMethod.SelectionChanged += (s, e) => listInNeedOfRefresh = true;
            ProgramSettings.Click += (s, e) => PS.Show();
            SortDirection.Click += (s, e) =>
            {
                if(sortPicture.Tag.ToString() == "up")
                {
                    sortPicture.Tag = "down";
                    sortPicture.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/DownArrow.png"));
                }
                else if (sortPicture.Tag.ToString() == "down")
                {
                    sortPicture.Tag = "up";
                    sortPicture.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/UpArrow.png"));
                }
                listInNeedOfRefresh = true;
            };

            SearchBox.TextChanged += (s, e) => listInNeedOfRefresh = true;
            List.SelectionChanged += ListItemChange;

            ScrollViewer sv = new ScrollViewer();
            MainGrid.Children.Add(sv);
            sv.SetValue(Grid.RowProperty, 1);
            sv.SetValue(Grid.ColumnProperty, 2);
            sv.SetValue(Grid.RowSpanProperty, 3);
            sv.Margin = new Thickness(5);
            sv.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            selectedItemsPanel = new StackPanel();
            sv.Content = selectedItemsPanel;
            
            DataContext = this;
            ListRefreshThread = new Thread(ListRefresh);
            ListRefreshThread.Start();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
            
            //give sort type the types.
            string[] sortTypes = new string[] { "Highest Margin", "Fast Flips", "Recommended", "High Quantity", "Favorites", "Alphabetize", "By ID" };
            foreach (string s in sortTypes)
                SortMethod.Items.Add(s);
            SortMethod.SelectedIndex = 0;
        }

        private void AddSelectedItemToList(Item i)
        {
            //border around item grid
            Border groupBorder = new Border
            {
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF666666")),
                BorderThickness = new Thickness(1),
                Tag = i
            };
            selectedItemsPanel.Children.Add(groupBorder);

            //grid storing all item information
            Grid singleItemGrid = new Grid
            {
                Width = 300
            };
            singleItemGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            singleItemGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            singleItemGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            singleItemGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
            singleItemGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
            groupBorder.Child = singleItemGrid;

            Grid PictureAndAdvancedGrid = new Grid();
            PictureAndAdvancedGrid.SetValue(Grid.ColumnProperty, 1);
            PictureAndAdvancedGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            PictureAndAdvancedGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            PictureAndAdvancedGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
            PictureAndAdvancedGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            PictureAndAdvancedGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });

            //image of item
            Image itemPicture = new Image
            {
                Width = 40,
                Height = 40
            };
            itemPicture.SetValue(Grid.RowProperty, 0);
            itemPicture.SetValue(Grid.ColumnProperty, 1);

            Button itemAdvancedOptionsButton = new Button()
            {
                Width = 32,
                Height = 32,
                Style = FindResource("ClickableButton") as Style
            };
            Image itemAdvancedOptionsImage = new Image() { Tag = "Closed" };
            itemAdvancedOptionsButton.Content = itemAdvancedOptionsImage;
            itemAdvancedOptionsButton.SetValue(Grid.RowProperty, 2);
            itemAdvancedOptionsButton.SetValue(Grid.ColumnProperty, 1);

            PictureAndAdvancedGrid.Children.Add(itemPicture);
            PictureAndAdvancedGrid.Children.Add(itemAdvancedOptionsButton);

            TextBlock[] textBlocks = new TextBlock[]
            {
                CreateTextBlock("Item Name: " + i.name, i),
                CreateTextBlock("ID: " + i.id.ToString("N0"), i, true),
                CreateTextBlock("Members Only: " + (i.members?"Yes":"No"), i, true),
                CreateTextBlock("Buy Price: ", i, "buyPriceFormatted"),
                CreateTextBlock("Sell Price: ", i, "sellPriceFormatted"),
                CreateTextBlock("Margin: ", i, "marginFormatted"),
                CreateTextBlock("Buy Quantity: ", i, "buyQuantity"),
                CreateTextBlock("Sell Quantity: ", i, "sellQuantity")
            };

            itemAdvancedOptionsButton.Click += (s, e) =>
            {
                double size = 0;
                if (itemAdvancedOptionsImage.Tag.ToString() == "Closed")
                {
                    size = double.NaN;
                    itemAdvancedOptionsImage.Tag = "Open";
                    itemAdvancedOptionsImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/ExpandUp.png"));
                }
                else
                {
                    size = 0;
                    itemAdvancedOptionsImage.Tag = "Closed";
                    itemAdvancedOptionsImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/ExpandDown.png"));
                }
                foreach (TextBlock tb in textBlocks)
                    if (tb.Tag != null && tb.Tag.ToString() == "adv")
                        tb.Height = size;
            };

            //the list which has all text stored inside of it
            StackPanel selectedItemDataListing = new StackPanel();
            selectedItemDataListing.Margin = new Thickness(5);

            //add all previously made textboxes
            foreach (var tb in textBlocks)
                selectedItemDataListing.Children.Add(tb);

            singleItemGrid.Children.Add(selectedItemDataListing);
            singleItemGrid.Children.Add(PictureAndAdvancedGrid);

            itemPicture.Source = new BitmapImage(new Uri(i.imageDirectory));
            itemAdvancedOptionsImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/ExpandDown.png"));
        }
        
        private TextBlock CreateTextBlock(string defaultText, Item I, bool isAdvanced = false)
        {
            TextBlock tb = new TextBlock() { Text = defaultText};
            
            if (isAdvanced)
            {
                tb.Tag = "adv";
                tb.Height = 0;
            }

            return tb;
        }
        private TextBlock CreateTextBlock(string defaultText, Item I, string BindingText, bool isAdvanced = false)
        {
            TextBlock tb = new TextBlock() { Text = defaultText };
            int index = IH.Items.IndexOf(IH.Items.FirstOrDefault(a => a.id == I.id));
            tb.SetBinding(TextBlock.TextProperty, new Binding() { Source = IH.Items[index], Path = new PropertyPath(BindingText), StringFormat = defaultText + " {0:N0}", UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged, Mode=BindingMode.TwoWay
            });

            if (isAdvanced)
            {
                tb.Tag = "adv";
                tb.Height = 0;
            }

            return tb;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer dt = sender as DispatcherTimer;

            TimeSpan timeSinceRefresh = DateTime.Now - lastRefreshed;
            TimeSpan timeSinceUpdate = DateTime.Now - lastUpdated;

            RefreshLabel.Text = "Last Refreshed: " + timeSinceRefresh.Seconds + " second(s) ago.";
            

            if (SS.IHThread != null && !SS.IHThread.IsAlive && timeSinceRefresh.Seconds > 1)
            {
                if (timeSinceUpdate.Seconds >= secondsPerRefresh)
                {
                    lastUpdated = DateTime.Now;
                    SS.IHThread = new Thread(IH.RefreshItemList);
                    SS.IHThread.Start();
                }
            }
        }

        private void ListItemChange(object sender, EventArgs e)
        {
            ListView list = sender as ListView;
            List<Item> selectedItems = list.SelectedItems.Cast<Item>().ToList();

            if(selectedItems != SelectedItemsList)
            {
                List<Item> removedItems = findRemovedItems(SelectedItemsList, selectedItems),
                    addedItems = findAddedItems(SelectedItemsList, selectedItems);

                foreach (Item i in removedItems)
                    RemoveSelectedItemFromList(i);

                foreach (Item i in addedItems)
                    AddSelectedItemToList(i);

                SelectedItemsList = selectedItems;
            }
        }

        private void RemoveSelectedItemFromList(Item i)
        {
            List<UIElement> toBeRemoved = new List<UIElement>();

            foreach(UIElement child in selectedItemsPanel.Children)
            {
                Border b = (Border)child;
                if (b != null && b.Tag == i)
                    toBeRemoved.Add(b);
            }
            foreach(UIElement e in toBeRemoved)
                selectedItemsPanel.Children.Remove(e);
        }

        private List<Item> findRemovedItems(List<Item> one, List<Item> two)
        {
            List<Item> list = new List<Item>();

            foreach (Item i in one)
                if (!two.Contains(i))
                    list.Add(i);

            return list;
        }

        private List<Item> findAddedItems(List<Item> one, List<Item> two)
        {
            List<Item> list = new List<Item>();

            foreach (Item i in two)
                if (!one.Contains(i))
                    list.Add(i);

            return list;
        }

        private List<Item> SortList(List<Item> list, string sortType, bool direction)
        {
            switch (sortType)
            {
                case "Highest Margin":
                    list = (direction?list.OrderByDescending(a => a.marginFormatted): list.OrderBy(a => a.marginFormatted)).ToList();
                    break;
                case "Fast Flips":
                    list = (direction ? list.Where(a=>a.buyQuantity > 50 && a.sellQuantity > 50).OrderByDescending(a => a.marginFormatted) : list.Where(a => a.buyQuantity > 50 && a.sellQuantity > 50).OrderBy(a => a.marginFormatted)).ToList();
                    break;
                case "Recommended":
                    list = (direction ? list.Where(a => a.buyQuantity > 10 && a.sellQuantity > 10).OrderByDescending(a => a.marginFormatted) : list.Where(a => a.buyQuantity > 10 && a.sellQuantity > 10).OrderBy(a => a.marginFormatted)).ToList();
                    break;
                case "Favorites":
                    break;
                case "High Quantity":
                    list = (direction ? list.Where(a=> a.buyQuantity > 200 && a.sellQuantity > 200).OrderByDescending(a => a.marginFormatted) : list.Where(a => a.buyQuantity > 200 && a.sellQuantity > 200).OrderBy(a => a.marginFormatted)).ToList();
                    break;
                case "By ID":
                    list = (direction ? list.OrderBy(a => a.id) : list.OrderByDescending(a => a.id)).ToList();
                    break;
            }

            list = PS.moneyAvailable == 0 ? list : list.Where(a =>a.buyPriceFormatted <= PS.moneyAvailable).ToList();

            return (SearchBox.Text == "Search" || SearchBox.Text == "") ? list : list.Where(a => a.name.ToLower().Contains(SearchBox.Text.ToLower()) || a.shortHandName.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
        }

        private void ListRefresh()
        {
            while (true)
            {
                if(listInNeedOfRefresh && IH.Items.Count != 0)
                {
                    //it has to not currently be updating and have waited at least 30 seconds to continue
                    this.Dispatcher.Invoke(() =>
                    {
                        List<Item> itemList = SortList(IH.Items, SortMethod.SelectedItem.ToString(), sortPicture.Tag.ToString() == "up");
                        List<Item> selectedItems = new List<Item>();
                        foreach (Item i in List.SelectedItems.Cast<Item>())
                            selectedItems.Add(i);
                        
                        List.ItemsSource = PS.filterItems ? itemList.Where(a => a.shouldBeVisible) : itemList;

                        if (selectedItems.Count > 0)
                            for(int i = 0; i < selectedItems.Count; i++)
                            {
                                int selectedItemIndex = List.Items.IndexOf(selectedItems[i]);

                                if(selectedItemIndex != -1)
                                    List.SelectedItems.Add(List.Items[selectedItemIndex]);
                            }
                    });

                    lastRefreshed = DateTime.Now;
                    listInNeedOfRefresh = false;
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

/*
Item Details List on Right MUST be scrollable.
    Item Advanced Details must be shrinkable from the main view box.
    List must allow multiple item selections

List View
    Sort Method Beneath List View
    Sort Direction Becomes Two Arrows
    Sort Direction Beneath List View
    Setting Button on far right beneath list view
    Filter Bad Flips becomes a setting within the setting menu

Tabs
    Merch
    Flip
    EXP/GP
    All tabs on far left with icons to activate

Search Bar Ideas
    Search Bar above the list
    Search Bar appear from magniying glass activatable from above the item pictures

GIVE PROGRAM AN ICON BEFORE I SHOOT MYSELF

Brought to you by Caleb

Styles
    Grey on Sort Boxes/Textboxes?
    Grey scrollbar?
    Blue Glow around comboboxes
    Blue Line around list when selected with arrow keys
*/