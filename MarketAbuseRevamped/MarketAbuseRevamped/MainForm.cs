using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;
using MarketAbuseRevamped.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace MarketAbuseRevamped
{
	public class MainForm : Office2007RibbonForm
	{
        private bool programLoaded = false;
		public static List<Item> AllItems = new List<Item>();
		public static ObservableCollection<Item> activeFlips = new ObservableCollection<Item>();
		private List<Creation> FavoriteCreations = new List<Creation>();
		private Thread updateThread, imageItemThread;
		private DateTime time = DateTime.Now;
		private Creation_Form lastForm;
		private IContainer components = null;
		private Button Search;
		private GroupBox itemDataGroupBox, ActiveFlipsGroupBox, settingsBox, AlchemyValues;
		private PictureBox ITEMPICTURE;
		private System.Windows.Forms.Timer lastUpdatedTimer;
		private RibbonControl MainRibbonControl;
		private ApplicationButton FileButton;
		private StyleManager Style;
		private TextBox searchTextbox;
		private RibbonPanel FlippingPanel, OtherPanel, ribbonPanel1;
		private RibbonTabItem FlippingRibbonItem, Settings, OtherTabItem;
		private ComboBox sortComboBox, THEME;
		public ListBox itemList;
		private RibbonBar OtherRibbonBar;
		private ItemContainer PrimaryOtherContainer, SkillsContainer, NonSkillOrientedCreations, ShopAbuse;
        private ButtonItem All, Cooking, Construction, Crafting, Farming, Fletching, Herblore, BarbarianMix, 
            Decanting, HerbCleaning, PotionMaking, UnfPotions, Magic, HighAlchemy, LowAlchemy, Prayer, Runecrafting, 
            Smithing, Poison, Sets, Unknown, GeneralStore, KaramjaStore, SellToGE, Favorites, Credits,
            Enchanting, OtherMagic, HelpButton, ActiveFlipsHelp, CreationHelp, FlippingHelp;
		private ButtonX AddOrRemoveFlip, FlipItem12, FlipItem11, FlipItem10, FlipItem9, FlipItem8, FlipItem7, 
            FlipItem6, FlipItem5, FlipItem4, FlipItem3, FlipItem2, FlipItem1;
		private NumericUpDown moneyAvailable;
		private CheckBox Members, moneyLimiterCheckbox, showAlchValues;
		private Label GeneralStoreLabel, KaramjaStoreLabel, LowAlchLabel, HighAlchLabel, themeLabel, moneyAvailableLabel, 
            SELLQUANTITY, BUYQUANTITY, MARGIN, SELLPRICE, BUYPRICE, ID, NAME, sortLabel, lastUpdated;

		public MainForm()
		{
			InitializeComponent();
			if (File.Exists("Update.rar"))
				File.Delete("Update.rar");

			if (DownloadString("http://pastebin.com/raw/zXg0YMyk") != Assembly.GetExecutingAssembly().GetName().Version.ToString())
			{
				if (MessageBoxEx.Show("This application has an update. Would you like to update?", "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					string address = DownloadString("http://pastebin.com/raw/GyGp6iLY");
					WebClient webClient = new WebClient();
					webClient.DownloadFile(address, "Update.rar");
					MessageBox.Show("Update.rar has been downloaded to active directory. Extract this file to finalize the update.");
					Process.Start(new ProcessStartInfo
					{
						FileName = Directory.GetCurrentDirectory(),
						UseShellExecute = true,
						Verb = "open"
					});
					Environment.Exit(0);
				}
			}
			Size = new Size(501, 376);
			LoadSettings();
		}

		private void HandleThread()
		{
			while (true)
			{
				if (programLoaded)
				{
					UpdateItemListing(false);
					if (lastForm != null)
						lastForm.UpdateMasterList();
					Invoke(new MethodInvoker(delegate { UpdateItemInfo(); }));
					Invoke(new MethodInvoker(delegate { UpdateShowing(); }));
					time = DateTime.Now;
				}
			}
		}

        private void HandleImageThread()
        {
            int updateEvery1000 = 0;
            while (true)
            {
                Invoke(new MethodInvoker(delegate { UpdateItemPicture(); }));

                /*if (lastForm != null)
                {
                    if (updateEvery1000 == 100000)
                    {
                        Invoke(new MethodInvoker(delegate { lastForm.itemList.BeginUpdate(); }));
                        //Invoke(new MethodInvoker(delegate { lastForm.sortBox_SelectedIndexChanged(lastForm.sortBox, null); }));
                        Invoke(new MethodInvoker(delegate { lastForm.itemList.EndUpdate(); }));
                        updateEvery1000 = 0;
                    }
                    else
                        updateEvery1000++;

                    //Invoke(new MethodInvoker(delegate { lastForm.ReloadCreation(); }));
                }*/
            }
        }
        public void UpdateItemPicture()
        {
            if (itemList.SelectedItem != null && ITEMPICTURE.Image == null)
            {
                Item item = (Item)itemList.SelectedItem;
                if(item != null)
                    ITEMPICTURE.Load("http://cdn.rsbuddy.com/items/" + item.id + ".png");
            }

            if (lastForm != null && lastForm.itemList != null && lastForm.itemList.SelectedItem != null)
            {
                TableLayoutPanel tlp = (TableLayoutPanel)lastForm.Controls.Cast<Control>().FirstOrDefault(a => a.GetType() == typeof(TableLayoutPanel));

                if(tlp != null)
                {
                    foreach (Control c in tlp.Controls.Cast<Control>().Where(a => a.GetType() == typeof(PictureBox)))
                    {
                        Item item = (Item)c.Tag;
                        PictureBox pb = ((PictureBox)c);
                        if (item != null && pb.Image == null)
                            pb.Load("http://cdn.rsbuddy.com/items/" + item.id + ".png");
                    }
                }
            }
        }

		private void CreateItemList()
		{
			DownloadFile("https://rsbuddy.com/exchange/summary.json", "summary.txt");
			string allData = ReadAllDataOfFile("summary.txt");
            List<string> itemInformation = GetItemInformationFromOSBuddyList(allData, true);
            foreach (string current in itemInformation)
				AllItems.Add(new Item(GetInformation(current, "name"), Convert.ToInt32(GetInformation(current, "id")), Convert.ToInt32(GetInformation(current, "sp")), Convert.ToBoolean(GetInformation(current, "members"))));
			Item item = new Item("Coins", 995, 1, false)
			{
				BuyPrice = 1,
				sellPrice = 1,
				buyQuantity = 1,
				sellQuantity = 1
			};
			AllItems.Add(item);
			sortComboBox_SelectedIndexChanged(null, null);
			LoadFavoritedItems();
			updateThread = new Thread(new ThreadStart(HandleThread));
			updateThread.Start();


            imageItemThread = new Thread(new ThreadStart(HandleImageThread));
            imageItemThread.Start();
        }

		private void UpdateItemListing(bool first = false)
		{
			string OSBuddyGuideData = "https://api.rsbuddy.com/grandExchange?a=guidePrice";
			int totalItemLoopCount = 0;
			int localItemLoopCount = 0;
			DateTime now = DateTime.Now;
			foreach (Item current in AllItems)
			{
				DateTime now2 = DateTime.Now;
                OSBuddyGuideData += "&i=" + current.id;
				localItemLoopCount += 1;
                totalItemLoopCount += 1;
				if (localItemLoopCount == 100 || totalItemLoopCount == AllItems.Count)
				{
					localItemLoopCount = 0;
					DownloadFile(OSBuddyGuideData, "itemDataUpdate.txt");
					string itemUpdateData = ReadAllDataOfFile("itemDataUpdate.txt");
					if (itemUpdateData == null && !first)
						break;
					List<string> itemInformationFromOSBuddyList = GetItemInformationFromOSBuddyList(itemUpdateData, false);
					foreach (string current2 in itemInformationFromOSBuddyList)
					{
						int GEBuyPrice = Convert.ToInt32(GetInformation(current2, "buying"));
						int GESellPrice = Convert.ToInt32(GetInformation(current2, "selling"));
						int buyQuantity = Convert.ToInt32(GetInformation(current2, "buyingQuantity"));
						int sellQuantity = Convert.ToInt32(GetInformation(current2, "sellingQuantity"));
						Item item = GetItem(Convert.ToInt32(GetInformation(current2, "id")));
						if (item.id == 995)
							return;
						int buyPrice = 0;

						if (GEBuyPrice != 0)
							buyPrice = GEBuyPrice;
						else if(GESellPrice != 0)
                            buyPrice = GESellPrice;
						item.BuyPrice = ((GEBuyPrice == 0) ? buyPrice : GEBuyPrice);
						item.sellPrice = ((GESellPrice == 0) ? buyPrice : GESellPrice);
						item.buyQuantity = buyQuantity;
						item.sellQuantity = sellQuantity;
						if (item.margin <= 0)
						{
							item.BuyPrice = ((GESellPrice == 0) ? buyPrice : GESellPrice);
							item.sellPrice = ((GEBuyPrice == 0) ? buyPrice : GEBuyPrice);
						}
                        OSBuddyGuideData = "https://api.rsbuddy.com/grandExchange?a=guidePrice";
                    }
					if (!programLoaded)
						Console.WriteLine("Group Time Taken: " + (DateTime.Now - now2).TotalSeconds);
				}
            }
            if (!programLoaded)
                Console.WriteLine("Total Time Taken: " + (DateTime.Now - now).TotalSeconds);
        }

		public static Item GetItem(int id)
		{
            return AllItems.FirstOrDefault(a => a.id == id);
		}

		public static Item GetItem(string name)
		{
            Item item = AllItems.FirstOrDefault(a => a.name.ToLower() == name.ToLower());
            
			if (item == null && name == "Raw beef")
                return GetItem("keefBeef");
            
			if (item == null)
				MessageBoxEx.Show("error getting item \"" + name + "\"");

            return item;
		}

		private string ReadAllDataOfFile(string fileName)
		{
			try
			{
				StreamReader streamReader = new StreamReader(fileName);
				string text = streamReader.ReadToEnd();
				streamReader.Close();
				streamReader.Dispose();
				return text;
			}
			catch
			{
                return null;
			}
		}

		private void DownloadFile(string url, string fileName)
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFile(url, fileName);
				webClient.Dispose();
			}
			catch
			{
			}
		}

		private string DownloadString(string url)
		{
			WebClient webClient = new WebClient();
			string result = webClient.DownloadString(url);
			webClient.Dispose();
			return result;
		}

        private List<string> GetItemInformationFromOSBuddyList(string allData, bool summaryList = false)
        {
            if (allData == null)
                return new List<string>();
            else
            {
                List<string> list = allData.Split(new string[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> list2 = new List<string>();
                for (int i = 0; i < list.Count; i = i + 1)
                {
                    if (summaryList && list[i].Contains("id"))
                        list2.Add(list[i]);
                    else
                    {
                        list2.Add("\"id\":" + list[i].Replace(",", "").Replace("\"", "").Replace(":", "") + "," + list[i + 1]);
                        i = i + 1;
                    }
                }
                return list2;
            }
        }
        
		private string GetInformation(string itemData, string splitText)
		{
			List<string> list = itemData.Split(new char[] { ',' }).ToList();
			foreach (string current in list)
			{
				if (current.ToLower().Contains("\"" + splitText.ToLower() + "\""))
				{
					string text = current.Replace("\"", "").Replace(splitText, "").Replace(":", "").Replace("{", "").Replace("}", "");
					while (text.First() == ' ')
						text = text.Remove(0, 1);
					return text;
				}
			}
            return "FAIL";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			CreateItemList();
			LoadFavoritedCreations();
			FlippingRibbonItem.Select();
			activeFlips.CollectionChanged += new NotifyCollectionChangedEventHandler(ActiveFlipsChanged);
			for (int i = 1; i < 13; i += 1)
			{
				(Controls.Find("FlipItem" + i, true).FirstOrDefault() as ButtonX).MouseUp += new MouseEventHandler(RemoveFlip);
			}
			programLoaded = true;
		}

		private void FavoriteItem(object sender, EventArgs e)
		{
			Item item = (Item)itemList.SelectedItem;
			if (item != null)
				item.favorited = !item.favorited;
			else
			{
				Creation item2 = (Creation)lastForm.itemList.SelectedItem;
				if (!FavoriteCreations.Contains(item2))
					FavoriteCreations.Add(item2);
				else
					FavoriteCreations.Remove(item2);
			}
		}

		public void ShowFavoritesMenu(object sender, MouseEventArgs args)
		{
			ListBox list = (ListBox)sender;
			if (list != null)
			{
				if (args.Button == MouseButtons.Right)
				{
					list.SelectedIndex = list.IndexFromPoint(args.X, args.Y);
					ContextMenu contextMenu = new ContextMenu();
					if (list == itemList)
					{
						bool favorited = ((Item)list.SelectedItem).favorited;
						if (favorited)
							contextMenu.MenuItems.Add("Unfavorite", new EventHandler(FavoriteItem));
						else
							contextMenu.MenuItems.Add("Favorite", new EventHandler(FavoriteItem));
						contextMenu.MenuItems.Add("Watch", new EventHandler(Watch));
						contextMenu.MenuItems.Add("Add to Active Flips", new EventHandler(AddOrRemoveFlip_Click));
						contextMenu.MenuItems.Add("Open in OSBuddy GE", new EventHandler(OpenOSBuddyData));
						contextMenu.MenuItems.Add("Open OSBuddy Graph Data", new EventHandler(OpenOSBuddyData));
					}
					else
					{
						if (lastForm != null && list == lastForm.itemList)
						{
							if (FavoriteCreations.FirstOrDefault(a=>a.GenerateID() == ((Creation)list.SelectedItem).GenerateID()) != null)
								contextMenu.MenuItems.Add("Unfavorite", new EventHandler(FavoriteItem));
							else
								contextMenu.MenuItems.Add("Favorite", new EventHandler(FavoriteItem));
						}
					}
					contextMenu.Show(this, PointToClient(Cursor.Position));
				}
			}
		}

		private void OpenOSBuddyData(object sender, EventArgs args)
		{
			MenuItem menuItem = (MenuItem)sender;
			if (menuItem.Text == "Open in OSBuddy GE")
				Process.Start("https://rsbuddy.com/exchange?id=" + ((Item)itemList.SelectedItem).id);
			else if (menuItem.Text == "Open OSBuddy Graph Data")
	        	Process.Start("https://api.rsbuddy.com/grandExchange?a=graph&start=0&g=1440&i=" + ((Item)itemList.SelectedItem).id);
		}

		public void ShowItemData(Item i)
		{
			itemList.SelectedItem = GetItemFromList(i, itemList.Items);
			FlippingRibbonItem.Select();
			Activate();
		}

		public void UpdateItemInfo()
		{
			if (ID.Tag != null)
			{
				Item item = (Item)ID.Tag;
				BUYPRICE.Text = "Buy Price: " + item.BuyPrice.ToString("N0");
				SELLPRICE.Text = "Sell Price: " + item.sellPrice.ToString("N0");
				MARGIN.Text = "Margin: " + item.margin.ToString("N0");
			}
		}

		private void SearchBoxHandleKeyPress(object sender, KeyPressEventArgs args)
		{
			if (args.KeyChar == '\r')
				Search_Click(null, null);
		}

		private void Search_Click(object sender, EventArgs e)
		{
			sortComboBox.Text = "Search";
			sortComboBox_SelectedIndexChanged(sortComboBox, null);
		}

		private void UpdateShowing()
		{
			sortComboBox_SelectedIndexChanged(sortComboBox, null);
		}

		private void sortComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<Item> list = new List<Item>();
			string text = sortComboBox.Text;
            if (text == "Selling Quantity")
                list = AllItems.Where(a => a.BuyPrice != 0 && a.sellPrice != 0 && a.sellQuantity != 0 && CheckAgainstSettings(a, a.BuyPrice)).OrderByDescending(a => a.sellQuantity).ToList();
            else if (text == "ID")
                list = AllItems.Where(a => CheckAgainstSettings(a, a.BuyPrice)).OrderBy(a => a.id).ToList();
            else if (text == "Buying Quantity")
                list = AllItems.Where(a => a.BuyPrice != 0 && a.sellPrice != 0 && a.buyQuantity != 0 && CheckAgainstSettings(a, a.BuyPrice)).OrderByDescending(a => a.buyQuantity).ToList();
            else if (text == "Fast Flips")
                list = AllItems.Where(a => a.BuyPrice != 0 && a.sellPrice != 0 && CheckAgainstSettings(a, a.BuyPrice) && a.margin >= 1000 && a.buyQuantity >= 25 && a.sellQuantity >= 25).OrderByDescending(a => a.margin).ToList();
            else if (text == "Recommended")
                list = AllItems.Where(a => a.BuyPrice != 0 && a.sellPrice != 0 && CheckAgainstSettings(a, a.BuyPrice) && a.margin >= 5000 && a.buyQuantity >= 6 && a.sellQuantity >= 6).OrderByDescending(a => a.margin).ToList();
            else if (text == "Favorites by Margin")
                list = AllItems.Where(a => a.favorited && a.BuyPrice != 0 && a.sellPrice != 0 && CheckAgainstSettings(a, a.BuyPrice)).OrderByDescending(a => a.margin).ToList();
            else if (text == "Large Quantity")
                list = AllItems.Where(a => a.BuyPrice != 0 && a.sellPrice != 0 && CheckAgainstSettings(a, a.BuyPrice) && a.margin > 3 && a.buyQuantity >= 1000 && a.sellQuantity >= 1000).OrderByDescending(a => a.margin).ToList();
            else if (text == "Lowest Margin")
                list = AllItems.Where(a => a.BuyPrice != 0 && a.sellPrice != 0 && CheckAgainstSettings(a, a.BuyPrice)).OrderBy(a => a.margin).ToList();
            else if (text == "Alphabetize")
                list = AllItems.Where(a => CheckAgainstSettings(a, a.BuyPrice)).OrderBy(a => a.name).ToList();
            else if (text == "Highest Margin")
                list = AllItems.Where(a => a.BuyPrice != 0 && a.sellPrice != 0 && CheckAgainstSettings(a, a.BuyPrice)).OrderByDescending(a => a.margin).ToList();
            else if (text == "Search")
                list = AllItems.Where(a => a.name.ToLower().Contains(searchTextbox.Text.ToLower()) && CheckAgainstSettings(a, a.BuyPrice)).OrderBy(a => a.name).ToList();
			else if (text == "Favorites by Alphabet")
                list = AllItems.Where(a => a.favorited && CheckAgainstSettings(a, a.BuyPrice)).OrderBy(a => a.name).ToList();
			itemList.BeginUpdate();
			Item item = (Item)itemList.SelectedItem;
			itemList.Items.Clear();
			itemList.Items.AddRange(list.ToArray());

			if (item != null)
				itemList.SelectedItem = GetItemFromList(item, itemList.Items);
			itemList.EndUpdate();
		}

		private Item GetItemFromList(Item oldItem, ListBox.ObjectCollection list)
		{
			Item result;
			foreach (Item item in list)
				if (item.id == oldItem.id)
					return item;
			return null;
		}

		private void lastUpdatedTimer_Tick(object sender, EventArgs e)
		{
			lastUpdated.Text = "Last Updated: " + ((int)(DateTime.Now - time).TotalSeconds).ToString() + " seconds ago.";
		}

		private void SaveFavoritedItems()
		{
			StreamWriter streamWriter = new StreamWriter("Favorited Items.txt");
			foreach (Item current in MainForm.AllItems)
			{
				bool favorited = current.favorited;
				if (favorited)
				{
					streamWriter.WriteLine(current.id.ToString());
				}
			}
			streamWriter.Flush();
			streamWriter.Close();
		}

		private void LoadFavoritedItems()
		{
			bool flag = File.Exists("Favorited Items.txt");
			if (flag)
			{
				StreamReader streamReader = new StreamReader("Favorited Items.txt");
				while (!streamReader.EndOfStream)
				{
					int id = Convert.ToInt32(streamReader.ReadLine());
					bool flag2 = MainForm.GetItem(id) != null;
					if (flag2)
					{
						MainForm.GetItem(id).favorited = true;
					}
				}
				streamReader.Close();
				streamReader.Dispose();
			}
		}

		private void SaveSettings()
		{
			StreamWriter streamWriter = new StreamWriter("Settings.txt");
			streamWriter.WriteLine("[MoneyLimiter]" + moneyLimiterCheckbox.Checked.ToString());
			streamWriter.WriteLine("[MoneyLimiterAmount]" + moneyAvailable.Value);
			streamWriter.WriteLine("[Members]" + Members.Checked.ToString());
			streamWriter.WriteLine("[AlchemyTab]" + showAlchValues.Checked.ToString());
			streamWriter.WriteLine("[Theme]" + THEME.Text);
			streamWriter.Flush();
			streamWriter.Close();
		}

		private void LoadSettings()
		{
			if (File.Exists("Settings.txt"))
			{
				StreamReader streamReader = new StreamReader("Settings.txt");
				while (!streamReader.EndOfStream)
				{
					string s = streamReader.ReadLine();
					string text = ReadSetting(s);
					string text2 = ReadSettingValue(s);
					string a = text;
                    if (a == "Theme")
                    {
                        if (text2 == "VS2012Dark")
                            Style.ManagerStyle = eStyle.VisualStudio2012Dark;
                        else if (text2 == "2007Silver")
                            Style.ManagerStyle = eStyle.Office2007Silver;
                        else if (text2 == "2007Black")
                            Style.ManagerStyle = eStyle.Office2007Black;
                        else if (text2 == "2007Blue")
                            Style.ManagerStyle = eStyle.Office2007Blue;
                        else if (text2 == "VS2010Blue")
                            Style.ManagerStyle = eStyle.VisualStudio2010Blue;
                        else if (text2 == "Win7Blue")
                            Style.ManagerStyle = eStyle.Windows7Blue;
                        else if (text2 == "2010Silver")
                            Style.ManagerStyle = eStyle.Office2010Silver;
                        else if (text2 == "Metro")
                            Style.ManagerStyle = eStyle.Metro;
                        else if (text2 == "2007Glass")
                            Style.ManagerStyle = eStyle.Office2007VistaGlass;
                        else if (text2 == "2010Blue")
                            Style.ManagerStyle = eStyle.Office2010Blue;
                        else if (text2 == "2013")
                            Style.ManagerStyle = eStyle.Metro;
                        else if (text2 == "2014")
                            Style.ManagerStyle = eStyle.OfficeMobile2014;
                        else if (text2 == "2016")
                            Style.ManagerStyle = eStyle.Office2016;
                        else if (text2 == "2010Black")
                            Style.ManagerStyle = eStyle.Office2010Black;
                        else if (text2 == "VS2012Light")
                            Style.ManagerStyle = eStyle.VisualStudio2012Light;
                        THEME.Text = text2;
                    }
                    else if (a == "AlchemyTab")
                    {
                        showAlchValues.Checked = Convert.ToBoolean(text2);
                        AlchemyValues.Visible = Convert.ToBoolean(text2);
                    }
                    else if(a == "Members")
                        Members.Checked = Convert.ToBoolean(text2);
                    else if(a == "MoneyLimiterAmount")
                        moneyAvailable.Value = Convert.ToDecimal(text2);
                    else if(a == "MoneyLimiter")
						moneyLimiterCheckbox.Checked = Convert.ToBoolean(text2);
				}
				streamReader.Close();
				streamReader.Dispose();
			}
		}

		public bool CheckAgainstSettings(Item i, int numChecked)
		{
			if ((!Members.Checked && !i.members) || Members.Checked)
			{
				if (!moneyLimiterCheckbox.Checked)
					return true;

				if (moneyAvailable.Value >= numChecked)
					return true;
			}
			return false;
		}

		public bool CheckAgainstSettings(Creation c)
		{
			foreach (Item current in c.Input)
				if (!CheckAgainstSettings(current, current.BuyPrice))
					return false;
			foreach (Item current2 in c.Output)
				if (!CheckAgainstSettings(current2, current2.sellPrice))
					return false;
			return true;
		}

		public bool CheckAgainstSettings(Shop s)
		{
			return (!Members.Checked && !s.Members) || Members.Checked;
		}

		public bool CheckAgainstSettings(ShopItem s)
		{
			return !(moneyLimiterCheckbox.Checked && s.Cost >= moneyAvailable.Value) 
                && CheckAgainstSettings(ShopList.GetShop(s));
		}

		public string ReadSetting(string s)
		{
			return s.Remove(s.IndexOf("]")).Replace("[", "");
		}

		public string ReadSettingValue(string s)
		{
			return s.Substring(s.IndexOf(']') + 1);
		}

		private void SaveFavoritedCreations()
		{
			StreamWriter streamWriter = new StreamWriter("Favorited Creations.txt");
			foreach (Creation current in FavoriteCreations)
				streamWriter.WriteLine(current.GenerateID());
			streamWriter.Flush();
			streamWriter.Close();
		}

		private void LoadFavoritedCreations()
		{
			if (File.Exists("Favorited Creations.txt"))
			{
				StreamReader streamReader = new StreamReader("Favorited Creations.txt");
				while (!streamReader.EndOfStream)
				{
					string id = streamReader.ReadLine();
					Creation creation = CreationLists.GetCreation(id);
					if (creation != null)
						FavoriteCreations.Add(creation);
				}
				streamReader.Close();
				streamReader.Dispose();
			}
		}

		private void CreationForm(string name, List<Creation> creations)
		{
			if (lastForm != null)
				lastForm.Close();
			Creation_Form creation_Form = new Creation_Form(name, creations, this);
			creation_Form.Show();
			lastForm = creation_Form;
		}

		private void CreationForm(string name, Creation.CreationFormType type)
		{
			if (lastForm != null)
				lastForm.Close();
			Creation_Form creation_Form = new Creation_Form(name, type, this);
			creation_Form.Show();
			lastForm = creation_Form;
		}

		private void CreationForm(string name, List<Shop> shops)
		{
			if (lastForm != null)
				lastForm.Close();
			Creation_Form creation_Form = new Creation_Form(name, shops, this);
			creation_Form.Show();
			lastForm = creation_Form;
		}

		public void ForceChangeSortComboBoxText(string text)
		{
			sortComboBox.Text = text;
			sortComboBox_SelectedIndexChanged(sortComboBox, null);
		}

		private void Members_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSettingData();
		}

		private void moneyLimiterCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSettingData();
		}

		private void moneyAvailable_ValueChanged(object sender, EventArgs e)
		{
			UpdateSettingData();
		}

		private void UpdateSettingData()
		{
			sortComboBox_SelectedIndexChanged(sortComboBox, null);
			if (lastForm != null)
				lastForm.sortBox_SelectedIndexChanged(sortComboBox, null);
		}

		private void THEME_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = THEME.Text;
            if (text == "VS2012Dark")
                Style.ManagerStyle = eStyle.VisualStudio2012Dark;
            else if (text == "2007Silver")
                Style.ManagerStyle = eStyle.Office2007Silver;
            else if (text == "2007Black")
                Style.ManagerStyle = eStyle.Office2007Black;
            else if(text == "2007Blue")
                Style.ManagerStyle = eStyle.Office2007Blue;
            else if (text == "VS2010Blue")
                Style.ManagerStyle = eStyle.VisualStudio2010Blue;
            else if(text == "Win7Blue")
                Style.ManagerStyle = eStyle.Windows7Blue;
            else if (text == "2010Silver")
                Style.ManagerStyle = eStyle.Office2010Silver;
            else if(text == "Metro")
                Style.ManagerStyle = eStyle.Metro;
            else if(text == "2010Blue")
                Style.ManagerStyle = eStyle.Office2010Blue;
            else if (text == "2007Glass")
                Style.ManagerStyle = eStyle.Office2007VistaGlass;
            else if (text == "2013")
                Style.ManagerStyle = eStyle.Metro;
            else if(text == "2014")
                Style.ManagerStyle = eStyle.OfficeMobile2014;
            else if (text == "2016")
                Style.ManagerStyle = eStyle.Office2016;
            else if(text == "2010Black")
                Style.ManagerStyle = eStyle.Office2010Black;
            else if (text == "VS2012Light")
                Style.ManagerStyle = eStyle.VisualStudio2012Light;
		}

		private void All_Click(object sender, EventArgs e)
		{
			CreationForm("All Skills", CreationLists.Skills.Creations);
		}

		private void Cooking_Click(object sender, EventArgs e)
		{
			CreationForm("Cooking", CreationLists.Cooking);
		}

		private void Construction_Click(object sender, EventArgs e)
		{
			CreationForm("Construction", CreationLists.Construction);
		}

		private void Crafting_Click(object sender, EventArgs e)
		{
			CreationForm("Crafting", CreationLists.Crafting);
		}

		private void Farming_Click(object sender, EventArgs e)
		{
			CreationForm("Farming", CreationLists.Farming);
		}

		private void Fletching_Click(object sender, EventArgs e)
		{
			CreationForm("Fletching", CreationLists.Fletching);
		}

		private void Herblore_Click(object sender, EventArgs e)
		{
			CreationForm("All Herblore", CreationLists.Herblore.Creations);
		}

		private void BarbarianMix_Click_1(object sender, EventArgs e)
		{
			CreationForm("Barbarian Mix", CreationLists.Mix);
		}

		private void Decanting_Click(object sender, EventArgs e)
		{
			CreationForm("Decanting", CreationLists.Decant);
		}

		private void HerbCleaning_Click(object sender, EventArgs e)
		{
			CreationForm("Herb Cleaning", CreationLists.HerbCleaning);
		}

		private void PotionMaking_Click(object sender, EventArgs e)
		{
			CreationForm("Potion Making", CreationLists.Potions);
		}

		private void UnfPotions_Click(object sender, EventArgs e)
		{
			CreationForm("Unfinished Potions", CreationLists.Unfinished);
		}

		private void Magic_Click(object sender, EventArgs e)
		{
			CreationForm("Magic", CreationLists.Magic.Creations);
		}

		private void HighAlchemy_Click(object sender, EventArgs e)
		{
			CreationForm("High Alchemy", Creation.CreationFormType.HighAlch);
		}

		private void LowAlchemy_Click(object sender, EventArgs e)
		{
			CreationForm("Low Alchemy", Creation.CreationFormType.LowAlch);
		}

		private void Prayer_Click(object sender, EventArgs e)
		{
			CreationForm("Prayer", CreationLists.Prayer);
		}

		private void Runecrafting_Click(object sender, EventArgs e)
		{
			CreationForm("Runecrafting", CreationLists.Runecrafting);
		}

		private void Smithing_Click_1(object sender, EventArgs e)
		{
			CreationForm("Smithing", CreationLists.Smithing);
		}

		private void Favorites_Click(object sender, EventArgs e)
		{
			CreationForm("Favorites", FavoriteCreations);
		}

		private void Poison_Click(object sender, EventArgs e)
		{
			CreationForm("Poisons", CreationLists.Poisons);
		}

		private void Sets_Click(object sender, EventArgs e)
		{
			CreationForm("Sets", CreationLists.Sets);
		}

		private void Unknown_Click(object sender, EventArgs e)
		{
			CreationForm("Unknown", CreationLists.Custom);
		}

		private void GeneralStore_Click(object sender, EventArgs e)
		{
			CreationForm("Sell to General Store", Creation.CreationFormType.GereralStore);
		}

		private void KaramjaStore_Click(object sender, EventArgs e)
		{
			CreationForm("Sell to Karamja Store", Creation.CreationFormType.KaramjaStore);
		}

		private void buttonItem1_Click(object sender, EventArgs e)
		{
			CreationForm("Sell to Grand Exchange", ShopList.Shops);
		}

		private void Credits_Click(object sender, EventArgs e)
		{
			MessageBoxEx.Show("This application was created by Sicryption, with the help of:\nOSBuddy - All Item Information\nThe 2007Scape Wikia - All Creation Data\n2007rshelp - All Shop Data\nCounterFX - Compiling/Testing Creation Data", "Credits");
		}

		private void itemList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender != null)
			{
				ListBox listBox = (ListBox)sender;
				if (listBox.SelectedItem != null)
				{
					Item item = (Item)listBox.SelectedItem;
					NAME.Text = "Name: " + item.name;
					ID.Text = "ID: " + item.id;
					ID.Tag = item;
					BUYPRICE.Text = "Buy Price: " + item.BuyPrice.ToString("N0");
					SELLPRICE.Text = "Sell Price: " + item.sellPrice.ToString("N0");
					MARGIN.Text = "Margin: " + item.margin.ToString("N0");
					BUYQUANTITY.Text = "Buy Quantity: " + item.buyQuantity.ToString("N0");
					SELLQUANTITY.Text = "Sell Quantity: " + item.sellQuantity.ToString("N0");
					HighAlchLabel.Text = "High Alch: " + item.highAlch.ToString("N0");
					LowAlchLabel.Text = "Low Alch: " + item.lowAlch.ToString("N0");
					KaramjaStoreLabel.Text = "Karamja Store: " + item.karamjaStore.ToString("N0");
					GeneralStoreLabel.Text = "General Store: " + item.generalStore.ToString("N0");
                    ITEMPICTURE.Image = null;
					//ITEMPICTURE.Load("http://cdn.rsbuddy.com/items/" + item.id + ".png");
				}
			}
		}

		private void AddOrRemoveFlip_Click(object sender, EventArgs e)
		{
			bool flag = MainForm.activeFlips.Count == 12;
			if (flag)
			{
				MessageBox.Show("You have too many Active Flips.\r\nPlease remove one and try again.");
			}
			else
			{
				bool flag2 = ID.Tag != null && !MainForm.activeFlips.Contains(ID.Tag) && MainForm.activeFlips.Count < 12;
				if (flag2)
				{
					MainForm.activeFlips.Add((Item)ID.Tag);
				}
			}
		}

		private void RemoveFlip(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Right;
			if (flag)
			{
				Item item = (Item)(sender as ButtonX).Tag;
				bool flag2 = item != null && MainForm.activeFlips.Contains(item);
				if (flag2)
				{
					MainForm.activeFlips.Remove(item);
				}
			}
			else
			{
				bool flag3 = e.Button == MouseButtons.Left;
				if (flag3)
				{
					ForceChangeSortComboBoxText("Alphabetize");
					Item item2 = (Item)((Control)sender).Tag;
					bool flag4 = item2 != null;
					if (flag4)
					{
						ShowItemData(item2);
					}
				}
			}
		}

		private void ActiveFlipsChanged(object sender, NotifyCollectionChangedEventArgs handler)
		{
			int num;
			for (int i = 1; i < MainForm.activeFlips.Count<Item>() + 1; i = num + 1)
			{
				ButtonX buttonX = base.Controls.Find("FlipItem" + i, true).FirstOrDefault<Control>() as ButtonX;
				buttonX.Image = LoadPicture("http://cdn.rsbuddy.com/items/" + MainForm.activeFlips[i - 1].id + ".png");
				buttonX.Tag = MainForm.activeFlips[i - 1];
				num = i;
			}
			for (int j = 12; j > MainForm.activeFlips.Count<Item>(); j = num - 1)
			{
				ButtonX buttonX2 = base.Controls.Find("FlipItem" + j, true).FirstOrDefault<Control>() as ButtonX;
				buttonX2.Tag = null;
				buttonX2.Image = null;
				num = j;
			}
		}

		private Bitmap LoadPicture(string url)
		{
			Stream stream = new WebClient().OpenRead(url);
			return new Bitmap(stream);
		}

		private void ActiveFlipsHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show("To add an item to the Active Flips Section, Press the blue + sign.\r\nTo remove an item from the Active Flips Section, Right click the picture of the item.");
		}

		private void CreationHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Creations are a bunch of tasks a player can do to make money.\r\nThese tasks could be as simple as fletching an arrow, to as complex making a Dragonfire Shield.\r\nThe creations do not currently show requirements, so be careful.");
		}

		private void FlippingHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show("To successfully flip an item, buy an item for a few gp higher than the listed buy price, and sell it for a few gp less than the listed sell price.\r\nI recommend using the \"Recommended\", \"Fast Flips\", and \"Large Quantity\" sections to flip.");
		}

		private void Watch(object sender, EventArgs e)
		{
			MessageBox.Show("This feature is temporarily disabled.\r\nThis feature will allow you to watch over an item, and will alert you if a price hits a certain amount.");
		}

		private void showAlchValues_CheckedChanged(object sender, EventArgs e)
		{
			AlchemyValues.Visible = (sender as CheckBox).Checked;
		}

		private void searchTextbox_TextChanged(object sender, EventArgs e)
		{
			sortComboBox.Text = "Search";
			sortComboBox_SelectedIndexChanged(sortComboBox, null);
		}

		private void Enchanting_Click(object sender, EventArgs e)
		{
			CreationForm("Enchanting", CreationLists.Enchanting);
		}

		private void OtherMagic_Click(object sender, EventArgs e)
		{
			CreationForm("Other Magics", CreationLists.OtherMagic);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				if (updateThread != null)
					updateThread.Abort();
                if (imageItemThread != null)
                    imageItemThread.Abort();
                SaveSettings();
				SaveFavoritedItems();
				SaveFavoritedCreations();
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.Search = new System.Windows.Forms.Button();
            this.itemDataGroupBox = new System.Windows.Forms.GroupBox();
            this.AddOrRemoveFlip = new DevComponents.DotNetBar.ButtonX();
            this.ITEMPICTURE = new System.Windows.Forms.PictureBox();
            this.SELLQUANTITY = new System.Windows.Forms.Label();
            this.BUYQUANTITY = new System.Windows.Forms.Label();
            this.MARGIN = new System.Windows.Forms.Label();
            this.SELLPRICE = new System.Windows.Forms.Label();
            this.BUYPRICE = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.NAME = new System.Windows.Forms.Label();
            this.sortLabel = new System.Windows.Forms.Label();
            this.lastUpdated = new System.Windows.Forms.Label();
            this.lastUpdatedTimer = new System.Windows.Forms.Timer(this.components);
            this.MainRibbonControl = new DevComponents.DotNetBar.RibbonControl();
            this.OtherPanel = new DevComponents.DotNetBar.RibbonPanel();
            this.OtherRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.PrimaryOtherContainer = new DevComponents.DotNetBar.ItemContainer();
            this.SkillsContainer = new DevComponents.DotNetBar.ItemContainer();
            this.All = new DevComponents.DotNetBar.ButtonItem();
            this.Cooking = new DevComponents.DotNetBar.ButtonItem();
            this.Construction = new DevComponents.DotNetBar.ButtonItem();
            this.Crafting = new DevComponents.DotNetBar.ButtonItem();
            this.Farming = new DevComponents.DotNetBar.ButtonItem();
            this.Fletching = new DevComponents.DotNetBar.ButtonItem();
            this.Herblore = new DevComponents.DotNetBar.ButtonItem();
            this.BarbarianMix = new DevComponents.DotNetBar.ButtonItem();
            this.Decanting = new DevComponents.DotNetBar.ButtonItem();
            this.HerbCleaning = new DevComponents.DotNetBar.ButtonItem();
            this.PotionMaking = new DevComponents.DotNetBar.ButtonItem();
            this.UnfPotions = new DevComponents.DotNetBar.ButtonItem();
            this.Magic = new DevComponents.DotNetBar.ButtonItem();
            this.Enchanting = new DevComponents.DotNetBar.ButtonItem();
            this.HighAlchemy = new DevComponents.DotNetBar.ButtonItem();
            this.LowAlchemy = new DevComponents.DotNetBar.ButtonItem();
            this.OtherMagic = new DevComponents.DotNetBar.ButtonItem();
            this.Prayer = new DevComponents.DotNetBar.ButtonItem();
            this.Runecrafting = new DevComponents.DotNetBar.ButtonItem();
            this.Smithing = new DevComponents.DotNetBar.ButtonItem();
            this.Favorites = new DevComponents.DotNetBar.ButtonItem();
            this.NonSkillOrientedCreations = new DevComponents.DotNetBar.ItemContainer();
            this.Poison = new DevComponents.DotNetBar.ButtonItem();
            this.Sets = new DevComponents.DotNetBar.ButtonItem();
            this.Unknown = new DevComponents.DotNetBar.ButtonItem();
            this.ShopAbuse = new DevComponents.DotNetBar.ItemContainer();
            this.GeneralStore = new DevComponents.DotNetBar.ButtonItem();
            this.KaramjaStore = new DevComponents.DotNetBar.ButtonItem();
            this.SellToGE = new DevComponents.DotNetBar.ButtonItem();
            this.FlippingPanel = new DevComponents.DotNetBar.RibbonPanel();
            this.AlchemyValues = new System.Windows.Forms.GroupBox();
            this.GeneralStoreLabel = new System.Windows.Forms.Label();
            this.KaramjaStoreLabel = new System.Windows.Forms.Label();
            this.LowAlchLabel = new System.Windows.Forms.Label();
            this.HighAlchLabel = new System.Windows.Forms.Label();
            this.ActiveFlipsGroupBox = new System.Windows.Forms.GroupBox();
            this.FlipItem12 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem11 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem10 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem9 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem8 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem7 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem6 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem5 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem4 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem3 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem2 = new DevComponents.DotNetBar.ButtonX();
            this.FlipItem1 = new DevComponents.DotNetBar.ButtonX();
            this.sortComboBox = new System.Windows.Forms.ComboBox();
            this.itemList = new System.Windows.Forms.ListBox();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.showAlchValues = new System.Windows.Forms.CheckBox();
            this.THEME = new System.Windows.Forms.ComboBox();
            this.themeLabel = new System.Windows.Forms.Label();
            this.moneyLimiterCheckbox = new System.Windows.Forms.CheckBox();
            this.moneyAvailableLabel = new System.Windows.Forms.Label();
            this.moneyAvailable = new System.Windows.Forms.NumericUpDown();
            this.Members = new System.Windows.Forms.CheckBox();
            this.FileButton = new DevComponents.DotNetBar.ApplicationButton();
            this.Credits = new DevComponents.DotNetBar.ButtonItem();
            this.HelpButton = new DevComponents.DotNetBar.ButtonItem();
            this.ActiveFlipsHelp = new DevComponents.DotNetBar.ButtonItem();
            this.CreationHelp = new DevComponents.DotNetBar.ButtonItem();
            this.FlippingHelp = new DevComponents.DotNetBar.ButtonItem();
            this.FlippingRibbonItem = new DevComponents.DotNetBar.RibbonTabItem();
            this.OtherTabItem = new DevComponents.DotNetBar.RibbonTabItem();
            this.Settings = new DevComponents.DotNetBar.RibbonTabItem();
            this.Style = new DevComponents.DotNetBar.StyleManager(this.components);
            this.itemDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ITEMPICTURE)).BeginInit();
            this.MainRibbonControl.SuspendLayout();
            this.OtherPanel.SuspendLayout();
            this.FlippingPanel.SuspendLayout();
            this.AlchemyValues.SuspendLayout();
            this.ActiveFlipsGroupBox.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.settingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(123, 3);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(57, 24);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // itemDataGroupBox
            // 
            this.itemDataGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.itemDataGroupBox.Controls.Add(this.AddOrRemoveFlip);
            this.itemDataGroupBox.Controls.Add(this.ITEMPICTURE);
            this.itemDataGroupBox.Controls.Add(this.SELLQUANTITY);
            this.itemDataGroupBox.Controls.Add(this.BUYQUANTITY);
            this.itemDataGroupBox.Controls.Add(this.MARGIN);
            this.itemDataGroupBox.Controls.Add(this.SELLPRICE);
            this.itemDataGroupBox.Controls.Add(this.BUYPRICE);
            this.itemDataGroupBox.Controls.Add(this.ID);
            this.itemDataGroupBox.Controls.Add(this.NAME);
            this.itemDataGroupBox.Location = new System.Drawing.Point(186, 3);
            this.itemDataGroupBox.Name = "itemDataGroupBox";
            this.itemDataGroupBox.Size = new System.Drawing.Size(217, 149);
            this.itemDataGroupBox.TabIndex = 4;
            this.itemDataGroupBox.TabStop = false;
            this.itemDataGroupBox.Text = "Item Data";
            // 
            // AddOrRemoveFlip
            // 
            this.AddOrRemoveFlip.AccessibleDescription = "Add Item to Active Flips";
            this.AddOrRemoveFlip.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AddOrRemoveFlip.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.AddOrRemoveFlip.Image = global::MarketAbuseRevamped.Properties.Resources.plus_sign_128;
            this.AddOrRemoveFlip.Location = new System.Drawing.Point(177, 105);
            this.AddOrRemoveFlip.Name = "AddOrRemoveFlip";
            this.AddOrRemoveFlip.Size = new System.Drawing.Size(34, 32);
            this.AddOrRemoveFlip.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AddOrRemoveFlip.TabIndex = 8;
            this.AddOrRemoveFlip.Click += new System.EventHandler(this.AddOrRemoveFlip_Click);
            // 
            // ITEMPICTURE
            // 
            this.ITEMPICTURE.Location = new System.Drawing.Point(177, 19);
            this.ITEMPICTURE.Name = "ITEMPICTURE";
            this.ITEMPICTURE.Size = new System.Drawing.Size(34, 32);
            this.ITEMPICTURE.TabIndex = 7;
            this.ITEMPICTURE.TabStop = false;
            // 
            // SELLQUANTITY
            // 
            this.SELLQUANTITY.AutoSize = true;
            this.SELLQUANTITY.BackColor = System.Drawing.Color.Transparent;
            this.SELLQUANTITY.Location = new System.Drawing.Point(6, 124);
            this.SELLQUANTITY.Name = "SELLQUANTITY";
            this.SELLQUANTITY.Size = new System.Drawing.Size(69, 13);
            this.SELLQUANTITY.TabIndex = 6;
            this.SELLQUANTITY.Text = "Sell Quantity:";
            // 
            // BUYQUANTITY
            // 
            this.BUYQUANTITY.AutoSize = true;
            this.BUYQUANTITY.BackColor = System.Drawing.Color.Transparent;
            this.BUYQUANTITY.Location = new System.Drawing.Point(6, 106);
            this.BUYQUANTITY.Name = "BUYQUANTITY";
            this.BUYQUANTITY.Size = new System.Drawing.Size(70, 13);
            this.BUYQUANTITY.TabIndex = 5;
            this.BUYQUANTITY.Text = "Buy Quantity:";
            // 
            // MARGIN
            // 
            this.MARGIN.AutoSize = true;
            this.MARGIN.BackColor = System.Drawing.Color.Transparent;
            this.MARGIN.Location = new System.Drawing.Point(6, 88);
            this.MARGIN.Name = "MARGIN";
            this.MARGIN.Size = new System.Drawing.Size(42, 13);
            this.MARGIN.TabIndex = 4;
            this.MARGIN.Text = "Margin:";
            // 
            // SELLPRICE
            // 
            this.SELLPRICE.AutoSize = true;
            this.SELLPRICE.BackColor = System.Drawing.Color.Transparent;
            this.SELLPRICE.Location = new System.Drawing.Point(6, 70);
            this.SELLPRICE.Name = "SELLPRICE";
            this.SELLPRICE.Size = new System.Drawing.Size(54, 13);
            this.SELLPRICE.TabIndex = 3;
            this.SELLPRICE.Text = "Sell Price:";
            // 
            // BUYPRICE
            // 
            this.BUYPRICE.AutoSize = true;
            this.BUYPRICE.BackColor = System.Drawing.Color.Transparent;
            this.BUYPRICE.Location = new System.Drawing.Point(6, 52);
            this.BUYPRICE.Name = "BUYPRICE";
            this.BUYPRICE.Size = new System.Drawing.Size(55, 13);
            this.BUYPRICE.TabIndex = 2;
            this.BUYPRICE.Text = "Buy Price:";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.BackColor = System.Drawing.Color.Transparent;
            this.ID.Location = new System.Drawing.Point(6, 34);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(21, 13);
            this.ID.TabIndex = 1;
            this.ID.Text = "ID:";
            // 
            // NAME
            // 
            this.NAME.AutoSize = true;
            this.NAME.BackColor = System.Drawing.Color.Transparent;
            this.NAME.Location = new System.Drawing.Point(6, 16);
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(38, 13);
            this.NAME.TabIndex = 0;
            this.NAME.Text = "Name:";
            // 
            // sortLabel
            // 
            this.sortLabel.AutoSize = true;
            this.sortLabel.BackColor = System.Drawing.Color.Transparent;
            this.sortLabel.Location = new System.Drawing.Point(0, 281);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sortLabel.Size = new System.Drawing.Size(47, 13);
            this.sortLabel.TabIndex = 5;
            this.sortLabel.Text = "Sort By: ";
            // 
            // lastUpdated
            // 
            this.lastUpdated.AutoSize = true;
            this.lastUpdated.BackColor = System.Drawing.Color.Transparent;
            this.lastUpdated.Location = new System.Drawing.Point(0, 304);
            this.lastUpdated.Name = "lastUpdated";
            this.lastUpdated.Size = new System.Drawing.Size(77, 13);
            this.lastUpdated.TabIndex = 7;
            this.lastUpdated.Text = "Last Updated: ";
            // 
            // lastUpdatedTimer
            // 
            this.lastUpdatedTimer.Enabled = true;
            this.lastUpdatedTimer.Interval = 1000;
            this.lastUpdatedTimer.Tick += new System.EventHandler(this.lastUpdatedTimer_Tick);
            // 
            // MainRibbonControl
            // 
            this.MainRibbonControl.AutoExpand = false;
            this.MainRibbonControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.MainRibbonControl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MainRibbonControl.CaptionVisible = true;
            this.MainRibbonControl.Controls.Add(this.FlippingPanel);
            this.MainRibbonControl.Controls.Add(this.ribbonPanel1);
            this.MainRibbonControl.Controls.Add(this.OtherPanel);
            this.MainRibbonControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainRibbonControl.ForeColor = System.Drawing.Color.Black;
            this.MainRibbonControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MainRibbonControl.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.FileButton,
            this.FlippingRibbonItem,
            this.OtherTabItem,
            this.Settings});
            this.MainRibbonControl.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.MainRibbonControl.Location = new System.Drawing.Point(5, 1);
            this.MainRibbonControl.MouseWheelTabScrollEnabled = false;
            this.MainRibbonControl.Name = "MainRibbonControl";
            this.MainRibbonControl.Size = new System.Drawing.Size(491, 422);
            this.MainRibbonControl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MainRibbonControl.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.MainRibbonControl.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.MainRibbonControl.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.MainRibbonControl.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.MainRibbonControl.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.MainRibbonControl.SystemText.QatDialogAddButton = "&Add >>";
            this.MainRibbonControl.SystemText.QatDialogCancelButton = "Cancel";
            this.MainRibbonControl.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.MainRibbonControl.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.MainRibbonControl.SystemText.QatDialogOkButton = "OK";
            this.MainRibbonControl.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.MainRibbonControl.SystemText.QatDialogRemoveButton = "&Remove";
            this.MainRibbonControl.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.MainRibbonControl.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.MainRibbonControl.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.MainRibbonControl.TabGroupHeight = 14;
            this.MainRibbonControl.TabIndex = 9;
            this.MainRibbonControl.Text = "MainRibbonControl";
            // 
            // OtherPanel
            // 
            this.OtherPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.OtherPanel.Controls.Add(this.OtherRibbonBar);
            this.OtherPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OtherPanel.Location = new System.Drawing.Point(0, 56);
            this.OtherPanel.Name = "OtherPanel";
            this.OtherPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.OtherPanel.Size = new System.Drawing.Size(491, 366);
            this.OtherPanel.StretchLastRibbonBar = true;
            // 
            // 
            // 
            this.OtherPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.OtherPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.OtherPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OtherPanel.TabIndex = 3;
            this.OtherPanel.Visible = false;
            // 
            // OtherRibbonBar
            // 
            this.OtherRibbonBar.AntiAlias = false;
            this.OtherRibbonBar.AutoOverflowEnabled = false;
            // 
            // 
            // 
            this.OtherRibbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.OtherRibbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OtherRibbonBar.ContainerControlProcessDialogKey = true;
            this.OtherRibbonBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.OtherRibbonBar.DragDropSupport = true;
            this.OtherRibbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.PrimaryOtherContainer});
            this.OtherRibbonBar.Location = new System.Drawing.Point(3, 0);
            this.OtherRibbonBar.Name = "OtherRibbonBar";
            this.OtherRibbonBar.Size = new System.Drawing.Size(503, 364);
            this.OtherRibbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.OtherRibbonBar.TabIndex = 0;
            // 
            // 
            // 
            this.OtherRibbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.OtherRibbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // PrimaryOtherContainer
            // 
            // 
            // 
            // 
            this.PrimaryOtherContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PrimaryOtherContainer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.PrimaryOtherContainer.Name = "PrimaryOtherContainer";
            this.PrimaryOtherContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.SkillsContainer,
            this.NonSkillOrientedCreations,
            this.ShopAbuse});
            // 
            // 
            // 
            this.PrimaryOtherContainer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // SkillsContainer
            // 
            // 
            // 
            // 
            this.SkillsContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SkillsContainer.MultiLine = true;
            this.SkillsContainer.Name = "SkillsContainer";
            this.SkillsContainer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.All,
            this.Cooking,
            this.Construction,
            this.Crafting,
            this.Farming,
            this.Fletching,
            this.Herblore,
            this.Magic,
            this.Prayer,
            this.Runecrafting,
            this.Smithing,
            this.Favorites});
            // 
            // 
            // 
            this.SkillsContainer.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.SkillsContainer.TitleStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveBorder;
            this.SkillsContainer.TitleStyle.BorderBottomWidth = 1;
            this.SkillsContainer.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.SkillsContainer.TitleStyle.BorderTopColor = System.Drawing.SystemColors.ActiveBorder;
            this.SkillsContainer.TitleStyle.BorderTopWidth = 1;
            this.SkillsContainer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SkillsContainer.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.SkillsContainer.TitleText = "Skill Oriented Creation";
            // 
            // All
            // 
            this.All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.All.Image = global::MarketAbuseRevamped.Properties.Resources.Stats_icon;
            this.All.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.All.Name = "All";
            this.All.Text = "All";
            this.All.Click += new System.EventHandler(this.All_Click);
            // 
            // Cooking
            // 
            this.Cooking.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Cooking.Image = global::MarketAbuseRevamped.Properties.Resources.Cooking_icon_png;
            this.Cooking.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Cooking.Name = "Cooking";
            this.Cooking.Text = "Cooking";
            this.Cooking.Click += new System.EventHandler(this.Cooking_Click);
            // 
            // Construction
            // 
            this.Construction.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Construction.Image = global::MarketAbuseRevamped.Properties.Resources.Construction_icon;
            this.Construction.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Construction.Name = "Construction";
            this.Construction.Text = "Construction";
            this.Construction.Click += new System.EventHandler(this.Construction_Click);
            // 
            // Crafting
            // 
            this.Crafting.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Crafting.Image = global::MarketAbuseRevamped.Properties.Resources.Crafting_icon_png;
            this.Crafting.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Crafting.Name = "Crafting";
            this.Crafting.Text = "Crafting";
            this.Crafting.Click += new System.EventHandler(this.Crafting_Click);
            // 
            // Farming
            // 
            this.Farming.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Farming.Image = global::MarketAbuseRevamped.Properties.Resources.Farming_icon_png;
            this.Farming.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Farming.Name = "Farming";
            this.Farming.Text = "Farming";
            this.Farming.Click += new System.EventHandler(this.Farming_Click);
            // 
            // Fletching
            // 
            this.Fletching.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Fletching.Image = global::MarketAbuseRevamped.Properties.Resources.Fletching_icon_png;
            this.Fletching.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Fletching.Name = "Fletching";
            this.Fletching.Text = "Fletching";
            this.Fletching.Click += new System.EventHandler(this.Fletching_Click);
            // 
            // Herblore
            // 
            this.Herblore.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Herblore.Image = global::MarketAbuseRevamped.Properties.Resources.Herblore_icon_png;
            this.Herblore.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Herblore.Name = "Herblore";
            this.Herblore.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BarbarianMix,
            this.Decanting,
            this.HerbCleaning,
            this.PotionMaking,
            this.UnfPotions});
            this.Herblore.Text = "Herblore";
            this.Herblore.Click += new System.EventHandler(this.Herblore_Click);
            // 
            // BarbarianMix
            // 
            this.BarbarianMix.Name = "BarbarianMix";
            this.BarbarianMix.Text = "Barbarian Mix";
            this.BarbarianMix.Click += new System.EventHandler(this.BarbarianMix_Click_1);
            // 
            // Decanting
            // 
            this.Decanting.Name = "Decanting";
            this.Decanting.Text = "Decanting";
            this.Decanting.Click += new System.EventHandler(this.Decanting_Click);
            // 
            // HerbCleaning
            // 
            this.HerbCleaning.Name = "HerbCleaning";
            this.HerbCleaning.Text = "Herb Cleaning";
            this.HerbCleaning.Click += new System.EventHandler(this.HerbCleaning_Click);
            // 
            // PotionMaking
            // 
            this.PotionMaking.Name = "PotionMaking";
            this.PotionMaking.Text = "Potion Making";
            this.PotionMaking.Click += new System.EventHandler(this.PotionMaking_Click);
            // 
            // UnfPotions
            // 
            this.UnfPotions.Name = "UnfPotions";
            this.UnfPotions.Text = "Unfinished Potions";
            this.UnfPotions.Click += new System.EventHandler(this.UnfPotions_Click);
            // 
            // Magic
            // 
            this.Magic.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Magic.Image = global::MarketAbuseRevamped.Properties.Resources.Magic_icon_png;
            this.Magic.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Magic.Name = "Magic";
            this.Magic.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Enchanting,
            this.HighAlchemy,
            this.LowAlchemy,
            this.OtherMagic});
            this.Magic.Text = "Magic";
            this.Magic.Click += new System.EventHandler(this.Magic_Click);
            // 
            // Enchanting
            // 
            this.Enchanting.Name = "Enchanting";
            this.Enchanting.Text = "Enchanting";
            this.Enchanting.Click += new System.EventHandler(this.Enchanting_Click);
            // 
            // HighAlchemy
            // 
            this.HighAlchemy.Name = "HighAlchemy";
            this.HighAlchemy.Text = "High Alchemy";
            this.HighAlchemy.Click += new System.EventHandler(this.HighAlchemy_Click);
            // 
            // LowAlchemy
            // 
            this.LowAlchemy.Name = "LowAlchemy";
            this.LowAlchemy.Text = "Low Alchemy";
            this.LowAlchemy.Click += new System.EventHandler(this.LowAlchemy_Click);
            // 
            // OtherMagic
            // 
            this.OtherMagic.Name = "OtherMagic";
            this.OtherMagic.Text = "Other";
            this.OtherMagic.Click += new System.EventHandler(this.OtherMagic_Click);
            // 
            // Prayer
            // 
            this.Prayer.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Prayer.Image = global::MarketAbuseRevamped.Properties.Resources.Prayer_icon_png;
            this.Prayer.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Prayer.Name = "Prayer";
            this.Prayer.Text = "Prayer";
            this.Prayer.Click += new System.EventHandler(this.Prayer_Click);
            // 
            // Runecrafting
            // 
            this.Runecrafting.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Runecrafting.Image = global::MarketAbuseRevamped.Properties.Resources.Runecrafting_icon_png;
            this.Runecrafting.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Runecrafting.Name = "Runecrafting";
            this.Runecrafting.Text = "Runecrafting";
            this.Runecrafting.Click += new System.EventHandler(this.Runecrafting_Click);
            // 
            // Smithing
            // 
            this.Smithing.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Smithing.Image = global::MarketAbuseRevamped.Properties.Resources.Smithing_icon_png;
            this.Smithing.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Smithing.Name = "Smithing";
            this.Smithing.Text = "Smithing";
            this.Smithing.Click += new System.EventHandler(this.Smithing_Click_1);
            // 
            // Favorites
            // 
            this.Favorites.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Favorites.Image = global::MarketAbuseRevamped.Properties.Resources.P2P_icon;
            this.Favorites.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Favorites.Name = "Favorites";
            this.Favorites.Text = "Favorites";
            this.Favorites.Click += new System.EventHandler(this.Favorites_Click);
            // 
            // NonSkillOrientedCreations
            // 
            // 
            // 
            // 
            this.NonSkillOrientedCreations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NonSkillOrientedCreations.Name = "NonSkillOrientedCreations";
            this.NonSkillOrientedCreations.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Poison,
            this.Sets,
            this.Unknown});
            // 
            // 
            // 
            this.NonSkillOrientedCreations.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.NonSkillOrientedCreations.TitleStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveBorder;
            this.NonSkillOrientedCreations.TitleStyle.BorderBottomWidth = 1;
            this.NonSkillOrientedCreations.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.NonSkillOrientedCreations.TitleStyle.BorderTopColor = System.Drawing.SystemColors.ActiveBorder;
            this.NonSkillOrientedCreations.TitleStyle.BorderTopWidth = 1;
            this.NonSkillOrientedCreations.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NonSkillOrientedCreations.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.NonSkillOrientedCreations.TitleText = "Non-Skill Oriented Creations";
            // 
            // Poison
            // 
            this.Poison.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Poison.Image = global::MarketAbuseRevamped.Properties.Resources.Poison_hitsplat;
            this.Poison.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Poison.Name = "Poison";
            this.Poison.Text = "Poison";
            this.Poison.Click += new System.EventHandler(this.Poison_Click);
            // 
            // Sets
            // 
            this.Sets.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Sets.Image = global::MarketAbuseRevamped.Properties.Resources.Sets;
            this.Sets.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Sets.Name = "Sets";
            this.Sets.Text = "Sets";
            this.Sets.Click += new System.EventHandler(this.Sets_Click);
            // 
            // Unknown
            // 
            this.Unknown.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Unknown.Image = global::MarketAbuseRevamped.Properties.Resources.Unknown;
            this.Unknown.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.Unknown.Name = "Unknown";
            this.Unknown.Text = "Unknown";
            this.Unknown.Click += new System.EventHandler(this.Unknown_Click);
            // 
            // ShopAbuse
            // 
            // 
            // 
            // 
            this.ShopAbuse.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ShopAbuse.Name = "ShopAbuse";
            this.ShopAbuse.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.GeneralStore,
            this.KaramjaStore,
            this.SellToGE});
            // 
            // 
            // 
            this.ShopAbuse.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ShopAbuse.TitleStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveBorder;
            this.ShopAbuse.TitleStyle.BorderBottomWidth = 1;
            this.ShopAbuse.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ShopAbuse.TitleStyle.BorderTopColor = System.Drawing.SystemColors.ActiveBorder;
            this.ShopAbuse.TitleStyle.BorderTopWidth = 1;
            this.ShopAbuse.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ShopAbuse.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.ShopAbuse.TitleText = "Shop Abuse";
            // 
            // GeneralStore
            // 
            this.GeneralStore.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.GeneralStore.Image = global::MarketAbuseRevamped.Properties.Resources.General_store_icon;
            this.GeneralStore.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.GeneralStore.Name = "GeneralStore";
            this.GeneralStore.Text = "Sell to General Store";
            this.GeneralStore.Click += new System.EventHandler(this.GeneralStore_Click);
            // 
            // KaramjaStore
            // 
            this.KaramjaStore.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.KaramjaStore.Image = global::MarketAbuseRevamped.Properties.Resources.General_store_icon;
            this.KaramjaStore.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.KaramjaStore.Name = "KaramjaStore";
            this.KaramjaStore.Text = "Sell to Karamja Store";
            this.KaramjaStore.Click += new System.EventHandler(this.KaramjaStore_Click);
            // 
            // SellToGE
            // 
            this.SellToGE.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.SellToGE.Image = global::MarketAbuseRevamped.Properties.Resources.Coins_detail;
            this.SellToGE.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.SellToGE.Name = "SellToGE";
            this.SellToGE.Text = "Sell to Grand Exchange";
            this.SellToGE.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // FlippingPanel
            // 
            this.FlippingPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlippingPanel.Controls.Add(this.AlchemyValues);
            this.FlippingPanel.Controls.Add(this.ActiveFlipsGroupBox);
            this.FlippingPanel.Controls.Add(this.sortComboBox);
            this.FlippingPanel.Controls.Add(this.itemList);
            this.FlippingPanel.Controls.Add(this.searchTextbox);
            this.FlippingPanel.Controls.Add(this.Search);
            this.FlippingPanel.Controls.Add(this.itemDataGroupBox);
            this.FlippingPanel.Controls.Add(this.sortLabel);
            this.FlippingPanel.Controls.Add(this.lastUpdated);
            this.FlippingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlippingPanel.Location = new System.Drawing.Point(0, 56);
            this.FlippingPanel.Name = "FlippingPanel";
            this.FlippingPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.FlippingPanel.Size = new System.Drawing.Size(491, 366);
            // 
            // 
            // 
            this.FlippingPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.FlippingPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.FlippingPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FlippingPanel.TabIndex = 2;
            // 
            // AlchemyValues
            // 
            this.AlchemyValues.Controls.Add(this.GeneralStoreLabel);
            this.AlchemyValues.Controls.Add(this.KaramjaStoreLabel);
            this.AlchemyValues.Controls.Add(this.LowAlchLabel);
            this.AlchemyValues.Controls.Add(this.HighAlchLabel);
            this.AlchemyValues.Location = new System.Drawing.Point(186, 157);
            this.AlchemyValues.Name = "AlchemyValues";
            this.AlchemyValues.Size = new System.Drawing.Size(217, 88);
            this.AlchemyValues.TabIndex = 14;
            this.AlchemyValues.TabStop = false;
            this.AlchemyValues.Text = "Alchemy Values";
            // 
            // GeneralStoreLabel
            // 
            this.GeneralStoreLabel.AutoSize = true;
            this.GeneralStoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.GeneralStoreLabel.Location = new System.Drawing.Point(6, 70);
            this.GeneralStoreLabel.Name = "GeneralStoreLabel";
            this.GeneralStoreLabel.Size = new System.Drawing.Size(75, 13);
            this.GeneralStoreLabel.TabIndex = 16;
            this.GeneralStoreLabel.Text = "General Store:";
            // 
            // KaramjaStoreLabel
            // 
            this.KaramjaStoreLabel.AutoSize = true;
            this.KaramjaStoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.KaramjaStoreLabel.Location = new System.Drawing.Point(6, 52);
            this.KaramjaStoreLabel.Name = "KaramjaStoreLabel";
            this.KaramjaStoreLabel.Size = new System.Drawing.Size(76, 13);
            this.KaramjaStoreLabel.TabIndex = 15;
            this.KaramjaStoreLabel.Text = "Karamja Store:";
            // 
            // LowAlchLabel
            // 
            this.LowAlchLabel.AutoSize = true;
            this.LowAlchLabel.BackColor = System.Drawing.Color.Transparent;
            this.LowAlchLabel.Location = new System.Drawing.Point(6, 34);
            this.LowAlchLabel.Name = "LowAlchLabel";
            this.LowAlchLabel.Size = new System.Drawing.Size(54, 13);
            this.LowAlchLabel.TabIndex = 14;
            this.LowAlchLabel.Text = "Low Alch:";
            // 
            // HighAlchLabel
            // 
            this.HighAlchLabel.AutoSize = true;
            this.HighAlchLabel.BackColor = System.Drawing.Color.Transparent;
            this.HighAlchLabel.Location = new System.Drawing.Point(6, 16);
            this.HighAlchLabel.Name = "HighAlchLabel";
            this.HighAlchLabel.Size = new System.Drawing.Size(56, 13);
            this.HighAlchLabel.TabIndex = 13;
            this.HighAlchLabel.Text = "High Alch:";
            // 
            // ActiveFlipsGroupBox
            // 
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem12);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem11);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem10);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem9);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem8);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem7);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem6);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem5);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem4);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem3);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem2);
            this.ActiveFlipsGroupBox.Controls.Add(this.FlipItem1);
            this.ActiveFlipsGroupBox.Location = new System.Drawing.Point(409, 4);
            this.ActiveFlipsGroupBox.Name = "ActiveFlipsGroupBox";
            this.ActiveFlipsGroupBox.Size = new System.Drawing.Size(82, 268);
            this.ActiveFlipsGroupBox.TabIndex = 10;
            this.ActiveFlipsGroupBox.TabStop = false;
            this.ActiveFlipsGroupBox.Text = "Active Flips";
            // 
            // FlipItem12
            // 
            this.FlipItem12.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem12.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem12.Location = new System.Drawing.Point(44, 221);
            this.FlipItem12.Name = "FlipItem12";
            this.FlipItem12.Size = new System.Drawing.Size(34, 32);
            this.FlipItem12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem12.TabIndex = 20;
            // 
            // FlipItem11
            // 
            this.FlipItem11.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem11.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem11.Location = new System.Drawing.Point(44, 179);
            this.FlipItem11.Name = "FlipItem11";
            this.FlipItem11.Size = new System.Drawing.Size(34, 32);
            this.FlipItem11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem11.TabIndex = 19;
            // 
            // FlipItem10
            // 
            this.FlipItem10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem10.Location = new System.Drawing.Point(44, 139);
            this.FlipItem10.Name = "FlipItem10";
            this.FlipItem10.Size = new System.Drawing.Size(34, 32);
            this.FlipItem10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem10.TabIndex = 18;
            // 
            // FlipItem9
            // 
            this.FlipItem9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem9.Location = new System.Drawing.Point(44, 99);
            this.FlipItem9.Name = "FlipItem9";
            this.FlipItem9.Size = new System.Drawing.Size(34, 32);
            this.FlipItem9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem9.TabIndex = 17;
            // 
            // FlipItem8
            // 
            this.FlipItem8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem8.Location = new System.Drawing.Point(44, 59);
            this.FlipItem8.Name = "FlipItem8";
            this.FlipItem8.Size = new System.Drawing.Size(34, 32);
            this.FlipItem8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem8.TabIndex = 16;
            // 
            // FlipItem7
            // 
            this.FlipItem7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem7.Location = new System.Drawing.Point(44, 19);
            this.FlipItem7.Name = "FlipItem7";
            this.FlipItem7.Size = new System.Drawing.Size(34, 32);
            this.FlipItem7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem7.TabIndex = 15;
            // 
            // FlipItem6
            // 
            this.FlipItem6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem6.Location = new System.Drawing.Point(6, 221);
            this.FlipItem6.Name = "FlipItem6";
            this.FlipItem6.Size = new System.Drawing.Size(34, 32);
            this.FlipItem6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem6.TabIndex = 14;
            // 
            // FlipItem5
            // 
            this.FlipItem5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem5.Location = new System.Drawing.Point(6, 179);
            this.FlipItem5.Name = "FlipItem5";
            this.FlipItem5.Size = new System.Drawing.Size(34, 32);
            this.FlipItem5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem5.TabIndex = 13;
            // 
            // FlipItem4
            // 
            this.FlipItem4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem4.Location = new System.Drawing.Point(6, 139);
            this.FlipItem4.Name = "FlipItem4";
            this.FlipItem4.Size = new System.Drawing.Size(34, 32);
            this.FlipItem4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem4.TabIndex = 12;
            // 
            // FlipItem3
            // 
            this.FlipItem3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem3.Location = new System.Drawing.Point(6, 99);
            this.FlipItem3.Name = "FlipItem3";
            this.FlipItem3.Size = new System.Drawing.Size(34, 32);
            this.FlipItem3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem3.TabIndex = 11;
            // 
            // FlipItem2
            // 
            this.FlipItem2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem2.Location = new System.Drawing.Point(6, 59);
            this.FlipItem2.Name = "FlipItem2";
            this.FlipItem2.Size = new System.Drawing.Size(34, 32);
            this.FlipItem2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem2.TabIndex = 10;
            // 
            // FlipItem1
            // 
            this.FlipItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.FlipItem1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.FlipItem1.Location = new System.Drawing.Point(6, 19);
            this.FlipItem1.Name = "FlipItem1";
            this.FlipItem1.Size = new System.Drawing.Size(34, 32);
            this.FlipItem1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.FlipItem1.TabIndex = 9;
            // 
            // sortComboBox
            // 
            this.sortComboBox.FormattingEnabled = true;
            this.sortComboBox.Items.AddRange(new object[] {
            "Alphabetize",
            "Recommended",
            "Fast Flips",
            "Large Quantity",
            "Highest Margin",
            "Favorites by Margin",
            "Favorites by Alphabet",
            "Buying Quantity",
            "Selling Quantity",
            "ID",
            "Lowest Margin"});
            this.sortComboBox.Location = new System.Drawing.Point(56, 278);
            this.sortComboBox.Name = "sortComboBox";
            this.sortComboBox.Size = new System.Drawing.Size(124, 21);
            this.sortComboBox.TabIndex = 13;
            this.sortComboBox.Text = "Alphabetize";
            this.sortComboBox.SelectedIndexChanged += new System.EventHandler(this.sortComboBox_SelectedIndexChanged);
            // 
            // itemList
            // 
            this.itemList.FormattingEnabled = true;
            this.itemList.Location = new System.Drawing.Point(3, 33);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(177, 238);
            this.itemList.TabIndex = 12;
            this.itemList.SelectedIndexChanged += new System.EventHandler(this.itemList_SelectedIndexChanged);
            this.itemList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShowFavoritesMenu);
            // 
            // searchTextbox
            // 
            this.searchTextbox.Location = new System.Drawing.Point(3, 5);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(112, 20);
            this.searchTextbox.TabIndex = 10;
            this.searchTextbox.TextChanged += new System.EventHandler(this.searchTextbox_TextChanged);
            this.searchTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBoxHandleKeyPress);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.settingsBox);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 56);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.ribbonPanel1.Size = new System.Drawing.Size(491, 366);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 4;
            this.ribbonPanel1.Visible = false;
            // 
            // settingsBox
            // 
            this.settingsBox.BackColor = System.Drawing.Color.Transparent;
            this.settingsBox.Controls.Add(this.showAlchValues);
            this.settingsBox.Controls.Add(this.THEME);
            this.settingsBox.Controls.Add(this.themeLabel);
            this.settingsBox.Controls.Add(this.moneyLimiterCheckbox);
            this.settingsBox.Controls.Add(this.moneyAvailableLabel);
            this.settingsBox.Controls.Add(this.moneyAvailable);
            this.settingsBox.Controls.Add(this.Members);
            this.settingsBox.Location = new System.Drawing.Point(3, 5);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Size = new System.Drawing.Size(217, 147);
            this.settingsBox.TabIndex = 15;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            // 
            // showAlchValues
            // 
            this.showAlchValues.AutoSize = true;
            this.showAlchValues.Location = new System.Drawing.Point(6, 42);
            this.showAlchValues.Name = "showAlchValues";
            this.showAlchValues.Size = new System.Drawing.Size(131, 17);
            this.showAlchValues.TabIndex = 6;
            this.showAlchValues.Text = "Show Alchemy Values";
            this.showAlchValues.UseVisualStyleBackColor = true;
            this.showAlchValues.CheckedChanged += new System.EventHandler(this.showAlchValues_CheckedChanged);
            // 
            // THEME
            // 
            this.THEME.FormattingEnabled = true;
            this.THEME.Items.AddRange(new object[] {
            "Metro",
            "2007Black",
            "2007Blue",
            "2007Silver",
            "2007Glass",
            "2010Black",
            "2010Blue",
            "2010Silver",
            "2013",
            "2014",
            "2016",
            "VS2010Blue",
            "VS2012Dark",
            "VS2012Light",
            "Win7Blue"});
            this.THEME.Location = new System.Drawing.Point(115, 114);
            this.THEME.Name = "THEME";
            this.THEME.Size = new System.Drawing.Size(96, 21);
            this.THEME.TabIndex = 5;
            this.THEME.Text = "2016";
            this.THEME.SelectedIndexChanged += new System.EventHandler(this.THEME_SelectedIndexChanged);
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.BackColor = System.Drawing.Color.Transparent;
            this.themeLabel.Location = new System.Drawing.Point(6, 117);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(46, 13);
            this.themeLabel.TabIndex = 4;
            this.themeLabel.Text = "Theme: ";
            // 
            // moneyLimiterCheckbox
            // 
            this.moneyLimiterCheckbox.AutoSize = true;
            this.moneyLimiterCheckbox.Location = new System.Drawing.Point(6, 65);
            this.moneyLimiterCheckbox.Name = "moneyLimiterCheckbox";
            this.moneyLimiterCheckbox.Size = new System.Drawing.Size(123, 17);
            this.moneyLimiterCheckbox.TabIndex = 3;
            this.moneyLimiterCheckbox.Text = "Set Money Available";
            this.moneyLimiterCheckbox.UseVisualStyleBackColor = true;
            this.moneyLimiterCheckbox.CheckedChanged += new System.EventHandler(this.moneyLimiterCheckbox_CheckedChanged);
            // 
            // moneyAvailableLabel
            // 
            this.moneyAvailableLabel.AutoSize = true;
            this.moneyAvailableLabel.BackColor = System.Drawing.Color.Transparent;
            this.moneyAvailableLabel.Location = new System.Drawing.Point(6, 91);
            this.moneyAvailableLabel.Name = "moneyAvailableLabel";
            this.moneyAvailableLabel.Size = new System.Drawing.Size(91, 13);
            this.moneyAvailableLabel.TabIndex = 2;
            this.moneyAvailableLabel.Text = "Money Available: ";
            // 
            // moneyAvailable
            // 
            this.moneyAvailable.Location = new System.Drawing.Point(115, 89);
            this.moneyAvailable.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.moneyAvailable.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.moneyAvailable.Name = "moneyAvailable";
            this.moneyAvailable.Size = new System.Drawing.Size(96, 20);
            this.moneyAvailable.TabIndex = 1;
            this.moneyAvailable.Value = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.moneyAvailable.ValueChanged += new System.EventHandler(this.moneyAvailable_ValueChanged);
            // 
            // Members
            // 
            this.Members.AutoSize = true;
            this.Members.Checked = true;
            this.Members.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Members.Location = new System.Drawing.Point(6, 19);
            this.Members.Name = "Members";
            this.Members.Size = new System.Drawing.Size(120, 17);
            this.Members.TabIndex = 0;
            this.Members.Text = "Allow Member Items";
            this.Members.UseVisualStyleBackColor = true;
            this.Members.CheckedChanged += new System.EventHandler(this.Members_CheckedChanged);
            // 
            // FileButton
            // 
            this.FileButton.AutoExpandOnClick = true;
            this.FileButton.CanCustomize = false;
            this.FileButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.FileButton.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.FileButton.ImagePaddingHorizontal = 0;
            this.FileButton.ImagePaddingVertical = 1;
            this.FileButton.Name = "FileButton";
            this.FileButton.ShowSubItems = false;
            this.FileButton.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Credits,
            this.HelpButton});
            this.FileButton.Text = "File";
            // 
            // Credits
            // 
            this.Credits.Name = "Credits";
            this.Credits.Text = "Credits";
            this.Credits.Click += new System.EventHandler(this.Credits_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ActiveFlipsHelp,
            this.CreationHelp,
            this.FlippingHelp});
            this.HelpButton.Text = "Help";
            // 
            // ActiveFlipsHelp
            // 
            this.ActiveFlipsHelp.Name = "ActiveFlipsHelp";
            this.ActiveFlipsHelp.Text = "Active Flips";
            this.ActiveFlipsHelp.Click += new System.EventHandler(this.ActiveFlipsHelp_Click);
            // 
            // CreationHelp
            // 
            this.CreationHelp.Name = "CreationHelp";
            this.CreationHelp.Text = "Creation Help";
            this.CreationHelp.Click += new System.EventHandler(this.CreationHelp_Click);
            // 
            // FlippingHelp
            // 
            this.FlippingHelp.Name = "FlippingHelp";
            this.FlippingHelp.Text = "Flipping Help";
            this.FlippingHelp.Click += new System.EventHandler(this.FlippingHelp_Click);
            // 
            // FlippingRibbonItem
            // 
            this.FlippingRibbonItem.Checked = true;
            this.FlippingRibbonItem.Name = "FlippingRibbonItem";
            this.FlippingRibbonItem.Panel = this.FlippingPanel;
            this.FlippingRibbonItem.Text = "Flipping";
            // 
            // OtherTabItem
            // 
            this.OtherTabItem.Name = "OtherTabItem";
            this.OtherTabItem.Panel = this.OtherPanel;
            this.OtherTabItem.Text = "Other";
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Panel = this.ribbonPanel1;
            this.Settings.Text = "Settings";
            // 
            // Style
            // 
            this.Style.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.Style.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 372);
            this.Controls.Add(this.MainRibbonControl);
            this.EnableGlass = false;
            this.FlattenMDIBorder = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Market Abuse Revamped";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.itemDataGroupBox.ResumeLayout(false);
            this.itemDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ITEMPICTURE)).EndInit();
            this.MainRibbonControl.ResumeLayout(false);
            this.MainRibbonControl.PerformLayout();
            this.OtherPanel.ResumeLayout(false);
            this.FlippingPanel.ResumeLayout(false);
            this.FlippingPanel.PerformLayout();
            this.AlchemyValues.ResumeLayout(false);
            this.AlchemyValues.PerformLayout();
            this.ActiveFlipsGroupBox.ResumeLayout(false);
            this.ribbonPanel1.ResumeLayout(false);
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyAvailable)).EndInit();
            this.ResumeLayout(false);

		}
	}
}
