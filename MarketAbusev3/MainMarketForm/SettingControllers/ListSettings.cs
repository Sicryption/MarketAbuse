using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MainMarketForm
{
    public class ListSettings : SettingsForm
    {
        List<Tuple<string, double>> listHeaderSizes;
        
        public ListSettings(MainWindow mw) : base(mw)
        {
            form.Title.Text = "List Settings";


            List<Tuple<String, String>> options = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("toggleSellPrice", "Show Sell Price"),
                new Tuple<string, string>("toggleBuyPrice", "Show Buy Price"),

                new Tuple<string, string>("toggleSellQuantity", "Show Selling Quantity"),
                new Tuple<string, string>("toggleBuyQuantity", "Show Buying Quantity"),

                new Tuple<string, string>("toggleID", "Show Item ID"),
                new Tuple<string, string>("toggleMargin", "Show Item Margin"),

                new Tuple<string, string>("toggleShortHandName", "Show Short Hand"),
                new Tuple<string, string>("toggleIsMembers", "Show Members State")
            };

            for (int i = 0; i < options.Count / 2; i++)
            {
                DockPanel dp = new DockPanel();
                dp.Children.Add(CreateCheckBox(options[i * 2]));

                if (i * 2 + 1 <= options.Count)
                    dp.Children.Add(CreateCheckBox(options[i * 2 + 1]));

                form.gridArea.Children.Add(dp);
            }

            setColumnVisibility(true);
        }

        public void setColumnVisibility(bool loadCheckboxes = false)
        {
            if (loadCheckboxes)
                LoadListData();

            if(listHeaderSizes == null)
            {
                listHeaderSizes = new List<Tuple<string, double>>();

                foreach (GridViewColumn header in MW.itemGridView.Columns)
                    listHeaderSizes.Add(new Tuple<string, double>(header.ToString(), header.Width));
            }

            List<Tuple<GridViewColumn, string>> headers = new List<Tuple<GridViewColumn, string>>
            {
                new Tuple<GridViewColumn, string>(MW.sellPriceHeader, "toggleSellPrice"),
                new Tuple<GridViewColumn, string>(MW.buyPriceHeader, "toggleBuyPrice"),
                new Tuple<GridViewColumn, string>(MW.sellingQuantityHeader, "toggleSellQuantity"),
                new Tuple<GridViewColumn, string>(MW.buyingQuantityHeader, "toggleBuyQuantity"),
                new Tuple<GridViewColumn, string>(MW.IDHeader, "toggleID"),
                new Tuple<GridViewColumn, string>(MW.marginHeader, "toggleMargin"),
                new Tuple<GridViewColumn, string>(MW.shortHandNameHeader, "toggleShortHandName"),
                new Tuple<GridViewColumn, string>(MW.membersHeader, "toggleIsMembers")
            };

            foreach (DockPanel dp in form.gridArea.Children)
                foreach(CheckBox cb in dp.Children)
                {
                    var v = headers.FirstOrDefault(a => a.Item2 == cb.Name);

                    if (v != null)
                        v.Item1.Width = ((bool)cb.IsChecked) ? FindColumnWidth(v.Item1.Header.ToString()) : 0;
                }
        }

        public double FindColumnWidth(string columnText)
        {
            return listHeaderSizes.FirstOrDefault(a => a.Item1.Replace("System.Windows.Controls.GridViewColumn Header:", "") == columnText).Item2;
        }

        public void LoadListData()
        {
            if(!File.Exists("Resources/ListView.settings"))
                SaveListData(true);

            StreamReader sr = new StreamReader("Resources/ListView.settings");

            while(!sr.EndOfStream)
            {
                string data = sr.ReadLine();
                string[] split = data.Split('|');


                foreach (DockPanel dp in form.gridArea.Children)
                    foreach (CheckBox cb in dp.Children)
                        if (cb.Name == split[0])
                            cb.IsChecked = bool.Parse(split[1]);
            }

            sr.Dispose();
        }

        public void SaveListData(bool firstSave = false)
        {
            StreamWriter sw = new StreamWriter("Resources/ListView.settings");

            foreach (DockPanel dp in form.gridArea.Children)
                foreach (CheckBox cb in dp.Children)
                {
                    if (firstSave && cb.Name == "toggleMargin")
                        sw.WriteLine(cb.Name + "|" + "True");
                    else
                        sw.WriteLine(cb.Name + "|" + cb.IsChecked);
                }

            sw.Dispose();
        }

        public CheckBox CreateCheckBox(Tuple<string, string> data)
        {
            CheckBox cb = new CheckBox
            {
                Foreground = System.Windows.Media.Brushes.White,
                Name = data.Item1,
                Content = data.Item2,
                FontSize = 16,
                Margin = new System.Windows.Thickness(5),
                FontFamily = new System.Windows.Media.FontFamily("Segoe UI Light"),
                Width = 175
            };

            cb.Click += (s, e) => { SaveListData(); setColumnVisibility(); };

            return cb;
        }
    }
}
