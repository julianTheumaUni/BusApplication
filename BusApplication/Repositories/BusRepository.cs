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
    public class BusRepository
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

        public BusRepository(string dbPathBuses)
        {
            _dbPathBuses = dbPathBuses;
        }

        public void AddBus(bool Accessibility, int Capacity, int RouteId)
        {
            Debug.WriteLine("Adding Bus...");
            try
            {
                Init();

                Bus busToAdd = new Bus
                {
                    Accessibility = Accessibility,
                    Capacity = Capacity,
                    OccupiedSeats = 0,
                    RouteId = RouteId,
                    StopRequested = false
                };

                //busToAdd.setVariables();
                Debug.WriteLine($"Bus Id: {busToAdd.BusId}");
                conn.Insert(busToAdd);

                Debug.WriteLine("Successfully added a new Bus");
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

        //public Bus GetBusByID(int busIdIn)
        //{
            /*
            foreach (Bus bus in App.BusRepo.GetAllBuses())
            {
                if (bus.busId == busIdIn)
                {
                    return bus;
                }
            }
            Bus nullBus = new Bus { busId = 0, routeNum = 0, driverId = 0, stopRequest = false, currentStopId = 0, maxSeats = 0, accessibility = false };
            return nullBus;
            */
        //}
    }
}
