using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    class OSRSWikiItemPriceAPI : AbstractItemPriceAPI
    {
        private string pullLatestItemAPIData()
        {
            WebClient webClient = new WebClient(); 
            webClient.Headers.Add("user-agent", "MarketAbuse - Flipping Tool | sicryption@gmail.com");
            return webClient.DownloadString(itemAPIUri);
        }

        private void parseBuyPrice(JsonElement property, ref OSRSItemPrices item)
        {
            JsonElement element = property.GetProperty("high");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.BuyPrice = element.GetInt32();
            }
        }

        private void parseBuyPriceTimestamp(JsonElement property, ref OSRSItemPrices item)
        {
            JsonElement element = property.GetProperty("highTime");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.BuyPriceTimestamp = element.GetInt64();
            }
        }

        private void parseSellPrice(JsonElement property, ref OSRSItemPrices item)
        {
            JsonElement element = property.GetProperty("low");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.SellPrice = element.GetInt32();
            }
        }

        private void parseSellPriceTimestamp(JsonElement property, ref OSRSItemPrices item)
        {
            JsonElement element = property.GetProperty("lowTime");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.SellPriceTimestamp = element.GetInt64();
            }
        }

        private OSRSItemPrices parseJsonProperty(JsonProperty itemJson)
        {
            OSRSItemPrices item = new OSRSItemPrices();

            item.Id = int.Parse(itemJson.Name);

            JsonElement itemValue = itemJson.Value;

            parseBuyPrice(itemValue, ref item);
            parseBuyPriceTimestamp(itemValue, ref item);
            parseSellPrice(itemValue, ref item);
            parseSellPriceTimestamp(itemValue, ref item);

            if (item.BuyPrice < item.SellPrice)
            {
                int temp = item.BuyPrice;
                item.BuyPrice = item.SellPrice;
                item.SellPrice = temp;
            }

            return item;
        }

        private ObservableCollection<OSRSItemPrices> parseAPIData(string apiData)
        {
            ObservableCollection<OSRSItemPrices> itemList = new ObservableCollection<OSRSItemPrices>();

            JsonDocument apiDataAsJson = JsonDocument.Parse(apiData);
            JsonElement dataElement;
            bool hasDataProperty = apiDataAsJson.RootElement.TryGetProperty("data", out dataElement);

            if(!hasDataProperty)
            {
                throw new InvalidOperationException("Data property missing from downloaded API!");
            }

            foreach (var jsonProperty in dataElement.EnumerateObject())
            {
                itemList.Add(parseJsonProperty(jsonProperty));
            }

            return itemList;
        }

        public override ObservableCollection<OSRSItemPrices> doAPIUpdate()
        {
            string latestAPIData = pullLatestItemAPIData();

            ObservableCollection<OSRSItemPrices> itemList = parseAPIData(latestAPIData);

            return itemList;
        }

        public Uri itemAPIUri = new Uri("https://prices.runescape.wiki/api/v1/osrs/latest");
    }
}
