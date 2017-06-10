using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapAppTest.Droid;
using System.Threading.Tasks;

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
        public void TestMapAddPin()
        {
            double testLat = 0;
            double testLong = 0;
            int testColor = 0x00FFFFFF;
            string testLabel = "testLabel";
            string testAddress = "123 Street";

            MappingEngine newEngine = new MappingEngine(null);
            bool result = newEngine.AddMarker(testLat, testLong, testColor, testLabel, testAddress);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestDatabaseConnection()
        {
            // Create a new database object
            TrailDatabaseLibrary newLibrary = new TrailDatabaseLibrary(null);

            // Connect/create the database
            TrailPlaces newPlaces = newLibrary.GetTrailsByLocation(45.650239, -122, 1);

            // Check assert
            Assert.IsTrue(newPlaces.GetNumberOfTrails() > 0);
            Assert.AreEqual(newPlaces.places[0].name, "Beacon Rock State Park");
        }

        [TestMethod]
        public void TestWeatherRetrieval()
        {
            // Grab weather for Hillcrest, San Diego :)
            Task<Weather> currentWeatherTask = WeatherCore.GetCurrentWeather(32.7497888, -117.1676501);
            currentWeatherTask.Wait();
            Weather currentWeather = currentWeatherTask.Result;
            Assert.IsNotNull(currentWeather);

            // Debug to verify we get back data
            //Console.WriteLine(currentWeather.Title);
            //Console.WriteLine(currentWeather.Temperature);
            //Console.WriteLine(currentWeather.Wind);
            //Console.WriteLine(currentWeather.Humidity);
            //Console.WriteLine(currentWeather.Visibility);
        } // TestWeatherRetrieval()

        [TestMethod]
        public void TestWeatherReturnTitle()
        {
            // Testing to make sure we are getting data for San Diego, CA
            Task<Weather> currentWeatherTask = WeatherCore.GetCurrentWeather(32.7497888, -117.1676501);
            currentWeatherTask.Wait();
            Weather currentWeather = currentWeatherTask.Result;
            Assert.IsNotNull(currentWeather);
            // Testing to make sure we are getting data for San Diego, CA
            Assert.AreEqual(currentWeather.Title, "San Diego, CA");
        } // TestWeatherReturnTitle()

        [TestMethod]
        public void TestWeatherReturnData()
        {
            // Set up data retrieval
            Task<Weather> currentWeatherTask = WeatherCore.GetCurrentWeather(32.7497888, -117.1676501);
            currentWeatherTask.Wait();
            Weather currentWeather = currentWeatherTask.Result;
            Assert.IsNotNull(currentWeather);

            Assert.IsNotNull(currentWeather.Title);
            Assert.IsNotNull(currentWeather.Temperature);
            Assert.IsNotNull(currentWeather.Wind);
            Assert.IsNotNull(currentWeather.Humidity);
            Assert.IsNotNull(currentWeather.Visibility);
        } // Test WeatherReturnData()

    }
}