using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.Json;


namespace tpmodul8_1302220121
{
    internal class CovidConfig
    {
        public string CONFIG1 { get; set; } = "celcius";
        public int CONFIG2 { get; set; } = 14;
        public string CONFIG3 { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string CONFIG4 { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private const string CONFIG_FILE_PATH = "covid_config.json";

        public CovidConfig()
        {
            LoadConfigFromFile();
        }

        private void LoadConfigFromFile()
        {
            if (File.Exists(CONFIG_FILE_PATH))
            {
                string configJson = File.ReadAllText(CONFIG_FILE_PATH);
                CovidConfig config = JsonSerializer.Deserialize<CovidConfig>(configJson);
                CONFIG1 = config.CONFIG1;
                CONFIG2 = config.CONFIG2;
                CONFIG3 = config.CONFIG3;
                CONFIG4 = config.CONFIG4;
            }
            else
            {
                WriteConfigToFile();
            }
        }

        private void WriteConfigToFile()
        {
            string configJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CONFIG_FILE_PATH, configJson);
        }

        public void UbahSatuan()
        {
            if (CONFIG1 == "celcius")
            {
                CONFIG1 = "fahrenheit";
            }
            else
            {
                CONFIG1 = "celcius";
            }
            WriteConfigToFile();
        }
    }
}