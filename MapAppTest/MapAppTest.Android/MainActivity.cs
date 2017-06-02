using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Maps;
using Android.Locations;
using Android.Content;
using Android.Util;
using System.Collections.Generic;
using System.Linq;

namespace MapAppTest.Droid
{
    [Activity(Label = "MapAppTest", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        LocationManager locMgr;
        Location location;
        private string tag;
        //TextView latitude;
        //TextView longitude;
        private string locationProvider;

        protected override void OnCreate(Bundle bundle)
        {

            // UI Stuff
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            // Xamarin init
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);

            // Launch!
            LoadApplication(new MapAppTest.App());

            // Application Init Section
            MappingEngine mappingEngine = new MappingEngine(MainPage.GetMap());

            // Get device location and set map starting point to that location.
            InitializeLocationManager();
            double latD;
            double longD;
            IList<String> providers = locMgr.GetProviders(true);
           
            latD = location.Latitude;
            longD = location.Longitude;
            mappingEngine.SetMapLocation(latD, longD, .8);
            mappingEngine.AddMarker(latD, longD, 0x00303080, "Sample Pin", "123 Street");
            
        }

        void InitializeLocationManager()
        {
            locMgr = (LocationManager)GetSystemService(LocationService);

            Criteria locationCriteria = new Criteria;
            
            locationCriteria.Accuracy = Accuracy.Coarse;
            locationCriteria.PowerRequirement = Power.Medium;
            locationProvider = locMgr.GetBestProvider(locationCriteria, true);
            IList<string> acceptableLocationProviders = locMgr.GetProviders(locationCriteria, true);

            if (acceptableLocationProviders.Any())
            {
                locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                locationProvider = string.Empty;
            }
            Log.Debug(tag, "Using " + locationProvider + ".");
        }


       
        protected override void OnResume()
        {
            base.OnResume();
            locMgr.RequestLocationUpdates(locationProvider, 0, 0, this);
        }

        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    string Provider = LocationManager.GpsProvider;

        //    if (locMgr.IsProviderEnabled(Provider))
        //    {
        //        locMgr.RequestLocationUpdates(Provider, 2000, 1, this);
        //    }
        //    else
        //    {
        //        Log.Info(tag, Provider + " is not available. Does the device have location services enabled?");
        //    }
        //}

        //public void OnLocationChanged(Location location)
        //{
        //    latitude.Text = "Latitude: " + location.Latitude;
        //    longitude.Text = "Longitude: " + location.Longitude;
        //}

        //protected override void OnPause()
        //{
        //    base.OnPause();
        //    locMgr.RemoveUpdates(this);
        //}
    }
}

