using BusApplication.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusApplication.Repositories
{
    public class UserRepository
    {
        string _dbPathBuses;

        SQLiteConnection conn = null;

        private void Init()
        {
            if(conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPathBuses);
            conn.CreateTable<User>();
        }

        public UserRepository(string dbPathBuses)
        {
            _dbPathBuses = dbPathBuses;
        }

        public void AddUser(UserType userType )
        {
            Debug.WriteLine("Adding User...");
            try
            {
                Init();

                User userToAdd = new User { UserType = userType };

                //busToAdd.setVariables();
                Debug.WriteLine($"User Id: {userToAdd.UserId}");
                Debug.WriteLine($"User Type: {userToAdd.UserType}");
                conn.Insert(userToAdd);

                Debug.WriteLine("Successfully added a new User");
            }
            catch (Exception ex){
                Debug.WriteLine(ex.ToString());
            }
        }

    }
}
