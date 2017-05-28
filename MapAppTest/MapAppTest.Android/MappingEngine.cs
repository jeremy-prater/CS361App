using Xamarin.Forms.Maps;

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

    public MapSpan SetMapLocation(double lat, double log, double radius)
    {
        currentLat = lat;
        currentLong = log;
        currentRadius = radius;

        MapSpan result = MapSpan.FromCenterAndRadius(
               new Position(lat, log),
               Distance.FromMiles(radius));

        // Preform null check
        if (localMap != null)
        {
            localMap.MoveToRegion(result);
        }
        return result;
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