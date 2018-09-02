using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net;

//incorporate https://api.rsbuddy.com/grandExchange?a=guidePrice&i=2&i=6&i=8&i=10 with UpdateItemAdvancedData when opening program. (creation form)

namespace MarketAbuse
{
    public partial class MarketAbuse : Form
    {
        public static List<Item> ItemList = new List<Item>();
        public static List<Item> FavoriteItemList = new List<Item>();
        public static List<CreationProcess> FavoriteProcessList = new List<CreationProcess>();
        public static ContextMenuStrip cm = new ContextMenuStrip();
        public ListBox selectedListbox;
        public PossibleCreations processClass;
        public static Form SecondForm;

        public MarketAbuse()
        {
            InitializeComponent();
            UpdateGEInformation();
            button2_Click_1(null, null);
            marginValue.Text = "";
            processClass = new PossibleCreations();

            cm.Items.Add("Refresh").MouseDown += new MouseEventHandler(refreshItemToolStripMenuItem_Click);
            cm.Items.Add("Favorite").MouseDown += new MouseEventHandler(favoriteItemToolStripMenuItem_Click);

            foreach(ToolStripDropDownButton tsi in toolStrip1.Items)
                foreach(ToolStripMenuItem s in tsi.DropDownItems)
                    s.Click += new EventHandler(updateCreationProcessListing);

            FavoriteLoader();
        }

        private void updateCreationProcessListing(object sender, EventArgs args)
        {
            processClass = new PossibleCreations();
        }
        private void FavoriteLoader()
        {
            if (!File.Exists("Favorites.txt"))
                return;

            StreamReader sr = new StreamReader("Favorites.txt");
            string mainPageFavoriteList = sr.ReadLine();
            string CreationProcessFavoriteList = sr.ReadLine();
            sr.Close();

            if (mainPageFavoriteList == null || CreationProcessFavoriteList == null)
                return;

            string[] itemIDList = mainPageFavoriteList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in itemIDList)
                if (s != "")
                    FavoriteItemList.Add(GetItem(Convert.ToInt32(s)));


            string[] CreationProcess = CreationProcessFavoriteList.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in CreationProcess)
            {
                string[] itemGroups = s.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < itemGroups.Length; i = i + 2)
                {
                    string[] itemsNeeded = itemGroups[i].Split(',');
                    string[] completedItems = itemGroups[i+1].Split(',');
                    List<int> itemNeededIDArray = new List<int>();
                    List<int> completedItemIDArray = new List<int>();

                    foreach (string st in itemsNeeded)
                        itemNeededIDArray.Add(int.Parse(st));
                    foreach (string st in completedItems)
                        completedItemIDArray.Add(int.Parse(st));

                    FavoriteProcessList.Add(processClass.GetCreationProcess(itemNeededIDArray, completedItemIDArray));
                }
            }
        }
        private void FavoriteWriter()
        {
            StreamWriter sw = new StreamWriter("Favorites.txt");
            foreach (Item i in FavoriteItemList)
                sw.Write(i.id + ",");
            sw.WriteLine();
            foreach(CreationProcess cp in FavoriteProcessList)
            {
                string itemsNeeded = "";
                foreach (Item i in cp.itemsNeeded)
                    itemsNeeded += i.id + ",";
                string completedItems = "";
                foreach (Item i in cp.completedItems)
                    completedItems += i.id + ",";
                itemsNeeded = itemsNeeded.Remove(itemsNeeded.LastIndexOf(','), 1);
                completedItems = completedItems.Remove(completedItems.LastIndexOf(','), 1);

                sw.Write("[{" + itemsNeeded + "}{" + completedItems + "}]");
            }
            sw.Flush();
            sw.Close();
        }
        public void listBoxSnap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            selectedListbox = ((ListBox)sender);
            selectedListbox.SelectedIndex = selectedListbox.IndexFromPoint(e.Location);

            if (selectedListbox.SelectedIndex == -1)
                return;

            Rectangle r = selectedListbox.GetItemRectangle(selectedListbox.SelectedIndex);
            if (r.Contains(e.Location))
            {
                cm.Items[1].Text = "Favorite";
                if (ActiveForm.Name == "MarketAbuse")
                {
                    foreach (Item i in FavoriteItemList)
                        if (i.id == GetItem(selectedListbox.SelectedItem.ToString()).id)
                        {
                            cm.Items[1].Text = "Unfavorite";
                        }
                }
                else if (ActiveForm.Name == "CreationForm")
                {
                    CreationProcess item = (selectedListbox.SelectedItem as CreationProcess);

                    for (int o = 0; o < FavoriteProcessList.Count(); o++)
                    {
                        string itemIDList = "";
                        string itemIDList2 = "";

                        foreach (Item i in FavoriteProcessList[o].itemsNeeded)
                            itemIDList += i.id + ",";
                        foreach (Item i in item.itemsNeeded)
                            itemIDList2 += i.id + ",";
                        string completedItemList = "";
                        string completedItemList2 = "";
                        foreach (Item i in FavoriteProcessList[o].completedItems)
                            completedItemList += i.id + ",";
                        foreach (Item i in item.completedItems)
                            completedItemList2 += i.id + ",";

                        if (itemIDList == itemIDList2
                            && completedItemList == completedItemList2)
                        {
                            cm.Items[1].Text = "Unfavorite";
                            break;
                        }
                    }
                }

                cm.Show(selectedListbox, e.Location);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateGEInformation();

            Item itemBeingLookedFor = GetItem(GetFriendlyName(directLookupTextbox.Text), priceLimit.Value, members.Checked);

            if (itemBeingLookedFor == null || itemBeingLookedFor.name == "")
                MessageBox.Show("Unable to find item: " + directLookupTextbox.Text);
            else
                UpdateItemListing(itemBeingLookedFor);
                
        }
        public static void UpdateGEInformation()
        {
            //download
            DownloadFile("https://rsbuddy.com/exchange/summary.json", "OSBuddy.txt");

            //update array
            StreamReader sr = new StreamReader("OSBuddy.txt");
            string allinfo = sr.ReadToEnd();
            sr.Close();
            string[] items = allinfo.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            int sizeOfArray = items.Length;
            int currentIndex = 0;

            for (int i = 0; i < items.Length; i++)
                if (!items[i].Contains("name"))
                {
                    items[i] = "";
                    sizeOfArray--;
                }

            //cut out useless info
            string[] cutItemList = new string[sizeOfArray];
            foreach (string s in items)
                if (s != "")
                {
                    cutItemList[currentIndex] = s;
                    currentIndex++;
                }

            ItemList.Clear();
            foreach (string s in cutItemList)
            {
                ItemList.Add(new Item(s));
            }
        }
        public static void DownloadFile(string remoteFilename, string localFilename)
        {
            WebClient client = new WebClient();
            client.DownloadFile(remoteFilename, localFilename);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateGEInformation();
            itemlistbox.Items.Clear();

            ArrayList possibleItemList = GetItemList(GetFriendlyName(itemLookupTextbox.Text), members.Checked);
            foreach (Item i in possibleItemList)
            {
                itemlistbox.Items.Add(i.name);
            }
        }
        public void UpdateItemListing(Item item)  
        {
            item.UpdateItemData();
            item.UpdateItemAdvancedData();

            avgbuy.Text = "Average Buy: " + item.buyPrice.ToString("#,##0");
            avgsell.Text = "Average Sell: " + item.sellPrice.ToString("#,##0");
            avgoverall.Text = "Average Overall: " + item.overallPrice.ToString("#,##0");
            buyquantity.Text = "Buying Quantity: " + item.buyQuantity.ToString("#,##0");
            sellquantity.Text = "Selling Quantity: " + item.sellQuantity.ToString("#,##0");
            name.Text = "Name: " + item.name;

            marginValue.Text = item.margin.ToString("#,##0");
            if (item.margin > 0)
                marginValue.ForeColor = Color.Green;
            else if (item.margin == 0)
                marginValue.ForeColor = SystemColors.ControlText;
            else if (item.margin < 0)
                marginValue.ForeColor = Color.Red;

            pictureBox1.Load("http://cdn.rsbuddy.com/items/" + item.id + ".png");
        }
        public static Item GetItem(string name, decimal priceLimit = 2147483647, bool member = true)
        {
            Item it = null;
            if (name.ToLower().Contains("coins") || name.ToLower().Contains("coin"))
                it = new Item("{\"members\": false, \"sell_average\": 1, \"id\": 995, \"overall_average\": 1, \"name\": \"Coins\", \"buy_average\": 1, \"sp\": 5}");

            foreach (Item i in ItemList)
                if (i.name.ToLower() == name.ToLower() && i.buyPrice <= priceLimit && (member || !i.members))
                        it = new Item(i.information);
            return it;
        }
        public static Item GetItem(string name, int quantity)
        {
            Item i = new Item(GetItem(name).information);
            if(i != null)
                i.quantity = quantity;
            return i;
        }
        public static Item GetItem(int id, int quantity = 0)
        {
            Item item = null;
            if (id == 995)
                item = new Item("{\"members\": false, \"sell_average\": 1, \"id\": 995, \"overall_average\": 1, \"name\": \"Coins\", \"buy_average\": 1, \"sp\": 5}");

            foreach (Item i in ItemList)
                if (i.id == id)
                    item = new Item(i.information);
            if (quantity != 0)
                item.quantity = quantity;
            else
                item.quantity = 1;
            return item;
        }
        private ArrayList GetItemList(string name, bool member = true)
        {
            ArrayList temp = new ArrayList();
            foreach (Item i in ItemList)
                if (i.name.ToLower().Contains(name.ToLower()) && i.buyPrice <= priceLimit.Value && (member || !i.members))
                        temp.Add(i);
            return temp;
        }
        public static string GetFriendlyName(string name)
        {
            if (name.ToLower() == "dfs")
                name = "Dragonfire Shield";
            else if (name.ToLower() == "ags")
                name = "Armadyl Godsword";
            else if (name.ToLower() == "sgs")
                name = "Saradomin Godsword";
            else if (name.ToLower() == "zgs")
                name = "Zamorak Godsword";
            else if (name.ToLower() == "bgs")
                name = "Bandos Godsword";
            else if (name.ToLower() == "whip")
                name = "Abyssal Whip";
            else if (name.ToLower() == "row")
                name = "Ring of Wealth";
            else if (name.ToLower() == "tbp")
                name = "blowpipe";
            else if (name.ToLower() == "acp")
                name = "Armadyl Chestplate";
            else if (name.ToLower() == "acb")
                name = "Armadyl Crossbow";
            else if (name.ToLower() == "bcp")
                name = "Bandos Chestplate";
            else if (name.ToLower() == "bring")
                name = "Berserker Ring";
            else if (name.ToLower() == "tassets" || name.ToLower() == "tassies")
                name = "Bandos Tassets";
            else if (name.ToLower() == "serp")
                name = "Serpentine";
            else if (name.ToLower() == "nats")
                name = "Nature Rune";
            else if (name.ToLower() == "cballs")
                name = "Cannonball";
            else if (name.ToLower() == "dds")
                name = "Dragon dagger";
            else if (name.ToLower() == "dspear")
                name = "Dragon spear";
            else if (name.ToLower() == "sotd")
                name = "Staff of the Dead";
            else if (name.ToLower() == "rcb")
                name = "Rune Crossbow";

            return name;
        }
        private void listBox1_DoubleClicked(object sender, EventArgs e)
        {
            if(((ListBox)sender).SelectedItem != null)
            {
                UpdateGEInformation();
                UpdateItemListing(GetItem(GetFriendlyName(((ListBox)sender).SelectedItem.ToString()), priceLimit.Value));
            }
        }
        private void marginupdate_Click(object sender, EventArgs e)
        {
            UpdateGEInformation();

            IOrderedEnumerable<Item> marginList = ItemList.Where(a => a.sellPrice != a.margin && (members.Checked || !a.members) && a.buyPrice <= priceLimit.Value).OrderByDescending(a => a.margin);

            marginlistbox.Items.Clear();
            for (int i = 0; i < 100; i++)
                marginlistbox.Items.Add(marginList.ElementAt(i).name);
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was created by Sicryption.");
        }
        private void oSBuddyExchangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://rsbuddy.com/exchange");
        }
        private void StartNewForm(Form form)
        {
            if (SecondForm != null)
                SecondForm.Close();
            SecondForm = form;
            form.Show();
        }
        private void listboxSearchbox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click_1(this, new EventArgs());
            }
        }
        private void directSearchbox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
        private void herbCleaningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Herb Cleaning", processClass.HerbCleaning, this));
        }
        private void alterationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Alterations", processClass.Alterations, this));
        }
        private void fletchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Fletching", processClass.Fletching, this));
        }
        private void craftingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Crafting", processClass.Crafting, this));
        }
        private void magicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Magic", processClass.Magic, this));
        }
        private void smithingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Smithing", processClass.Smithing, this));
        }
        private void prayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Prayer", processClass.Prayer, this));
        }
        private void runecraftingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Runecrafting", processClass.Runecrafting, this));
        }
        private void farmingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Farming", processClass.Farming, this));
        }
        public void refreshItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateItemListing(GetItem(selectedListbox.SelectedItem.ToString()));
        }
        private void favoriteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveForm.Name == "MarketAbuse")
            {
                Item item = GetItem(selectedListbox.SelectedItem.ToString());

                if (cm.Items[1].Text == "Favorite")
                    FavoriteItemList.Add(item);
                else if (cm.Items[1].Text == "Unfavorite")
                {
                    int itemIndex = 0;
                    for (int o = 0; o < FavoriteItemList.Count(); o++)
                        if (FavoriteItemList[o].id == item.id)
                            itemIndex = o;
                    FavoriteItemList.RemoveAt(itemIndex);
                }
            }
            else if (ActiveForm.Name == "CreationForm")
            {
                CreationProcess item = (selectedListbox.SelectedItem as CreationProcess);

                if (cm.Items[1].Text == "Favorite")
                    FavoriteProcessList.Add(item);
                else if (cm.Items[1].Text == "Unfavorite")
                {
                    int itemIndex = 0;
                    for (int o = 0; o < FavoriteProcessList.Count(); o++)
                        foreach (Item i in FavoriteProcessList[o].itemsNeeded)
                            foreach (Item it in item.itemsNeeded)
                                if (i.id == it.id)
                                    itemIndex = o;
                    FavoriteProcessList.RemoveAt(itemIndex);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UpdateGEInformation();

            List<Item> marginList = FavoriteItemList;

            marginlistbox.Items.Clear();
            for (int i = 0; i < marginList.Count(); i++)
                marginlistbox.Items.Add(marginList.ElementAt(i).name);
        }
        private void favoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Favorites", FavoriteProcessList, this));
        }

        private void poisonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Poisons", processClass.Poisons, this));
        }

        private void setsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Sets", processClass.Sets, this));
        }

        private void constructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Construction", processClass.Construction, this));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*UpdateGEInformation();

            List<Item> marginList = ItemList.Where(a => a.sellPrice != a.margin &&
            (members.Checked || !a.members) && (a.buyQuantity >= 20 || a.sellQuantity >= 20) 
            && a.buyPrice <= priceLimit.Value)
            .OrderByDescending(a => a.margin).ToList();

            marginlistbox.Items.Clear();
            foreach(Item i in marginList)
                marginlistbox.Items.Add(i);*/
            string itemIDURL = "https://api.rsbuddy.com/grandExchange?a=guidePrice";
            foreach(Item i in ItemList)
            {
                itemIDURL += "&i=" + i.id;
            }
            MessageBox.Show(ItemList.Count.ToString());
            DownloadFile(itemIDURL, "itemQuantities.txt");
            //StreamReader sr = new StreamReader("itemQuantities.txt");
            
        }

        private void decantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Decant", processClass.Decant, this));
        }

        private void unfinishedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Unfinished", processClass.Unfinished, this));
        }

        private void potionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Herblore", processClass.Herblore, this));
        }

        private void barbarianMixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewForm(new CreationForm("Barbarian Mix", processClass.Mix, this));
        }
    }
}
