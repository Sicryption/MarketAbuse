using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MainMarketForm
{
    public class ItemHandler
    {
        public List<Item> Items = new List<Item>();
        public List<ShortHandName> ShortHandNames = new List<ShortHandName>();
        public SplashScreen SS;
        public MainWindow MW;

        public ItemHandler()
        {
            CreateNessecaryDirectories();
        }

        public void RefreshItemList()
        {
            string osbuddyFileName = "Data/osbuddyData.txt";
            string shortHandFileName = "Resources/ShortHand.names";
            string OSBuddySummaryURL = "https://rsbuddy.com/exchange/summary.json";

            WebClient wc = new WebClient();
            wc.Proxy = GlobalProxySelection.GetEmptyWebProxy();

            DownloadRequiredDLLS();

            //download MAIN item list and info
            wc.DownloadFile(OSBuddySummaryURL, osbuddyFileName);

            if (SS != null)
                SS.UpdateProgressBar(70, "Formatting Price Summary");

            //store MAIN info as an item list
            List<Item> items = formatMainItemData(osbuddyFileName);

            if (SS != null)
                SS.UpdateProgressBar(80, "Downloading Current Price Data");

            //Download most recent buy/sell item information.
            string OSBuddyPriceBaseURL = "https://api.rsbuddy.com/grandExchange?a=guidePrice";
            int itemsAtATime = 100;
            for (int i = 0; i < items.Count / itemsAtATime; i++)
            {
                Console.Write("Attempting to download items " + i * itemsAtATime + " to " + (i + 1) * itemsAtATime);

                string url = OSBuddyPriceBaseURL;
                for (int j = 0; j < itemsAtATime; j++)
                {
                    //should be just <  ?
                    int num = (j + (i * itemsAtATime));
                    if (num < items.Count)
                        url += "&i=" + items[num].id;
                }

                Console.WriteLine("|" + url);
                bool downloadSuccess = false;
                while (!downloadSuccess)
                {
                    //Console.WriteLine("Testing start");
                    try { wc.DownloadFile(url, osbuddyFileName); downloadSuccess = true; } catch { }//Console.WriteLine("Failed to download these items..."); Console.WriteLine(url); }
                    //Console.WriteLine("Testing end");
                }

                List<KeyValuePair<string, ItemGuideData>> itemGuideData = formatGuideItemData(osbuddyFileName);
                for (int j = 0; j < itemGuideData.Count; j++)
                {
                    int index = items.IndexOf(items.FirstOrDefault(a => a.id == Convert.ToInt32(itemGuideData[j].Key)));
                    int bP = itemGuideData[j].Value.buyPrice,
                        sP = itemGuideData[j].Value.sellPrice;
                    items[index].buyPrice = bP > sP ? sP : bP;
                    items[index].sellPrice = bP > sP ? bP : sP;
                    items[index].buyQuantity = itemGuideData[j].Value.buyingQuantity;
                    items[index].sellQuantity = itemGuideData[j].Value.sellQuantity;
                    items[index].overallPrice = itemGuideData[j].Value.averagePrice;
                }
            }

            if(MW != null)
                MW.listInNeedOfRefresh = true;

            if (SS != null)
                SS.UpdateProgressBar(90, "Downloading Item Pictures");

            //if main itemlist is null, make this the main item list, otherwise update the values
            //this is only called on the first time the progam is loaded
            if (Items.Count == 0)
            {
                Items = items;
                var imagesInFolder = Directory.GetFiles("Images");

                if(imagesInFolder.Count() < 100)
                {
                    wc.DownloadFile("https://github.com/Sicryption/MarketAbuse/raw/master/Bundle.zip", "Images/Bundle.zip");
                    System.IO.Compression.ZipFile.ExtractToDirectory("Images/Bundle.zip", "Images/");
                    File.Delete("Images/Bundle.zip");
                }
                
                //download pictures
                foreach (Item i in items)
                    if (!File.Exists("Images/" + i.id + ".png"))
                        wc.DownloadFile("http://cdn.rsbuddy.com/items/" + i.id + ".png", "Images/" + i.id + ".png");
            }

            //Console.WriteLine("PogChamp");
            //if (MW != null && MW.List != null && MW.List.SelectedItems != null)
           //     Console.WriteLine(MW.List.SelectedItems.Count);
           foreach(Item i in items)
            {
                Item j = Items.FirstOrDefault(a => a.id == i.id);

                if (j != null)
                {
                    j.buyPrice = i.buyPrice;
                    j.sellPrice = i.sellPrice;
                    j.buyQuantity = i.buyQuantity;
                    j.sellQuantity = i.sellQuantity;
                    j.overallPrice = i.overallPrice;
                    j.buyAverage = i.buyAverage;
                    j.sellAverage = i.sellAverage;
                    j.overallAverage = i.overallAverage;
                }
            }

            if (MW != null)
                MW.listInNeedOfRefresh = true;

            //if (MW != null && MW.List != null && MW.List.SelectedItems != null)
            //    Console.WriteLine(MW.List.SelectedItems.Count);

            if (SS != null)
            {
                SS.UpdateProgressBar(95, "Getting Short Hand Names");
                
                if (!File.Exists("Resources/ShortHand.names"))
                    wc.DownloadFile("https://raw.githubusercontent.com/Sicryption/MarketAbuse/master/ShortHand.names", "Resources/ShortHand.names");

                ShortHandNames = LoadShortHandNames(shortHandFileName);

                for (int i = 0; i < Items.Count; i++)
                    if (ShortHandNames.Any(a => Items[i].name.ToLower() == a.itemName.ToLower()))
                        Items[i].shortHandName = ShortHandNames.FirstOrDefault(a => Items[i].name.ToLower() == a.itemName.ToLower()).shortHand;
            }
            

            if (SS != null)
            {
                SS.UpdateProgressBar(100, "Launching Program");
                SS.OpenMainWindow();
                SS = null;
            }
            wc.Dispose();
        }

        private void DownloadRequiredDLLS()
        {
            WebClient wc = new WebClient();

            if(!File.Exists("Newtonsoft.Json.dll"))
                wc.DownloadFile("https://github.com/Sicryption/MarketAbuse/raw/master/Newtonsoft.Json.dll", "Newtonsoft.Json.dll");
            
            wc.Dispose();
        }

        public void CreateNessecaryDirectories()
        {
            //check for folders 
            if (!Directory.Exists("Images"))
                Directory.CreateDirectory("Images");
            if (!Directory.Exists("Data"))
                Directory.CreateDirectory("Data");
            if (!Directory.Exists("Resources"))
                Directory.CreateDirectory("Resources");
        }

        private List<ShortHandName> LoadShortHandNames(string fileToFormat)
        {
            StreamReader sr = new StreamReader(fileToFormat);
            List<ShortHandName> list = new List<ShortHandName>();
            
            while(!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] split = s.Split(new char[] { ':' });
                ShortHandName name = new ShortHandName() { itemName = split[0], shortHand = split[1] };
                list.Add(name);
            }

            sr.Close();

            return list;
        }

        private List<Item> formatMainItemData(string fileToFormat)
        {
            //load the file into the stream
            StreamReader sr = new StreamReader(fileToFormat);

            //"2": {"sell_average": 180, "sp": 5, "id": 2, "buy_average": 180, "members": true, "name": "Cannonball", "overall_average": 180}

            //reads in the entire json file and formats the values
            dynamic fileReadIn = JsonConvert.DeserializeObject<Dictionary<string, Item>>(sr.ReadToEnd());

            sr.Close();

            //stores all the values into a list to be used.
            List<Item> items = new List<Item>();
            foreach (KeyValuePair<string, Item> f in fileReadIn)
                items.Add(f.Value);

            return items;
        }

        private List<KeyValuePair<string, ItemGuideData>> formatGuideItemData(string fileToFormat)
        {
            //load the file into the stream
            StreamReader sr = new StreamReader(fileToFormat);

            //"2":{"overall":180,"buying":180,"buyingQuantity":566062,"selling":179,"sellingQuantity":452812}

            //reads in the entire json file and formats the values
            dynamic fileReadIn = JsonConvert.DeserializeObject<Dictionary<string, ItemGuideData>>(sr.ReadToEnd());
            sr.Close();

            //stores all the values into a list to be used.
            List<KeyValuePair<string, ItemGuideData>> items = new List<KeyValuePair<string, ItemGuideData>>();
            foreach (KeyValuePair<string, ItemGuideData> f in fileReadIn)
                items.Add(f);

            return items;
        }
    }
}
