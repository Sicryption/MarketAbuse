using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Text.Json;

using MarketAbuse.OSRSObjects;

namespace MarketAbuse.APIs
{
    class OSRSWikiItemInformationAPI : AbstractItemInformationAPI
    {
        private string pullLatestItemAPIData()
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "MarketAbuse - Flipping Tool | sicryption@gmail.com");
            return webClient.DownloadString(itemAPIUri);
        }

        private void parseName(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("name", out element);

            if (propertyExists && element.ValueKind == JsonValueKind.String)
            {
                item.Name = element.GetString();
            }
        }

        private void parseExamineText(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("examine", out element);

            if (propertyExists && element.ValueKind == JsonValueKind.String)
            {
                item.ExamineText = element.GetString();
            }
        }

        private void parseId(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("id", out element);

            if (propertyExists && element.ValueKind == JsonValueKind.Number)
            {
                item.Id = element.GetUInt32();
            }
        }

        private void parseHighAlch(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("highalch", out element);

            if (propertyExists && element.ValueKind == JsonValueKind.Number)
            {
                item.HighAlchAmount = element.GetUInt32();
            }
        }

        private void parseLowAlch(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("lowalch", out element);

            if (propertyExists && element.ValueKind == JsonValueKind.Number)
            {
                item.LowAlchAmount = element.GetUInt32();
            }
        }

        private void parseValue(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("value", out element);

            if (propertyExists && element.ValueKind == JsonValueKind.Number)
            {
                item.Value = element.GetUInt32();
            }
        }

        private void parseIcon(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("icon", out element);

            if (propertyExists && element.ValueKind == JsonValueKind.String)
            {
                item.IconName = element.GetString();
            }
        }

        private void parseIsMembers(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("members", out element);

            if (propertyExists && (element.ValueKind == JsonValueKind.False || element.ValueKind == JsonValueKind.True))
            {
                item.MembersOnly = element.GetBoolean();
            }
        }

        private void parseBuyLimit(JsonElement property, ref OSRSItemInformation item)
        {
            JsonElement element;
            bool propertyExists = property.TryGetProperty("limit", out element);

            if (propertyExists && element.ValueKind == JsonValueKind.Number)
            {
                item.BuyLimit = element.GetUInt32();
            }
        }

        private OSRSItemInformation parseJsonElement(JsonElement itemJson)
        {
            OSRSItemInformation item = new OSRSItemInformation();

            parseName(itemJson, ref item);
            parseExamineText(itemJson, ref item);
            parseId(itemJson, ref item);
            parseIsMembers(itemJson, ref item);
            parseLowAlch(itemJson, ref item);
            parseHighAlch(itemJson, ref item);
            parseIcon(itemJson, ref item);
            parseBuyLimit(itemJson, ref item);
            parseValue(itemJson, ref item);

            return item;
        }

        private ObservableCollection<OSRSItemInformation> parseAPIData(string apiData)
        {
            ObservableCollection<OSRSItemInformation> itemList = new ObservableCollection<OSRSItemInformation>();

            JsonDocument apiDataAsJson = JsonDocument.Parse(apiData);
            foreach (var jsonElement in apiDataAsJson.RootElement.EnumerateArray())
            {
                itemList.Add(parseJsonElement(jsonElement));
            }

            return itemList;
        }

        public override ObservableCollection<OSRSItemInformation> doAPIUpdate()
        {
            string latestAPIData = pullLatestItemAPIData();

            ObservableCollection<OSRSItemInformation> itemList = parseAPIData(latestAPIData);

            return itemList;
        }

        public Uri itemAPIUri = new Uri("https://prices.runescape.wiki/api/v1/osrs/mapping");
    }
}
