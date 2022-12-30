using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class Driver
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }

    
}
