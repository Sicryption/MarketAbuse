using System.Collections.Generic;
using System.Text.Json;

namespace MarketAbuse.Settings
{
    public class FavoritedItemsSettings : AbstractSettings
    {
        public FavoritedItemsSettings() :
            base("FavoritedItems")
        {
            FavoritedItems = new List<uint>();
        }

        protected override void deserialize(string fileData)
        {
            var de = JsonSerializer.Deserialize<FavoritedItemsSettings>(fileData);
            copyClassProperties(this, de);
        }

        protected override string serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public List<uint> FavoritedItems { get; set; }
    }
}
