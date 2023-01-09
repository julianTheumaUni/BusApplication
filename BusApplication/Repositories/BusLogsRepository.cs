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
    public class BusLogsRepository
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

        public BusLogsRepository(string dbPathBuses)
        {
            _dbPathBuses = dbPathBuses;
        }

        public void AddBusLogs(int BusId, int UserId, DateTime TimeEntered)
        {
            Debug.WriteLine("Adding Bus Log...");
            try
            {
                Init();

                BusLogs busLogToAdd = new BusLogs
                {
                    BusId = BusId,
                    TimeEntered = TimeEntered,
                    UserId = UserId
                };

                conn.Insert(busLogToAdd);
              
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
