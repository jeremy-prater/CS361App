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
        public MappingEngine mappingEngine = null;
        public TrailLocationManager locationManager = null;
        public TrailDatabaseLibrary databaseManager = null;

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
            mappingEngine = new MappingEngine(MainPage.GetMap());
            locationManager = new TrailLocationManager(this);
            databaseManager = new TrailDatabaseLibrary(this);

            // More Init code...
        }

        public void UpdatedLocation()
        {
            Location curLocation = locationManager.GetLocation();
            mappingEngine.SetMapLocation(curLocation.Latitude, curLocation.Longitude, .8);

            TrailPlaces currentPlaces = databaseManager.GetTrailsByLocation(curLocation.Latitude, curLocation.Longitude, .8);
            mappingEngine.ClearMarkers();
            foreach (TrailData curTrail in currentPlaces.places)
            {
                mappingEngine.AddMarker(curTrail.lat, curTrail.lon, 0x00303080, curTrail.name, curTrail.city);
            }
        }
    }
}

