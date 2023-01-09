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
    public class BusStopRoutesRepository
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
            conn.CreateTable<Bus>();
        }

        public BusStopRoutesRepository(string dbPathBuses)
        {
            _dbPathBuses = dbPathBuses;
        }

        public void AddBusStopRoute(int RouteID, int BusStopId)
        {
            Debug.WriteLine("Adding Bus Stop Route...");
            try
            {
                Init();

                BusStopRoutes busStopRoutesToAdd = new BusStopRoutes
                {
                    BusRouteId = RouteID,
                    BusStopId = BusStopId
                };

                //busToAdd.setVariables();
                Debug.WriteLine($"Bus Stop Route Id: {busStopRoutesToAdd.BusStopRouteId}");
                conn.Insert(busStopRoutesToAdd);

                Debug.WriteLine("Successfully added a new Bus Stop Route");
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
