using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapAppTest.Droid;
using MapAppTest;
using Xamarin.Forms.Maps;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
    }
}
