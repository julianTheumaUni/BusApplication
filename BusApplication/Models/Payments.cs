using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class Payments
    {
        [PrimaryKey, AutoIncrement]
        public int PaymentId { get; set; }
        public bool HasPaid { get; set; }
        public int BusId { get; set; }

    }
}
