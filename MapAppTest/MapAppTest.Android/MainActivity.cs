using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Maps;
using Android.Graphics;

namespace MapAppTest.Droid
{
    [Activity(Label = "MapAppTest", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
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

            // Local program setup.
            mappingEngine.SetMapLocation(21.353063, -158.132459, .8);
            mappingEngine.AddMarker(21.353063, -158.132459, Color.Yellow);
        }
    }
}

