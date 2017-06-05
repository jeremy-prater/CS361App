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

        public TrailPlaces currentPlaces;
        public TrailPlaces searchPlaces;

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
            mappingEngine = new MappingEngine(MapPage.GetMap());
            locationManager = new TrailLocationManager(this);
            databaseManager = new TrailDatabaseLibrary(this);

            // More Init code...
            currentPlaces = null;
            searchPlaces = null;
        }

        public void UpdatedLocation()
        {
            Location curLocation = locationManager.GetLocation();
            double radius = mappingEngine.GetRadius();
            mappingEngine.SetMapLocation(curLocation.Latitude, curLocation.Longitude, radius);

            currentPlaces = databaseManager.GetTrailsByLocation(curLocation.Latitude, curLocation.Longitude, radius);
            searchPlaces = databaseManager.GetTrailsByLocation(curLocation.Latitude, curLocation.Longitude, radius * 10);

            // Refactor this into a differential update where the following actions occur:
            // An array of items is created where A = items on map and B = items in DB
            // Remove all items from map where A is not in B
            // Add items to map where B is not in A
            mappingEngine.ClearMarkers();
            foreach (TrailData curTrail in currentPlaces.places)
            {
                mappingEngine.AddMarker(curTrail.lat, curTrail.lon, 0x00303080, curTrail.name, curTrail.city);
            }
        }
    }
}

