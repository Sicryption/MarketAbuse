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


namespace MarketAbuse
{
    public class Item
    {
        public int
            BuyPrice = 0,
            SellPrice = 0,
            OverallPrice = 0,
            HighAlchPrice = 0,
            LowAlchPrice = 0,
            margin = 0,
            buyQuantity = 0,
            sellQuantity = 0,
            id = 0,
            geLimit = 0,
            herbCleanProfit = 0,
            quantity = 1;
        public int buyPrice
        {
            get
            {
                if (BuyPrice != 0)
                    return BuyPrice;
                else if (SellPrice != 0)
                    return SellPrice;
                else if (OverallPrice != 0)
                    return OverallPrice;
                else
                    return 0;
            }
            set { BuyPrice = value; }
        }
        public int sellPrice
        {
            get
            {
                if (SellPrice != 0)
                    return SellPrice;
                else if (BuyPrice != 0)
                    return BuyPrice;
                else if (OverallPrice != 0)
                    return OverallPrice;
                else
                    return 0;
            }
            set { SellPrice = value; }
        }
        public int overallPrice
        {
            get
            {
                if (OverallPrice != 0)
                    return OverallPrice;
                else if (BuyPrice != 0)
                    return BuyPrice;
                else if (SellPrice != 0)
                    return SellPrice;
                else
                    return 0;
            }
            set { OverallPrice = value; }
        }
        public bool members;
        public string name { get; set; }
        public string information = "";
        public Item CleanVersion = null;

        public Item(string info)
        {
            information = info;
            FindItemID();
            UpdateItemData();
            FindItemMemberStatus();
            name = FindItemName(info);
        }

        public override string ToString()
        {
            return name;
        }
        private string FindData(string type)
        {
            int infoStartIndex = information.IndexOf("\"" + type + "\":");
            string info = information.Substring(infoStartIndex + type.Length + 4);
            info = info.Split(new string[] { "," }, StringSplitOptions.None).First();
            return info;
        }
        public static string FindData(string forcedInformation, string type)
        {
            int infoStartIndex = forcedInformation.IndexOf("\"" + type + "\"");
            string info = forcedInformation.Substring(infoStartIndex + type.Length + 1);
            info = info.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
            info = info.Replace("\"", "");
            info = info.Replace(":", "");
            info = info.Replace("{", "");
            info = info.Replace("}", "");
            if (info[0] == ' ')
                info = info.TrimStart(' ');
            return info;
        }
        public static string FindItemName(string forcedInformation)
        {
            string NAME = FindData(forcedInformation, "name");

            if (NAME == "keefBeef")
                NAME = "Raw beef";
            return NAME;
        }
        private void FindItemID()
        {
            id = Convert.ToInt32(FindData("id"));
        }
        private void FindItemBuyQuantity(string info)
        {
            buyQuantity = int.Parse(FindData(info, "buyingQuantity"));
        }
        private void FindItemSellQuantity(string info)
        {
            sellQuantity = int.Parse(FindData(info, "sellingQuantity"));
        }
        private void FindItemMemberStatus()
        {
            members = Convert.ToBoolean(FindData("members"));
        }
        private void FindItemSellAverage()
        {
            sellPrice = Convert.ToInt32(FindData("sell_average"));
        }
        private void FindItemOverallAverage()
        {
            int num = 0;
            if (int.TryParse(FindData("overall_average"), out num))
                overallPrice = num;
            else
                MessageBox.Show("Failed to find overall average");
        }
        private void FindItemBuyAverage()
        {
            buyPrice = Convert.ToInt32(FindData("buy_average"));
        }
        public void UpdateItemData()
        {
            FindItemBuyAverage();
            FindItemSellAverage();
            FindItemOverallAverage();
            int testing = buyPrice;
            int testing2 = sellPrice;

            margin = Convert.ToInt32(FindData("sell_average")) -
                Convert.ToInt32(FindData("buy_average"));
        }
        public bool UpdateItemAdvancedData()
        {
            try
            {
                MarketAbuse.DownloadFile("http://api.rsbuddy.com/grandExchange?a=guidePrice&i=" + id, "tempItemData.txt");
                StreamReader sr = new StreamReader("tempItemData.txt");
                string allinfo = sr.ReadToEnd();
                sr.Close();

                FindItemBuyQuantity(allinfo);
                FindItemSellQuantity(allinfo);
                return true;
            }
            catch { return false; }
        }
    }
}
