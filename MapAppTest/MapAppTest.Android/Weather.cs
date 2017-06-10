using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MapAppTest.Droid
{
    public class Weather
    {
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }

        public Weather()
        {
            this.Title = " ";
            this.Temperature = " ";
            this.Wind = " ";
            this.Humidity = " ";
            this.Visibility = " ";
        }
    }

    public class ForecastWeather
    {
        public string ForecastDay { get; set; }
        public string ForecastText { get; set; }

        public ForecastWeather()
        {
            this.ForecastDay = " ";
            this.ForecastText = " ";
        }
    }

    public class CurrentWeather
    {
        public RootObject root { get; set;
        }
        public class Features
        {
            public int conditions { get; set; }
        }

        public class Response
        {
            public string version { get; set; }
            public string termsofService { get; set; }
            public Features features { get; set; }
        }

        public class Image
        {
            public string url { get; set; }
            public string title { get; set; }
            public string link { get; set; }
        }

        public class DisplayLocation
        {
            public string full { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string state_name { get; set; }
            public string country { get; set; }
            public string country_iso3166 { get; set; }
            public string zip { get; set; }
            public string magic { get; set; }
            public string wmo { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string elevation { get; set; }
        }

        public class ObservationLocation
        {
            public string full { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string country_iso3166 { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string elevation { get; set; }
        }

        public class Estimated
        {
        }

        public class CurrentObservation
        {
            public Image image { get; set; }
            public DisplayLocation display_location { get; set; }
            public ObservationLocation observation_location { get; set; }
            public Estimated estimated { get; set; }
            public string station_id { get; set; }
            public string observation_time { get; set; }
            public string observation_time_rfc822 { get; set; }
            public string observation_epoch { get; set; }
            public string local_time_rfc822 { get; set; }
            public string local_epoch { get; set; }
            public string local_tz_short { get; set; }
            public string local_tz_long { get; set; }
            public string local_tz_offset { get; set; }
            public string weather { get; set; }
            public string temperature_string { get; set; }
            public double temp_f { get; set; }
            public double temp_c { get; set; }
            public string relative_humidity { get; set; }
            public string wind_string { get; set; }
            public string wind_dir { get; set; }
            public int wind_degrees { get; set; }
            public double wind_mph { get; set; }
            public string wind_gust_mph { get; set; }
            public double wind_kph { get; set; }
            public string wind_gust_kph { get; set; }
            public string pressure_mb { get; set; }
            public string pressure_in { get; set; }
            public string pressure_trend { get; set; }
            public string dewpoint_string { get; set; }
            public int dewpoint_f { get; set; }
            public int dewpoint_c { get; set; }
            public string heat_index_string { get; set; }
            public string heat_index_f { get; set; }
            public string heat_index_c { get; set; }
            public string windchill_string { get; set; }
            public string windchill_f { get; set; }
            public string windchill_c { get; set; }
            public string feelslike_string { get; set; }
            public string feelslike_f { get; set; }
            public string feelslike_c { get; set; }
            public string visibility_mi { get; set; }
            public string visibility_km { get; set; }
            public string solarradiation { get; set; }
            public string UV { get; set; }
            public string precip_1hr_string { get; set; }
            public string precip_1hr_in { get; set; }
            public string precip_1hr_metric { get; set; }
            public string precip_today_string { get; set; }
            public string precip_today_in { get; set; }
            public string precip_today_metric { get; set; }
            public string icon { get; set; }
            public string icon_url { get; set; }
            public string forecast_url { get; set; }
            public string history_url { get; set; }
            public string ob_url { get; set; }
            public string nowcast { get; set; }
        }

        public class RootObject
        {
            public Response response { get; set; }
            public CurrentObservation current_observation { get; set; }
        }
    }

    public class CurrentForecast
    {
        public RootObject root { get; set; }
        public class Features
        {
            public int forecast { get; set; }
        }

        public class Response
        {
            public string version { get; set; }
            public string termsofService { get; set; }
            public Features features { get; set; }
        }

        public class Forecastday
        {
            public int period { get; set; }
            public string icon { get; set; }
            public string icon_url { get; set; }
            public string title { get; set; }
            public string fcttext { get; set; }
            public string fcttext_metric { get; set; }
            public string pop { get; set; }
        }

        public class TxtForecast
        {
            public string date { get; set; }
            public List<Forecastday> forecastday { get; set; }
        }

        public class Date
        {
            public string epoch { get; set; }
            public string pretty { get; set; }
            public int day { get; set; }
            public int month { get; set; }
            public int year { get; set; }
            public int yday { get; set; }
            public int hour { get; set; }
            public string min { get; set; }
            public int sec { get; set; }
            public string isdst { get; set; }
            public string monthname { get; set; }
            public string monthname_short { get; set; }
            public string weekday_short { get; set; }
            public string weekday { get; set; }
            public string ampm { get; set; }
            public string tz_short { get; set; }
            public string tz_long { get; set; }
        }

        public class High
        {
            public string fahrenheit { get; set; }
            public string celsius { get; set; }
        }

        public class Low
        {
            public string fahrenheit { get; set; }
            public string celsius { get; set; }
        }

        public class QpfAllday
        {
            public double @in { get; set; }
            public int mm { get; set; }
        }

        public class QpfDay
        {
            public double @in { get; set; }
            public int mm { get; set; }
        }

        public class QpfNight
        {
            public double @in { get; set; }
            public int mm { get; set; }
        }

        public class SnowAllday
        {
            public double @in { get; set; }
            public double cm { get; set; }
        }

        public class SnowDay
        {
            public double @in { get; set; }
            public double cm { get; set; }
        }

        public class SnowNight
        {
            public double @in { get; set; }
            public double cm { get; set; }
        }

        public class Maxwind
        {
            public int mph { get; set; }
            public int kph { get; set; }
            public string dir { get; set; }
            public int degrees { get; set; }
        }

        public class Avewind
        {
            public int mph { get; set; }
            public int kph { get; set; }
            public string dir { get; set; }
            public int degrees { get; set; }
        }

        public class Forecastday2
        {
            public Date date { get; set; }
            public int period { get; set; }
            public High high { get; set; }
            public Low low { get; set; }
            public string conditions { get; set; }
            public string icon { get; set; }
            public string icon_url { get; set; }
            public string skyicon { get; set; }
            public int pop { get; set; }
            public QpfAllday qpf_allday { get; set; }
            public QpfDay qpf_day { get; set; }
            public QpfNight qpf_night { get; set; }
            public SnowAllday snow_allday { get; set; }
            public SnowDay snow_day { get; set; }
            public SnowNight snow_night { get; set; }
            public Maxwind maxwind { get; set; }
            public Avewind avewind { get; set; }
            public int avehumidity { get; set; }
            public int maxhumidity { get; set; }
            public int minhumidity { get; set; }
        }

        public class Simpleforecast
        {
            public List<Forecastday2> forecastday { get; set; }
        }

        public class Forecast
        {
            public TxtForecast txt_forecast { get; set; }
            public Simpleforecast simpleforecast { get; set; }
        }

        public class RootObject
        {
            public Response response { get; set; }
            public Forecast forecast { get; set; }
        }
    }
    public class WeatherCore
    {
        public static async Task<Weather> GetCurrentWeather(double lat, double lon)
        {
            string key = "30ae4f88a9679843";
            string queryString = $"http://api.wunderground.com/api/{key}/conditions/q/{lat},{lon}.json";

            CurrentWeather.RootObject results = await DataServices.getCurrentWeatherFromServices(queryString).ConfigureAwait(false);

            if (results != null)
            {
                Weather weather = new Weather();
                weather.Title = results.current_observation.display_location.full;
                weather.Temperature = results.current_observation.temperature_string;
                weather.Wind = results.current_observation.wind_string;
                weather.Humidity = results.current_observation.relative_humidity;
                weather.Visibility = results.current_observation.visibility_mi + " miles";

                return weather;
            }
            else
            {
                return null;
            }
        }

        public static async Task<ForecastWeather> GetCurrentForecast(double lat, double lon)
        {
            string key = "30ae4f88a9679843";
            string queryString = $"http://api.wunderground.com/api/{key}/forecast/q/{lat},{lon}.json";

            CurrentForecast.RootObject results = await DataServices.getForecastFromServices(queryString).ConfigureAwait(false);

            if (results != null)
            {
                ForecastWeather forecast = new ForecastWeather();
                forecast.ForecastDay = results.forecast.txt_forecast.forecastday[0].title;
                forecast.ForecastText = results.forecast.txt_forecast.forecastday[0].fcttext;

                return forecast;
            }
            else
            {
                return null;
            }
        }

    }

    public class DataServices
    {
        public static async Task<CurrentWeather.RootObject> getCurrentWeatherFromServices(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            CurrentWeather.RootObject data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<CurrentWeather.RootObject>(json);
            }

            return data;
        }

        public static async Task<CurrentForecast.RootObject> getForecastFromServices(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            CurrentForecast.RootObject data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<CurrentForecast.RootObject>(json);
            }

            return data;
        }
    }
}
