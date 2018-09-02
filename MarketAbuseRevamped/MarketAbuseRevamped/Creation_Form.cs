using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MarketAbuseRevamped
{
    internal class Creation_Form : Office2007Form
    {
        public List<Creation> MasterList = new List<Creation>();

        public List<ShopItem> ShopItems = new List<ShopItem>();

        private MainForm main;

        public Creation.CreationFormType formType = Creation.CreationFormType.Normal;
        
        private IContainer components = null;

        public ListBox itemList;

        private TableLayoutPanel TablePanel;

        public ComboBox sortBox;

        public Creation_Form(string name, List<Creation> creations, MainForm form)
        {
            CreationLists.Initialize();
            InitializeComponent();
            Text = name;
            MasterList = creations;
            main = form;
            itemList.MouseDown += new MouseEventHandler(main.ShowFavoritesMenu);
            foreach (Creation current in MasterList)
            {
                itemList.Items.Add(current);
            }
            sortBox_SelectedIndexChanged(sortBox, null);
            FormBorderStyle = main.FormBorderStyle;
        }

        public Creation_Form(string name, Creation.CreationFormType type, MainForm form)
        {
            InitializeComponent();
            formType = type;
            Text = name;
            main = form;
            foreach (Item current in MainForm.AllItems)
            {
                bool flag = type == Creation.CreationFormType.GereralStore;
                if (flag)
                {
                    MasterList.Add(new Creation(new List<Item>
                    {
                        current
                    }, new List<Item>
                    {
                        CreationLists.GI("Coins", current.generalStore)
                    }, type));
                }
                else
                {
                    bool flag2 = type == Creation.CreationFormType.HighAlch;
                    if (flag2)
                    {
                        MasterList.Add(new Creation(new List<Item>
                        {
                            current,
                            CreationLists.GI("Nature rune", 1)
                        }, new List<Item>
                        {
                            CreationLists.GI("Coins", current.highAlch)
                        }, type));
                    }
                    else
                    {
                        bool flag3 = type == Creation.CreationFormType.LowAlch;
                        if (flag3)
                        {
                            MasterList.Add(new Creation(new List<Item>
                            {
                                current,
                                CreationLists.GI("Nature rune", 1)
                            }, new List<Item>
                            {
                                CreationLists.GI("Coins", current.lowAlch)
                            }, type));
                        }
                        else
                        {
                            bool flag4 = type == Creation.CreationFormType.KaramjaStore;
                            if (flag4)
                            {
                                MasterList.Add(new Creation(new List<Item>
                                {
                                    current
                                }, new List<Item>
                                {
                                    CreationLists.GI("Coins", current.karamjaStore)
                                }, type));
                            }
                        }
                    }
                }
            }
            sortBox_SelectedIndexChanged(sortBox, null);
        }

        public Creation_Form(string name, List<Shop> s, MainForm form)
        {
            InitializeComponent();
            ShopList.Initialize();
            Text = name;
            main = form;
            formType = Creation.CreationFormType.Shop;
            foreach (Shop current in s)
            {
                ShopItems.AddRange(current.Items);
            }
            itemList.Items.AddRange(ShopItems.ToArray());
            sortBox.Items.Clear();
            sortBox.Items.AddRange(new string[]
            {
                "Alphabetize",
                "Highest Margin"
            });
            sortBox_SelectedIndexChanged(sortBox, null);
        }

        public void itemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemList.SelectedItem != null)
            {
                if (formType == Creation.CreationFormType.Shop)
                    LoadShopItem((ShopItem)itemList.SelectedItem);
                else
                    LoadCreation((Creation)itemList.SelectedItem, 0);
            }
        }

        public void ReloadCreation()
        {
            if (!(itemList.SelectedItem == null || TablePanel.Controls == null))
            {
                foreach (Control control in TablePanel.Controls)
                {
                    if (control.Name.Contains("BuyPrice"))
                    {
                        Item item = (Item)control.Tag;
                        int num = (sortBox.Text == "Insta-buy" || sortBox.Text == "Insta-transaction") ? item.sellPrice : item.BuyPrice;
                        string text = (sortBox.Text == "Insta-buy" || sortBox.Text == "Insta-transaction") ? "Sell Price: " : "Buy Price: ";
                        text += (num * item.quantity).ToString("N0");
                        text += ((item.quantity == 1) ? "" : (" (" + num.ToString("N0") + " each)"));
                        control.Text = text;
                    }
                    else if (control.Name.Contains("SellPrice"))
                    {
                        Item item2 = (Item)control.Tag;
                        int num2 = (sortBox.Text == "Insta-sell" || sortBox.Text == "Insta-transaction") ? item2.BuyPrice : item2.sellPrice;
                        string text2 = (sortBox.Text == "Insta-buy" || sortBox.Text == "Insta-transaction") ? "Buy Price: " : "Sell Price: ";
                        text2 += (num2 * item2.quantity).ToString("N0");
                        text2 += ((item2.quantity == 1) ? "" : (" (" + num2.ToString("N0") + " each)"));
                        control.Text = text2;
                    }
                    else if (control.Name.Contains("Margin"))
                    {
                        int num3;
                        if (formType == Creation.CreationFormType.Shop)
                        {
                            ShopItem shopItem = (ShopItem)itemList.SelectedItem;
                            num3 = shopItem.margin();
                        }
                        else
                        {
                            Creation creation = (Creation)itemList.SelectedItem;
                            if (sortBox.Text == "Insta-buy")
                                num3 = creation.instaBuyMargin();
                            else if (sortBox.Text == "Insta-sell")
                                num3 = creation.instaSellMargin();
                            else if (sortBox.Text == "Insta-transaction")
                                num3 = creation.instaTransactionMargin();
                            else
                                num3 = creation.margin();
                        }
                        control.Text = "Profit: " + num3.ToString("N0");
                        control.ForeColor = ((num3 >= 0) ? Color.Green : ((num3 == 0) ? SystemColors.Control : Color.Red));
                    }
                }
            }
        }

        private void LoadShopItem(ShopItem si)
        {
            Creation creation = ShopItemToCreation(si);
            TablePanel.Controls.Clear();
            TablePanel.ColumnCount = 2;
            TablePanel.RowCount = creation.Input.Count * 2 + creation.Output.Count * 2 + 2;
            TablePanel.Size = new Size(254, TablePanel.RowCount * 16);

            if (formType == Creation.CreationFormType.Shop 
                && TablePanel.Controls.Cast<Control>().FirstOrDefault(a => a.Name == "storeName") != null)
            {
                Item item = creation.Input[0];
                item.quantity = si.Cost;
                Label label = new Label
                {
                    Name = "storeName",
                    Text = "Store Name: " + ShopList.GetShop(si).Name,
                    AutoSize = true,
                    Tag = ShopList.GetShop(si)
                };
                label.Click += new EventHandler(TableItemSelected);
                TablePanel.Controls.Add(label);
                TablePanel.SetColumnSpan(label, 2);
            }
            LoadCreation(creation, 1);
        }

        private void LoadCreation(Creation c, int row = 0)
        {
            if (formType != Creation.CreationFormType.Shop)
            {
                TablePanel.Controls.Clear();
                TablePanel.ColumnCount = 2;
                TablePanel.RowCount = c.Input.Count * 2 + c.Output.Count * 2 + 1;
                TablePanel.Size = new Size(254, TablePanel.RowCount * 16);
            }
            foreach (Item current in c.Input)
            {
                string text = "Name: " + current.name;
                text += ((current.quantity == 1) ? "" : (" x" + current.quantity));
                Label label = new Label
                {
                    Text = text,
                    AutoSize = true,
                    Tag = current,
                    Name = "Name" + current.name
                };
                label.Click += new EventHandler(TableItemSelected);
                TablePanel.Controls.Add(label, 0, row);
                PictureBox pictureBox = new PictureBox();
                //pictureBox.Load("http://cdn.rsbuddy.com/items/" + current.id + ".png");
                pictureBox.Click += new EventHandler(TableItemSelected);
                pictureBox.Tag = current;
                pictureBox.Image = null;
                TablePanel.Controls.Add(pictureBox, 1, row);
                TablePanel.SetRowSpan(pictureBox, 2);
                int num = row;
                row = num + 1;
                int num2 = (sortBox.Text == "Insta-buy" || sortBox.Text == "Insta-transaction") ? current.sellPrice : current.BuyPrice;
                string str = (sortBox.Text == "Insta-buy" || sortBox.Text == "Insta-transaction") ? "Sell Price: " : "Buy Price: ";
                text = str + (num2 * current.quantity).ToString("N0");
                text += ((current.quantity == 1) ? "" : (" (" + num2.ToString("N0") + " each)"));
                Label label2 = new Label
                {
                    Text = text,
                    AutoSize = true,
                    Tag = current,
                    Name = "BuyPrice" + current.name
                };
                label2.Click += new EventHandler(TableItemSelected);
                TablePanel.Controls.Add(label2, 0, row);
                num = row;
                row = num + 1;
            }
            foreach (Item current2 in c.Output)
            {
                string text2 = "Name: " + current2.name;
                text2 += ((current2.quantity == 1) ? "" : (" x" + current2.quantity));
                Label label3 = new Label
                {
                    Text = text2,
                    AutoSize = true,
                    Tag = current2,
                    Name = "Name" + current2.name
                };
                label3.Click += new EventHandler(TableItemSelected);
                TablePanel.Controls.Add(label3, 0, row);
                PictureBox pictureBox2 = new PictureBox();
                //pictureBox2.Load("http://cdn.rsbuddy.com/items/" + current2.id + ".png");
                pictureBox2.Click += new EventHandler(TableItemSelected);
                TablePanel.Controls.Add(pictureBox2, 1, row);
                pictureBox2.Tag = current2;
                TablePanel.SetRowSpan(pictureBox2, 2);
                int num = row;
                row = num + 1;
                int num3 = (sortBox.Text == "Insta-sell" || sortBox.Text == "Insta-transaction") ? current2.BuyPrice : current2.sellPrice;
                string str2 = (sortBox.Text == "Insta-buy" || sortBox.Text == "Insta-transaction") ? "Buy Price: " : "Sell Price: ";
                text2 = str2 + (num3 * current2.quantity).ToString("N0");
                text2 += ((current2.quantity == 1) ? "" : (" (" + num3.ToString("N0") + " each)"));
                Label label4 = new Label
                {
                    Text = text2,
                    AutoSize = true,
                    Tag = current2,
                    Name = "SellPrice" + current2.name
                };
                label4.Click += new EventHandler(TableItemSelected);
                TablePanel.Controls.Add(label4, 0, row);
                num = row;
                row = num + 1;
            }
            int num4;
            if (sortBox.Text == "Insta-buy")
                num4 = c.instaBuyMargin();
            else if (sortBox.Text == "Insta-sell")
                num4 = c.instaSellMargin();
            else if (sortBox.Text == "Insta-transaction")
                num4 = c.instaTransactionMargin();
            else
                num4 = c.margin();

            Label control = new Label
            {
                Text = "Profit: " + num4.ToString("N0"),
                AutoSize = true,
                Name = "Margin",
                ForeColor = ((num4 >= 0) ? Color.Green : ((num4 == 0) ? SystemColors.Control : Color.Red))
            };
            TablePanel.Controls.Add(control, 0, row);
        }

        public bool ValidityCheck(Creation c)
        {
            foreach (Item current in c.Input)
                if (current.BuyPrice == 0)
                    return false;
            foreach (Item current2 in c.Output)
                if (current2.sellPrice == 0)
                    return false;

            return true;
        }

        public bool ValidityCheck(ShopItem c)
        {
            return !(c.Item.sellPrice == 0 || c.Quantity == 0);
        }

        public Creation ShopItemToCreation(ShopItem si)
        {
            Item item = MainForm.GetItem(995);
            item.quantity = si.Cost;
            return new Creation(new List<Item> { item }, new List<Item> { si.Item });
        }

        public void sortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Creation> list = new List<Creation>();
            List<ShopItem> list2 = new List<ShopItem>();
            string text = sortBox.Text;
            if (text == "Insta-transaction")
                list = MasterList.Where(a => ValidityCheck(a) && main.CheckAgainstSettings(a))
                    .OrderByDescending(a => a.instaTransactionMargin()).ToList();
            else if (text == "Insta-sell")
                list = MasterList.Where(a => ValidityCheck(a) && main.CheckAgainstSettings(a))
                    .OrderByDescending(a => a.instaSellMargin()).ToList();
            else if (text == "Insta-buy")
                list = MasterList.Where(a => ValidityCheck(a) && main.CheckAgainstSettings(a))
                    .OrderByDescending(a => a.instaBuyMargin()).ToList();
            else if (text == "Alphabetize")
            {
                if (formType == Creation.CreationFormType.Shop)
                    list2 = ShopItems.Where(a => ValidityCheck(a) && main.CheckAgainstSettings(a))
                        .OrderBy(a => a.Item.name).ToList();
                else
                    list = MasterList.Where(a => ValidityCheck(a) && main.CheckAgainstSettings(a))
                        .OrderBy(a => a.ToString()).ToList();
            }
            else if (text == "Highest Margin")
            {
                if (formType == Creation.CreationFormType.Shop)
                    list2 = ShopItems.Where(a => ValidityCheck(a) && main.CheckAgainstSettings(a))
                        .OrderByDescending(a => a.margin()).ToList();
                else
                    list = MasterList.Where(a => ValidityCheck(a) && main.CheckAgainstSettings(a))
                        .OrderByDescending(a => a.margin()).ToList();
            }

            if (list.Count != 0)
            {
                foreach (Creation current in list)
                    if (!ValidityCheck(current))
                        list.Remove(current);

                Creation creation = (Creation)itemList.SelectedItem;
                itemList.BeginUpdate();
                itemList.Items.Clear();
                itemList.Items.AddRange(list.ToArray());

                if (creation != null)
                    itemList.SelectedItem = GetCreationFromList(creation, itemList.Items);
                itemList.EndUpdate();
            }
            else if (list2.Count != 0)
            {
                foreach (ShopItem current2 in list2)
                    if (!ValidityCheck(current2))
                        list2.Remove(current2);

                ShopItem shopItem = (ShopItem)itemList.SelectedItem;
                itemList.BeginUpdate();
                itemList.Items.Clear();
                itemList.Items.AddRange(list2.ToArray());

                if (shopItem != null)
                    itemList.SelectedItem = GetShopItemFromList(shopItem, itemList.Items);
                itemList.EndUpdate();
            }
        }

        private Creation GetCreationFromList(Creation oldCreation, ListBox.ObjectCollection list)
        {
            foreach (Creation creation in list)
                if (creation.GenerateID() == oldCreation.GenerateID())
                    return creation;
            return null;
        }

        private ShopItem GetShopItemFromList(ShopItem item, ListBox.ObjectCollection list)
        {
            foreach (ShopItem shopItem in list)
                if (shopItem.generateID() == item.generateID())
                    return shopItem;
            return null;
        }

        private void TableItemSelected(object sender, EventArgs args)
        {
            if (sender.GetType() == typeof(Label) && ((Label)sender).Tag.GetType() == typeof(Shop))
            {
                Shop shop = (Shop)((Label)sender).Tag;

                if (shop != null)
                {
                    MessageBoxEx.Show(string.Concat(new string[]
                    {
                        "Name: ",
                        shop.Name,
                        "\r\nMembers: ",
                        shop.Members.ToString(),
                        "\r\nLocation: ",
                        shop.Location,
                        "\r\nShop Keeper: ",
                        shop.ShopKeeper,
                        "\r\nExtra Information: ",
                        shop.ExtraNotes
                    }), shop.Name);
                    return;
                }
            }
            main.ForceChangeSortComboBoxText("Alphabetize");
            main.ShowItemData((Item)((Control)sender).Tag);
        }

        public void UpdateMasterList()
        {
            for (int i = 0; i < MasterList.Count(); i += 1)
            {
                for (int j = 0; j < MasterList[i].Input.Count(); j += 1)
                {
                    Item item = MainForm.GetItem(MasterList[i].Input[j].id);
                    MasterList[i].Input[j].BuyPrice = item.BuyPrice;
                    MasterList[i].Input[j].sellPrice = item.sellPrice;
                }
                for (int k = 0; k < MasterList[i].Output.Count(); k += 1)
                {
                    Item item2 = MainForm.GetItem(MasterList[i].Output[k].id);
                    MasterList[i].Output[k].BuyPrice = item2.BuyPrice;
                    MasterList[i].Output[k].sellPrice = item2.sellPrice;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            itemList = new ListBox();
            TablePanel = new TableLayoutPanel();
            sortBox = new ComboBox();
            SuspendLayout();
            itemList.FormattingEnabled = true;
            itemList.Location = new Point(12, 12);
            itemList.Name = "itemList";
            itemList.Size = new Size(151, 238);
            itemList.TabIndex = 0;
            itemList.SelectedIndexChanged += new EventHandler(itemList_SelectedIndexChanged);
            TablePanel.AutoSize = true;
            TablePanel.ColumnCount = 1;
            TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            TablePanel.Location = new Point(169, 12);
            TablePanel.Name = "TablePanel";
            TablePanel.RowCount = 15;
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            TablePanel.Size = new Size(4, 332);
            TablePanel.TabIndex = 1;
            sortBox.FormattingEnabled = true;
            sortBox.Items.AddRange(new object[]
            {
                "Alphabetize",
                "Highest Margin",
                "Insta-buy",
                "Insta-sell",
                "Insta-transaction"
            });
            sortBox.Location = new Point(12, 256);
            sortBox.Name = "sortBox";
            sortBox.Size = new Size(151, 21);
            sortBox.TabIndex = 2;
            sortBox.Text = "Highest Margin";
            sortBox.SelectedIndexChanged += new EventHandler(sortBox_SelectedIndexChanged);
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 283);
            Controls.Add(sortBox);
            Controls.Add(TablePanel);
            Controls.Add(itemList);
            DoubleBuffered = true;
            EnableGlass = false;
            FlattenMDIBorder = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Creation_Form";
            Padding = new System.Windows.Forms.Padding(9);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Creation Form";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
