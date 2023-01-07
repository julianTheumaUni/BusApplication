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
        string _dbPathRoutes;

        SQLiteConnection conn = null;

        private void Init()
        {
            if(conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPathRoutes);
            conn.CreateTable<Route>();
        }

        public RouteRepository(string dbPathRoutes)
        {
            _dbPathRoutes = dbPathRoutes;
        }

        public void AddRoute(int routeNumber, string routeTownName)
        {
            Debug.WriteLine("Adding Route...");
            try
            {
                Init();

                conn.Insert(new Route
                {
                    routeNum = routeNumber,
                    routeTown = routeTownName
                });

                Debug.WriteLine("Successfully added a new Route");
            }
            catch {
                Debug.WriteLine("Error in adding Route");
            }
        }

        public List<Route> GetAllRoutes()
        {
            try
            {
                Init();
                List<Route> list = conn.Table<Route>().ToList();
                Debug.WriteLine($"{list.Count}Routes");
                return conn.Table<Route>().ToList();
            }

            catch
            {
                Console.WriteLine("Error getting all routes");
                return new List<Route>();
            }
        }
    }
}
