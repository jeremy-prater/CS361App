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

namespace MapAppTest.Droid
{
    [Activity(Label = "MapAppTest", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        LocationManager locMgr;
        private string tag;
        //TextView latitude;
        //TextView longitude;
        private string locationProvider;

        protected override void OnCreate(Bundle bundle)
        {
            //Initialize location manager
            locMgr = GetSystemService(Context.LocationService) as LocationManager;

            // Get Best Location Provider
            Criteria locationCriteria = new Criteria();

            locationCriteria.Accuracy = Accuracy.Coarse;
            locationCriteria.PowerRequirement = Power.Medium;

            locationProvider = locMgr.GetBestProvider(locationCriteria, true);
            if (locationProvider != null)
            {
                //locMgr.RequestLocationUpdates(locationProvider, 2000, 1, this);
            }
            else
            {
                Log.Info(tag, "No location providers available");
            }

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
            double latD;
            double longD;
            latD = locMgr.GetLastKnownLocation(locationProvider).Latitude;
            longD = locMgr.GetLastKnownLocation(locationProvider).Longitude;
            mappingEngine.SetMapLocation(latD, longD, .8);
            mappingEngine.AddMarker(latD, -longD, 0x00303080, "Sample Pin", "123 Street");
            
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

