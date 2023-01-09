using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class Arrivals
    {
        [ForeignKey(nameof(Bus))]
        public int BusId { get; set; }
        
        public DateTime ScheduledArrival { get; set; }
        public DateTime ExpectedArrival { get; set; }
        [ForeignKey(nameof(BusStop))]
        public int BusStopId { get; set; }
    }

}
