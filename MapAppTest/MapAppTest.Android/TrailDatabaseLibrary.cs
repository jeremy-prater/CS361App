using Android.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;
using Xamarin.Forms;

namespace MapAppTest.Droid
{
    public class TrailData
    {
        public string name;
        public string city;
        public string state;
        public string country;
        public string directions;
        public string description;
        public double lat;
        public double lon;
    };

    public class TrailPlaces
    {
        public TrailData[] places;

        public int GetNumberOfTrails()
        {
            if (places != null)
                return places.Length;
            else
                return 0;
        }
    }
    public class TrailDatabaseLibrary
    {
        //MainActivity context;
        const string Debug_Tag = "TrailDB";

        public TrailDatabaseLibrary (object parent)
        {
            //context = parent;
        }
        public TrailPlaces GetTrailsByLocation(double locLat, double locLong, double radius)
        {
            string requestAPI = "https://trailapi-trailapi.p.mashape.com/?lat=" +
                locLat.ToString() +
                "&limit=50&lon=" +
                locLong.ToString() +
                "&radius=" +
                radius.ToString();
            HttpResponse<string> response = Unirest.get(requestAPI)
            .header("X-Mashape-Key", "AWH2MCAi96mshwBrZ3fyOc8qhUhRp1scsoNjsnMLietLmi8SMd")
            .header("Accept", "text/plain")
            .asString();

            TrailPlaces trailData = JsonConvert.DeserializeObject<TrailPlaces>(response.Body);
            return trailData;
        }
    }
}
