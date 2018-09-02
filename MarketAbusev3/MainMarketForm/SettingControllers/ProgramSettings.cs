using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MainMarketForm
{
    public class ProgramSettings : SettingsForm
    {
        public TextBox moneyAvailableTextBox;
        public CheckBox badItemsCheckBox;
        public int moneyAvailable;
        public bool filterItems { get { return (bool)badItemsCheckBox.IsChecked; } }
        private bool hasReadInInformation = false;

        public ProgramSettings(MainWindow mw) : base(mw)
        {
            DockPanel dp = new DockPanel();

            TextBlock head = new TextBlock()
            {
                Text = "Money Available: ",
                FontSize = 16,
                FontFamily = new System.Windows.Media.FontFamily("Segoe UI Light"),
                Margin = new System.Windows.Thickness(5),
                Foreground = System.Windows.Media.Brushes.White
            };
            dp.Children.Add(head);

            moneyAvailableTextBox = new TextBox()
            {
                Width = 100,
                Text = "0",
                FontSize = 16,
                Margin = new Thickness(5),
                FontFamily = new System.Windows.Media.FontFamily("Segoe UI Light"),
                Name = "moneyAvailable"
            };
            moneyAvailableTextBox.PreviewTextInput += (s, e) =>
            {
                Regex regex = new Regex("^[0-9]+$"); //regex that matches disallowed text
                bool isAllNumbers = regex.IsMatch(e.Text);

                //not all numbers OR its more than 1 bilion worth of digits (10) 1000000000
                if (!isAllNumbers || moneyAvailableTextBox.Text.Length > 9)
                    e.Handled = true;
            };

            moneyAvailableTextBox.TextChanged += (s, e) => {
                SaveListData();

                if (moneyAvailableTextBox.Text == "")
                    moneyAvailableTextBox.Text = "0";
                else
                {
                    Int64 value;
                    bool success = Int64.TryParse(moneyAvailableTextBox.Text, out value);

                    if (success)
                    {
                        if (value > int.MaxValue)
                            value = int.MaxValue;

                        moneyAvailable = (int)value;
                        moneyAvailableTextBox.Text = ((int)value).ToString();
                        MW.listInNeedOfRefresh = true;
                    }
                    moneyAvailableTextBox.CaretIndex = moneyAvailableTextBox.Text.Length;
                }
            };
            dp.Children.Add(moneyAvailableTextBox);

            form.gridArea.Children.Add(dp);

            DockPanel dp2 = new DockPanel();
            badItemsCheckBox = new CheckBox
            {
                Foreground = System.Windows.Media.Brushes.White,
                Content = "Hide Bad Items",
                FontSize = 16,
                Margin = new Thickness(5),
                FontFamily = new System.Windows.Media.FontFamily("Segoe UI Light"),
                Name = "badItemsCheck"
            };
            badItemsCheckBox.Click += (s, e) => { SaveListData(); MW.listInNeedOfRefresh = true; };
            dp2.Children.Add(badItemsCheckBox);
            form.gridArea.Children.Add(dp2);

            LoadListData();
            MW.listInNeedOfRefresh = true;
        }

        public void LoadListData()
        {
            if (!File.Exists("Resources/Program.settings"))
                SaveListData(true);

            using (StreamReader sr = new StreamReader("Resources/Program.settings"))
            {
                while (!sr.EndOfStream)
                {
                    string data = sr.ReadLine();
                    string[] split = data.Split('|');

                    foreach (DockPanel dp in form.gridArea.Children)
                    {
                        foreach (CheckBox cb in dp.Children.Cast<UIElement>().Where(a => a.GetType() == typeof(CheckBox)))
                            if (cb.Name == split[0])
                                cb.IsChecked = bool.Parse(split[1]);
                        foreach (TextBox tb in dp.Children.Cast<UIElement>().Where(a => a.GetType() == typeof(TextBox)))
                            if (tb.Name == split[0])
                                tb.Text = split[1];
                    }
                }

                if (!hasReadInInformation)
                    hasReadInInformation = true;
            }
        }

        public void SaveListData(bool firstSave = false)
        {
            if (!hasReadInInformation && !firstSave)
                return;

            using (StreamWriter sw = new StreamWriter("Resources/Program.settings"))
            {
                foreach (DockPanel dp in form.gridArea.Children)
                {
                    foreach (CheckBox cb in dp.Children.Cast<UIElement>().Where(a => a.GetType() == typeof(CheckBox)))
                    {
                        if (firstSave && cb.Name == "badItemsCheck")
                            sw.WriteLine(cb.Name + "|" + "True");
                        else
                            sw.WriteLine(cb.Name + "|" + cb.IsChecked);
                    }

                    foreach (TextBox tb in dp.Children.Cast<UIElement>().Where(a => a.GetType() == typeof(TextBox)))
                    {
                        if (firstSave && tb.Name == "moneyAvailable")
                            sw.WriteLine(tb.Name + "|" + 0);
                        else
                            sw.WriteLine(tb.Name + "|" + tb.Text);
                    }
                }
            }
        }
    }
}
