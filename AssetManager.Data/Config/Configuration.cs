using AssetManager.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Data.Config
{
    public class Configuration
    {
        public static string GetConnectionString()
        {
            var jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "config.json");
            using var fs = File.OpenRead(jsonFile);
            using var sr = new StreamReader(fs, new UTF8Encoding(false));
            var json = sr.ReadToEnd() ?? "";

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            return configJson.ConnectionString;
        }
    }
}
