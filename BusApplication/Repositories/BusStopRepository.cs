using BusApplication.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusApplication.Repositories
{
    public class BusStopRepository
    {
        string _dbPathBuses;

        SQLiteConnection conn = null;

        private void Init()
        {
            if(conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPathBuses);
            conn.CreateTable<BusStop>();
        }

        public BusStopRepository(string dbPathBuses)
        {
            _dbPathBuses = dbPathBuses;
        }

        public void AddBusStop(float Longitude, float Latitude, string City)
        {
            Debug.WriteLine("Adding Bus Stop...");
            try
            {
                Init();

                BusStop busStopToAdd = new BusStop
                {
                    Longitude = Longitude,
                    Latitude = Latitude,
                    City = City
                };
                //busToAdd.setVariables();
                Debug.WriteLine($"Bus Stop Id: {busStopToAdd.BusStopId}");
                conn.Insert(busStopToAdd);

                Debug.WriteLine("Successfully added a new Bus Stop");
            }
            catch (Exception ex){
                Debug.WriteLine(ex.ToString());
            }
        }

        public List<Bus> GetAllBuses()
        {
            try
            {
                Init();
                List<Bus> list = conn.Table<Bus>().ToList();
                Debug.WriteLine($"{list.Count}Buses");
                return conn.Table<Bus>().ToList();
            }

            catch
            {
                Console.WriteLine("Error getting all buses");
                return new List<Bus>();
            }
        }

 
    }
}
