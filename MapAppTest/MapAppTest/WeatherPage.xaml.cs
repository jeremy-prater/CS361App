using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapAppTest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
		public WeatherPage ()
		{
			InitializeComponent ();

            LoadData();
		}

        public async void LoadData()
        {
            Weather currentWeather = await Core.GetCurrentWeather(21.353063, -158.132459);
            ForecastWeather forecast = await Core.GetCurrentForecast(21.353063, -158.132459);

            WeatherData weather = new WeatherData();
            weather.Title = currentWeather.Title;
            weather.Temperature = currentWeather.Temperature;
            weather.Wind = currentWeather.Wind;
            weather.Humidity = currentWeather.Humidity;
            weather.Visibility = currentWeather.Visibility;
            weather.ForecastDay = forecast.ForecastDay;
            weather.ForecastText = forecast.ForecastText;

            this.BindingContext = weather;
        }

        public class WeatherData
        {
            public string Title { get; set; }
            public string Temperature { get; set; }
            public string Wind { get; set; }
            public string Humidity { get; set; }
            public string Visibility { get; set; }
            public string ForecastDay { get; set; }
            public string ForecastText { get; set; }

            public WeatherData()
            {
                this.Title = " ";
                this.Temperature = " ";
                this.Wind = " ";
                this.Humidity = " ";
                this.Visibility = " ";
                this.ForecastDay = " ";
                this.ForecastText = " ";
            }
        }
	}
}