using System.Text.Json;

namespace MarketAbuse.Settings
{
    public class ApplicationSettings : AbstractSettings
    {
        public ApplicationSettings() :
            base("Application")
        {

        }

        protected override void deserialize(string fileData)
        {
            copyClassProperties(this, JsonSerializer.Deserialize<ApplicationSettings>(fileData));
        }

        protected override string serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public string FilterOption { get; set; }
        public string SortOption { get; set; }
    }
}
