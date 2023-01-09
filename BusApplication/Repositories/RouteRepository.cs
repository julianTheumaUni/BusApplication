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
    public class RouteRepository
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

        public void AddRoute(string StartLocation, string EndLocation)
        {
            Debug.WriteLine("Adding Route...");
            try
            {
                Init();

                conn.Insert(new Route
                {
                    StartLocation = StartLocation,
                    EndLocation = EndLocation
                });

                Debug.WriteLine($"Successfully added a new Route {StartLocation} to {EndLocation}");
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
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

        public Route GetRouteByID(int routeIdIn)
        {
            /*
            foreach (Route route in App.RouteRepo.GetAllRoutes())
            {
                if (route.routeNum == routeIdIn)
                {
                    return route;
                }
            }
            Route nullRoute = new Route { routeNum = 0, routeTown = "N/A" };
            return nullRoute;
            */
            return new Route { EndLocation = "Bye", StartLocation = "Hello" };
        }
    }
}
