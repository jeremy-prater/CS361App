using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using Android.Util;

namespace MapAppTest.Droid
{
    public class TrailLocationManager : Activity, ILocationListener
    {
        MainActivity parent;
        const string Debug_Tag = "Location";
        LocationManager locMgr;
        Location currentLocation;
        private string locationProvider;

        public TrailLocationManager(MainActivity context)
        {
            parent = context;
            locMgr = context.GetSystemService(Context.LocationService) as LocationManager;

            Criteria locationCriteria = new Criteria
            {
                Accuracy = Accuracy.Fine,
                PowerRequirement = Power.High
            };

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
            locMgr.RequestLocationUpdates(locationProvider, 2000, 1, this);
            Log.Debug(Debug_Tag, "Using " + locationProvider + ".");
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (locMgr.IsProviderEnabled(locationProvider))
            {
                locMgr.RequestLocationUpdates(locationProvider, 2000, 1, this);
            }
            else
            {
                Log.Info(Debug_Tag, locationProvider + " is not available. Does the device have location services enabled?");
            }
        }

        public void OnLocationChanged(Location location)
        {
            currentLocation = location;
            Log.Debug(Debug_Tag, "Updating Position [" + location.Latitude + "," + location.Longitude + "]");
            parent.UpdatedLocation();
        }

        public Location GetLocation()
        {
            return currentLocation;
        }

        protected override void OnPause()
        {
            base.OnPause();
            locMgr.RemoveUpdates(this);
        }

        public void OnProviderDisabled(string provider)
        {
            Log.Debug(Debug_Tag, "Provider Disabled! [" + provider + "]");
        }

        public void OnProviderEnabled(string provider)
        {
            Log.Debug(Debug_Tag, "Provider Enabled! [" + provider + "]");
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            Log.Debug(Debug_Tag, "Provider Status Changed! [" + provider + "]->[" + status.ToString() + "]");

        }
    }
}