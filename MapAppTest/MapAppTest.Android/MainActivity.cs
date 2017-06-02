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

            // More Init code...
        }
    }
}

