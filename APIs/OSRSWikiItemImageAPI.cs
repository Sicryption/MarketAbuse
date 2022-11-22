using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    class OSRSWikiItemImageAPI : AbstractItemImageAPI
    {
        List<string> quantityFiveItems = new List<string>()
        {
            "arrow",
            "bolts",
            "brutal",
            "bolt tips",
            "shaft",
            "javelin heads",
            "rack",
            "seed",
            "scales",
            "leaf",
            "ether",
            "sweets",
            "spore"
        };

        List<string> quantityFiveItemExceptions = new List<string>()
        {
            "Crystal armour seed",
            "Curry leaf",
            "Crystal tool seed",
            "Crystal weapon seed",
            "Enhanced crystal teleport seed",
            "Enhanced crystal weapon seed",
            "Gold leaf",
            "Grimy irit leaf",
            "Grimy guam leaf",
            "Guam leaf",
            "Irit leaf",
            "Kebbit bolts",
            "Long kebbit bolts",
            "Spider on shaft"
        };

        List<string> itemsMissingQuantity = new List<string>()
        {
            "Acorn",
            "Bone fragments",
            "Amylase crystal",
            "Numulite",
        };

        List<string> trimmedArmourPrefixes = new List<string>()
        {
            "Shattered",
            "Trailblazer",
            "Twisted"
        };

        List<Tuple<string, string>> directReplacements = new List<Tuple<string, string>>()
        { 
            new Tuple<string, string>("Iron dart(p+)", "Iron dart (p)"),
            new Tuple<string, string>("Iron dart(p++)", "Iron dart (p)"),
            new Tuple<string, string>("Pharaoh's sceptre (uncharged)", "Pharaoh's_sceptre")
        };

        private void doDirectReplacements(ref string itemName)
        {
            foreach (var directReplacement in directReplacements)
            {
                if (itemName == directReplacement.Item1)
                {
                    itemName = directReplacement.Item2;
                }
            }
        }

        private void removeChargeCountFromTrimmedIfNeeded(ref string itemName)
        {
            bool doTrimmedRegex = true;
            foreach (var prefix in trimmedArmourPrefixes)
            {
                if (itemName.StartsWith(prefix))
                {
                    doTrimmedRegex = false;
                }
            }

            if (doTrimmedRegex)
            {
                itemName = Regex.Replace(itemName, @"(.*)\(t[0-9]+\)(.*)", @"$1(t)$2");
            }
        }

        private void removePoisonStackCount(ref string itemName)
        {
            itemName = Regex.Replace(itemName, @"(.*)\(p\+*\)(.*)", @"$1(p)$2");
        }

        private void reduceJewellryChargesToFour(ref string itemName)
        {
            itemName = itemName.Replace("(6)", "(4)");
        }

        private void makeAmmunitionQuantities5(ref string itemName)
        {
            bool doFiveItemExceptionCheck = true;
            foreach (var fiveItemException in quantityFiveItemExceptions)
            {
                if (itemName == fiveItemException)
                {
                    doFiveItemExceptionCheck = false;
                }
            }

            if (doFiveItemExceptionCheck)
            {
                foreach (var fiveItem in quantityFiveItems)
                {
                    if (itemName.EndsWith(fiveItem))
                    {
                        itemName = Regex.Replace(itemName, @"(.*) " + fiveItem + @"(.*)", @"$1 " + fiveItem + @"$2 5");
                    }
                }
            }

            foreach (var missingQuantity in itemsMissingQuantity)
            {
                if (itemName == missingQuantity)
                {
                    itemName = itemName.Replace(missingQuantity, missingQuantity + " 5");
                }
            }

        }

        private string modifyNameToMatchWikiName(string itemName)
        {
            itemName = itemName.Replace(".png", "");

            doDirectReplacements(ref itemName);
            removeChargeCountFromTrimmedIfNeeded(ref itemName);
            removePoisonStackCount(ref itemName);
            reduceJewellryChargesToFour(ref itemName);
            makeAmmunitionQuantities5(ref itemName);

            itemName = itemName.Trim();
            itemName = itemName.Replace(" ", "_");

            return itemName;
        }

        private byte[] getItemImageFromName(string itemName)
        {
            itemName = modifyNameToMatchWikiName(itemName);

            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "MarketAbuse - Flipping Tool | sicryption@gmail.com");

            try
            {
                return webClient.DownloadData(getItemURI(itemName));
            }
            catch
            {
                return null;
            }
        }

        public override OSRSItemImage getItemImage(string itemName)
        {
            OSRSItemImage osrsItemImage = new OSRSItemImage();

            osrsItemImage.itemName = itemName;
            osrsItemImage.Image = getItemImageFromName(itemName);

            return osrsItemImage;
        }

        public Uri getItemURI(string itemName)
        {
            bool useHighQualityImages = false;

            string baseURLName = "https://oldschool.runescape.wiki/images/" + itemName;
            
            if(useHighQualityImages)
            {
                baseURLName += "_detail";
            }

            baseURLName += ".png";
            return new Uri(baseURLName);
        }

        private readonly object syncLock = new object();
    }
}
