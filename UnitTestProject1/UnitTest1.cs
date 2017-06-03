using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapAppTest.Droid;

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

    }
}