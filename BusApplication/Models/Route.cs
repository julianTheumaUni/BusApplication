using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class Route
    {
        [PrimaryKey, AutoIncrement]
        public int routeNum { get; set; }
        public string routeTown { get; set; }
    }
}
