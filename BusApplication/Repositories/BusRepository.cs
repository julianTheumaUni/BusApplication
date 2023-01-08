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

        public void AddBus(int BusID, int RouteNum, string RouteTowns, int StopsNum, int SeatsLeft, int Accessibility)
        {
            Debug.WriteLine("Adding Bus...");
            try
            {
                Init();

                conn.Insert(new Bus
                {
                    busId = BusID,
                    routeNum = RouteNum,
                    routeTowns = RouteTowns,
                    stopsNum = StopsNum,
		    seatsLeft = SeatsLeft,
		    accessibility = Accessibility
                });

                Debug.WriteLine("Successfully added a new Bus");
            }
            catch {
                Debug.WriteLine("Error in adding Bus");
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
	    
	public Bus GetBusByID(int busIdIn){
		foreach(bus in App.BusRepo.GetAllBuses()){
			if(bus.busId == busIdIn){
				return bus;
			}
		}
	}
    }
}
