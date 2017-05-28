using Xamarin.Forms.Maps;

public class MappingEngine
{
    double currentLat;
    double currentLong;
    double currentRadius;

    Map localMap = null;

    public MappingEngine (Map newMap)
    {
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