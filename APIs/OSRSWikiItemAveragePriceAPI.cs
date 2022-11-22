using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    public class OSRSWikiItemAveragePriceAPI : AbstractItemAveragePriceAPI
    {
        public OSRSWikiItemAveragePriceAPI(TimeframeInterval timeframeInterval)
        {
            this.timeframeInterval = timeframeInterval;

            if(timeframeInterval == TimeframeInterval.OneDay)
            {
                itemAPIUri = new Uri("https://prices.runescape.wiki/api/v1/osrs/24h");
            }
            else if (timeframeInterval == TimeframeInterval.FiveMinutes)
            {
                itemAPIUri = new Uri("https://prices.runescape.wiki/api/v1/osrs/5m");
            }
            else if (timeframeInterval == TimeframeInterval.OneHour)
            {
                itemAPIUri = new Uri("https://prices.runescape.wiki/api/v1/osrs/1h");
            }
        }

        public enum TimeframeInterval
        {
            OneHour = 60,
            FiveMinutes = 5,
            OneDay = 24 * 60
        }

        private string pullLatestItemAPIData()
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "MarketAbuse - Flipping Tool | sicryption@gmail.com");
            return webClient.DownloadString(itemAPIUri);
        }

        private void parseAverageLowPrice(JsonElement property, ref OSRSItemAveragePrices item)
        {
            JsonElement element = property.GetProperty("avgLowPrice");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.AverageLowPrice = element.GetInt32();
            }
        }

        private void parseAverageHighPrice(JsonElement property, ref OSRSItemAveragePrices item)
        {
            JsonElement element = property.GetProperty("avgHighPrice");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.AverageHighPrice = element.GetInt32();
            }
        }

        private void parseLowPriceVolume(JsonElement property, ref OSRSItemAveragePrices item)
        {
            JsonElement element = property.GetProperty("lowPriceVolume");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.LowPriceVolume = element.GetUInt32();
            }
        }

        private void parseHighPriceVolume(JsonElement property, ref OSRSItemAveragePrices item)
        {
            JsonElement element = property.GetProperty("highPriceVolume");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.HighPriceVolume = element.GetUInt32();
            }
        }

        private OSRSItemAveragePrices parseJsonProperty(JsonProperty itemJson)
        {
            OSRSItemAveragePrices item = new OSRSItemAveragePrices();

            item.Id = uint.Parse(itemJson.Name);
            item.ItemAverageTimeframe_min = (uint)timeframeInterval;

            JsonElement itemValue = itemJson.Value;

            parseAverageLowPrice(itemValue, ref item);
            parseAverageHighPrice(itemValue, ref item);
            parseLowPriceVolume(itemValue, ref item);
            parseHighPriceVolume(itemValue, ref item);

            return item;
        }

        private ObservableCollection<OSRSItemAveragePrices> parseAPIData(string apiData)
        {
            ObservableCollection<OSRSItemAveragePrices> itemList = new ObservableCollection<OSRSItemAveragePrices>();

            JsonDocument apiDataAsJson = JsonDocument.Parse(apiData);
            JsonElement dataElement;
            bool hasDataProperty = apiDataAsJson.RootElement.TryGetProperty("data", out dataElement);

            if (!hasDataProperty)
            {
                throw new InvalidOperationException("Data property missing from downloaded API!");
            }

            foreach (var jsonProperty in dataElement.EnumerateObject())
            {
                itemList.Add(parseJsonProperty(jsonProperty));
            }

            return itemList;
        }

        public override ObservableCollection<OSRSItemAveragePrices> doAPIUpdate()
        {
            string latestAPIData = pullLatestItemAPIData();

            ObservableCollection<OSRSItemAveragePrices> itemList = parseAPIData(latestAPIData);

            return itemList;
        }

        private TimeframeInterval timeframeInterval;
        public Uri itemAPIUri = new Uri("https://prices.runescape.wiki/api/v1/osrs/24h");
    }
}
