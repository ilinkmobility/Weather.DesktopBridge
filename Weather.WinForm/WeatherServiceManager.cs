using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Weather.WinForm
{
    public class WeatherServiceManager
    {
        const string URL = "https://query.yahooapis.com/v1/public/yql?q=select%20item.forecast%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text=%22CITY_NAME,%20in%22)%20and%20u=%27c%27%20limit%205&format=json";

        //Private Constructor.
        private WeatherServiceManager()
        {
        }

        private static WeatherServiceManager instance = null;
        public static WeatherServiceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherServiceManager();
                }
                return instance;
            }
        }

        public string GetFormattedCityURL(string city)
        {
            return URL.Replace("CITY_NAME", city);
        }

        public List<Weather> GetForecast(string city)
        {
            List<Weather> forecast = new List<Weather>();

            try
            {
                string json = string.Empty;
                string url = GetFormattedCityURL(city);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }

                JObject weatherJson = JObject.Parse(json);
                forecast = weatherJson["query"]["results"]["channel"].Select(r => new Weather() { Date = (string)r["item"]["forecast"]["date"], Day = (string)r["item"]["forecast"]["day"], High = (string)r["item"]["forecast"]["high"], Low = (string)r["item"]["forecast"]["low"] }).ToList<Weather>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return forecast;
        }

        public string ToJson(List<Weather> list)
        {
            return JsonConvert.SerializeObject(list); ;
        }
    }
}
