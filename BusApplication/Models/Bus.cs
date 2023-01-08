using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using BusApplication.ViewModel;

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
        
        public Route myRoute = GetRouteById(routeNum);
        public Driver myDriver = GetDriverById(driverId);
    }

    
}
