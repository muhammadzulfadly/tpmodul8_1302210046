using System;
using System.Text.Json;

namespace tpmodul8_1302210046
{
    public class CovidConfig
    {
        public Covid config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "covid_config.json";
        public CovidConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault();
                WriteConfig();
            }
        }
        private Covid ReadConfig()
        {
            string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
            config = JsonSerializer.Deserialize<Covid>(jsonFromFile);
            return config;
        }

        private void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }

        public void SetDefault()
        {
            config = new Covid("celcius", 14, "Anda tidak diperbolehkan masuk ke dalam gedung ini", "Anda dipersilahkan untuk masuk ke dalam gedung ini");
        }
        public void UbahSatuan()
        {
            config.satuan_suhu = config.satuan_suhu == "celcius" ? "fahrenheit" : "fahrenheit";
        }
        public bool IsInputValid(double suhu, int hariDemam)
        {
            if (config.satuan_suhu == "celcius")
            {
                if (suhu < 36.5 && suhu > 37.5)
                {
                    return false;
                }
            }
            else if (config.satuan_suhu == "fahrenheit")
            {
                if (suhu < 97.7 && suhu > 99.5)
                {
                    return false;
                }
            }

            if (hariDemam >= config.batas_hari_demam)
            {
                return false;
            }

            return true;
        }
    }

    public class Covid
	{
		public string satuan_suhu { get; set; }
		public int batas_hari_demam { get; set; }
		public string pesan_ditolak { get; set; }
		public string pesan_diterima { get; set; }
		public Covid(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
		{
			this.satuan_suhu = satuan_suhu;
			this.batas_hari_demam = batas_hari_demam;
			this.pesan_ditolak = pesan_ditolak;
			this.pesan_diterima = pesan_diterima;
		}

		public Covid()
		{
			
		}
    }
}