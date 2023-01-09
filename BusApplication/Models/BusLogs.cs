using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class BusLogs
    {
        [PrimaryKey, AutoIncrement]
        public int BusLogId { get; set; }
        
        [ForeignKey(nameof(BusUser))]
        public int UserId { get; set; }

        [ForeignKey(nameof(Bus))]
        public int BusId { get; set; }
        
        public DateTime TimeEntered { get; set; }
    }

}
