using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BusApplication.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        public UserType UserType { get; set; }

    }

    public enum UserType
    {
        BusUser = 1,
        BusDriver = 2,
        DriverManager = 3,
        UserManager = 4,
        Admin = 5
    }
}
