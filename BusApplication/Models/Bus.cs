using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class Bus
    {
        [PrimaryKey, AutoIncrement]
        public int BusId { get; set; }

        [ForeignKey(nameof(Route))]
        public int RouteId { get; set; }

        [ForeignKey(nameof(Driver))]
        public int? DriverId { get; set; }
        public bool Accessibility { get; set; }
        public bool StopRequested { get; set; }

        [ForeignKey(nameof(BusStop))]
        public int? CurrentBusStopId { get; set; }
        public int Capacity { get; set; }
        public int OccupiedSeats { get; set; }
        

        public void setVariables()
        {
        //    seatsLeft = maxSeats;
            //myRoute = App.RouteRepo.GetRouteByID(routeNum);
            //myDriver = App.DriverRepo.GetDriverByID(driverId);
        }
    }
}
