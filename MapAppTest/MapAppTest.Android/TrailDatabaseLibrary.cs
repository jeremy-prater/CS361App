using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrailDatabaseLibrary
{
    public class TrailDatabase__Trail
    {
        [PrimaryKey, AutoIncrement]
        public int trailID { get; set; }

        public string trailName { get; set; }

        public string trailAddress { get; set; }

        public override string ToString()
        {
            return string.Format("[Trail: ID={0}, trailName={1}, trailAddress={2}]", trailID, trailName, trailAddress);
        }
    }

    public class TrailDatabaseLibrary
    {
        private const string localDBPath = "trailsdb.sqlite";
        private SQLiteAsyncConnection dbConn;

        public async Task<string> CreateConnectionAsync()
        {
            return await createDatabaseAsync();
        }

        public async Task<string> AddTrailAsync(TrailDatabase__Trail newTrail)
        {
            try
            {
                if (await dbConn.InsertAsync(newTrail) != 0)
                {
                    Debug.WriteLine("<<WARNING>> Trail {0} already exist! Updating existing trail data.", newTrail.trailID);
                    await dbConn.UpdateAsync(newTrail);
                }
                return "success";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetAllTrailsAsync()
        {
            try
            {
                List<TrailDatabase__Trail> trailData = await dbConn.QueryAsync<TrailDatabase__Trail>("Select * FROM TrailDatabase__Trail", null);
                return "success";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }

        }

        private async Task<string> createDatabaseAsync()
        {
            try
            {
                dbConn = new SQLiteAsyncConnection(localDBPath);
                {
                    await dbConn.CreateTableAsync<TrailDatabase__Trail>();
                    return "success";
                }
            }

            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
    }
}
