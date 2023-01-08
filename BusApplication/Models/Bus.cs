using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class Bus
    {
        [PrimaryKey, AutoIncrement]
        public int busId { get; set; }
        public int routeNum { get; set; }
        public int driverId { get; set; }
        public bool stopRequest { get; set; }
        public int currentStopId { get; set; }
        public int maxSeats { get; set; }
        public int seatsLeft { get; set; }
        public bool accessibility { get; set; }

        public Route myRoute { get; set; }
        public Driver myDriver { get; set; }

        public void setVariables()
        {
            seatsLeft = maxSeats;
            myRoute = App.RouteRepo.GetRouteByID(routeNum);
            myDriver = App.DriverRepo.GetDriverByID(driverId);
        }
    }
}
