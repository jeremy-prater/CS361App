using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapAppTest.Droid;
using MapAppTest;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMapPositionSetting()
        {
            double testLat = 0;
            double testLong = 0;
            double testRadius = 1;

            MappingEngine newEngine = new MappingEngine(null);

            newEngine.SetMapLocation(testLat, testLong, testRadius);

            Assert.AreEqual(newEngine.GetRadius(), testRadius);
            Assert.AreEqual(newEngine.GetLatitudeDegrees(), testLat);
            Assert.AreEqual(newEngine.GetLongitudeDegrees(), testLong);
            //Assert.IsTrue(false); // Test assert
        }

        [TestMethod]
        public async Task TestWeatherRetrieval()
        {
            // Grab weather for Hillcrest, San Diego :)
            Weather currentWeather = await Core.GetCurrentWeather(32.7497888, -117.1676501);
            Assert.IsNotNull(currentWeather);

            // Debug to verify we get back data
            //Console.WriteLine(currentWeather.Title);
            //Console.WriteLine(currentWeather.Temperature);
            //Console.WriteLine(currentWeather.Wind);
            //Console.WriteLine(currentWeather.Humidity);
            //Console.WriteLine(currentWeather.Visibility);
        } // TestWeatherRetrieval()

        [TestMethod]
        public async Task TestWeatherReturnTitle()
        {
            // Testing to make sure we are getting data for San Diego, CA
            Weather currentWeather = await Core.GetCurrentWeather(32.7497888, -117.1676501);
            // Testing to make sure we are getting data for San Diego, CA
            Assert.AreEqual(currentWeather.Title, "San Diego, CA");
        } // TestWeatherReturnTitle()

        [TestMethod]
        public async Task TestWeatherReturnData()
        {
            // Set up data retrieval
            Weather currentWeather = await Core.GetCurrentWeather(32.7497888, -117.1676501);
            Assert.IsNotNull(currentWeather.Title);
            Assert.IsNotNull(currentWeather.Temperature);
            Assert.IsNotNull(currentWeather.Wind);
            Assert.IsNotNull(currentWeather.Humidity);
            Assert.IsNotNull(currentWeather.Visibility);
        } // Test WeatherReturnData()
    } // UnitTest1
} // UnitTestProject1