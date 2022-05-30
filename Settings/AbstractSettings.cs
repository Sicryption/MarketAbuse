using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace MarketAbuse.Settings
{
    public abstract class AbstractSettings
    {
        public AbstractSettings(string settingsFileName)
        {
            this.settingsFileName = settingsFileName;
        }

        public bool loadFromFile()
        {
            string filePath = getFilePath();
            if (!File.Exists(filePath))
            {
                return false;
            }

            deserialize(File.ReadAllText(filePath));
            return true;
        }

        public void saveToFile()
        {
            if(!Directory.Exists(settingsFolderName))
            {
                Directory.CreateDirectory(settingsFolderName);
            }

            string filePath = getFilePath();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.WriteAllText(filePath, serialize());
        }

        protected void copyClassProperties<T>(T target, T source)
        {
            foreach (PropertyInfo property in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                property.SetValue(target, property.GetValue(source, null), null);
            }
        }

        protected abstract string serialize();
        protected abstract void deserialize(string fileData);

        private string getFilePath()
        {
            return settingsFolderName + "/" + settingsFileName + ".settings";
        }

        private const string settingsFolderName = "settings";
        private string settingsFileName;
    }
}
