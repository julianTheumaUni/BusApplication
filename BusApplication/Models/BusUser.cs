using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class BusUser
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public Types Type { get; set; }
        public int[] BusLogs { get; set; }
        public int[] Payments { get; set; }
    }

    public enum Types
    {
        Student = 1,
        Adult = 2,
        Child = 3,
        Concession = 4
    }
}

//BusUser