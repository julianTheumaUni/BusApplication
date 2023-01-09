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
    public class ArrivalsRepository
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

        public ArrivalsRepository(string dbPathBuses)
        {
            _dbPathBuses = dbPathBuses;
        }

        public void AddArrival(int BusId, int BusStopId, DateTime ExpectedArrival, DateTime ScheduledArrival)
        {
            Debug.WriteLine("Adding Bus...");
            try
            {
                Init();

                Arrivals arrivalsToAdd = new Arrivals
                {
                    BusId = BusId,
                    BusStopId = BusStopId,
                    ExpectedArrival = ExpectedArrival,
                    ScheduledArrival = ScheduledArrival
                };

                conn.Insert(arrivalsToAdd);

                Debug.WriteLine($"Successfully added arrival for bus ID: {arrivalsToAdd.BusId}");
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
        /*
        public Bus GetBusByID(int busIdIn)
        {
            foreach (Bus bus in App.BusRepo.GetAllBuses())
            {
                if (bus.busId == busIdIn)
                {
                    return bus;
                }
            }
            Bus nullBus = new Bus { busId = 0, routeNum = 0, driverId = 0, stopRequest = false, currentStopId = 0, maxSeats = 0, accessibility = false };
            return nullBus;
        }
        */
    }
}
