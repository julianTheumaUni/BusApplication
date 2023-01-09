using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class BusStop
    {
        [PrimaryKey, AutoIncrement]
        public int BusStopId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int[] Arrivals { get; set; }
        
        public string City { get; set; }
    }
}
