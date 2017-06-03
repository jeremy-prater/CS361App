using Xamarin.Forms.Maps;
using Android.Graphics;
using Android.Locations;

public class MappingEngine
{
    double currentLat;
    double currentLong;
    double currentRadius;

    Map localMap = null;

    public MappingEngine (Map newMap)
    {
        // Oh no... I made it a singleton.
        // Please use mutexes or other blocking calls
        // to access critical map data.
        localMap = newMap;
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