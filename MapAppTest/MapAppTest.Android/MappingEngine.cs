using Xamarin.Forms.Maps;
using Android.Graphics;
using Android.Locations;
using Android.Util;

namespace MapAppTest.Droid
{
    public class MappingEngine
    {
        double currentLat;
        double currentLong;
        double currentRadius;

        Map localMap = null;
        const string Debug_Tag = "MappingEngine";

        public MappingEngine(Map newMap)
        {
            // Oh no... I made it a singleton.
            // Please use mutexes/locks or other blocking calls
            // to access critical map data.
            localMap = newMap;

            // Set default radius to 1
            currentRadius = 1;

            // Setup mapping event hooks
            if (localMap != null)
            {
                localMap.PropertyChanged += LocalMap_PropertyChanged;
            }
        }

        private void LocalMap_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Log.Debug(Debug_Tag, "Map Property Changed: [" + e.PropertyName + "]->[" + e.ToString() + "]");
            if (e.PropertyName.CompareTo("VisibleRegion") == 0)
            {
                SynchronizeMapLocation(localMap.VisibleRegion.LatitudeDegrees, localMap.VisibleRegion.LongitudeDegrees, localMap.VisibleRegion.Radius.Kilometers);
                //parent.UpdatedLocation(false);
            }
        }

        public void SynchronizeMapLocation(double newLat, double newLong, double radius)
        {
            currentLat = newLat;
            currentLong = newLong;
            currentRadius = radius;
        }

        public MapSpan SetMapLocation(double newLat, double newLong, double radius)
        {
            currentLat = newLat;
            currentLong = newLong;
            currentRadius = radius;

            MapSpan result = MapSpan.FromCenterAndRadius(
                   new Position(currentLat, currentLong),
                   Distance.FromMiles(radius));

            // Preform null check
            if (localMap != null)
            {
                localMap.MoveToRegion(result);
            }
            return result;
        }

        public void ClearMarkers()
        {
            // Preform null check
            if (localMap != null)
            {
                localMap.Pins.Clear();
            }
        }

        public bool AddMarker(double markerLat, double markerLong, int color, string label, string address)
        {
            Pin newPin = new Pin();
            newPin.Type = PinType.Place;
            newPin.Position = new Position(markerLat, markerLong);
            newPin.Label = label;
            newPin.Address = address;

            // Preform null check
            if (localMap != null)
            {
                //Color pinColor = new Color(color);
                localMap.Pins.Add(newPin);
            }
            return true;
        }

        public double GetLatitudeDegrees()
        {
            return currentLat;
        }

        public double GetLongitudeDegrees()
        {
            return currentLong;
        }

        public double GetRadius()
        {
            return currentRadius;
        }
    }
}