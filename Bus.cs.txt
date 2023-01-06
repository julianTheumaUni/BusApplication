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
        public string routeTowns { get; set; }
        public int stopsNum { get; set; }
        public int seatsLeft { get; set; }
        public int accessibility { get; set; }
    }

    
}