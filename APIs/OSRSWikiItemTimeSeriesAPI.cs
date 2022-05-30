using MarketAbuse.OSRSObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MarketAbuse.APIs
{
    public class OSRSWikiItemTimeSeriesAPI : AbstractItemTimeSeriesAPI
    {
        public enum SupportedDurations
        {
            FiveMinutes,
            OneHour,
            SixHours,
            OneDay
        }

        public OSRSWikiItemTimeSeriesAPI(SupportedDurations supportedDuration, uint itemId) :
            base(itemId)
        {
            this.supportedDuration = supportedDuration;
        }

        private string pullLatestItemAPIData()
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "MarketAbuse - Flipping Tool | sicryption@gmail.com");
            return webClient.DownloadString(itemAPIUri);
        }

        private void setItemAPIUri(uint itemId)
        {
            string baseUri = "https://prices.runescape.wiki/api/v1/osrs/timeseries?timestep=";
            
            if(supportedDuration == SupportedDurations.FiveMinutes)
            {
                baseUri += "5m";
            }
            else if (supportedDuration == SupportedDurations.OneHour)
            {
                baseUri += "1h";
            }
            else if (supportedDuration == SupportedDurations.SixHours)
            {
                baseUri += "6h";
            }
            else if (supportedDuration == SupportedDurations.OneDay)
            {
                baseUri += "24h";
            }

            baseUri += "&id=" + itemId;

            itemAPIUri = new Uri(baseUri);
        }

        private void parseTimestamp(JsonElement property, ref OSRSItemTimeSeries item)
        {
            JsonElement element = property.GetProperty("timestamp");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.timestamp = element.GetInt64();
            }
        }

        private void parseAverageHighPrice(JsonElement property, ref OSRSItemTimeSeries item)
        {
            JsonElement element = property.GetProperty("avgHighPrice");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.averageHighPrice = element.GetInt32();
            }
        }

        private void parseAverageLowPrice(JsonElement property, ref OSRSItemTimeSeries item)
        {
            JsonElement element = property.GetProperty("avgLowPrice");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.averageLowPrice = element.GetInt32();
            }
        }

        private void parseHighPriceVolume(JsonElement property, ref OSRSItemTimeSeries item)
        {
            JsonElement element = property.GetProperty("highPriceVolume");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.highPriceVolume = element.GetInt32();
            }
        }

        private void parseLowPriceVolume(JsonElement property, ref OSRSItemTimeSeries item)
        {
            JsonElement element = property.GetProperty("lowPriceVolume");

            if (element.ValueKind == JsonValueKind.Number)
            {
                item.lowPriceVolume = element.GetInt32();
            }
        }

        private OSRSItemTimeSeries parseJsonProperty(JsonElement itemJson)
        {
            OSRSItemTimeSeries item = new OSRSItemTimeSeries();

            parseTimestamp(itemJson, ref item);
            parseAverageLowPrice(itemJson, ref item);
            parseAverageHighPrice(itemJson, ref item);
            parseLowPriceVolume(itemJson, ref item);
            parseHighPriceVolume(itemJson, ref item);

            return item;
        }

        private ObservableCollection<OSRSItemTimeSeries> parseAPIData(string apiData)
        {
            ObservableCollection<OSRSItemTimeSeries> itemList = new ObservableCollection<OSRSItemTimeSeries>();

            JsonDocument apiDataAsJson = JsonDocument.Parse(apiData);
            JsonElement dataElement;
            bool hasDataProperty = apiDataAsJson.RootElement.TryGetProperty("data", out dataElement);

            if (!hasDataProperty)
            {
                throw new InvalidOperationException("Data property missing from downloaded API!");
            }

            foreach (var jsonElement in dataElement.EnumerateArray())
            {
                var generatedElement = parseJsonProperty(jsonElement);

                if(generatedElement.averageLowPrice > 0 && generatedElement.averageHighPrice > 0)
                {
                    itemList.Add(generatedElement);
                }
            }

            return itemList;
        }


        public override ObservableCollection<OSRSItemTimeSeries> getTimeSeries(uint itemId)
        {
            setItemAPIUri(itemId);

            string apiData = pullLatestItemAPIData();

            return parseAPIData(apiData);
        }

        private SupportedDurations supportedDuration;
        private Uri itemAPIUri;
    }
}
