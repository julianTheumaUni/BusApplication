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
        public int RouteId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
    }
}
