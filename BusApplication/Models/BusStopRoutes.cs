using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class BusStopRoutes
    {
        public int BusStopRouteId { get; set; }

        [ForeignKey(nameof(BusStop))]
        public int BusStopId { get; set; }

        [ForeignKey(nameof(Route))]
        public int BusRouteId { get; set; }
    }

}
