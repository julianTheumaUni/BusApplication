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
    public class BusUserRepository
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
            conn.CreateTable<BusUser>();
        }

        public BusUserRepository(string dbPathBuses)
        {
            _dbPathBuses = dbPathBuses;
        }

        public void AddBusUser(Types _userType, int _userId)
        {
            Debug.WriteLine("Adding Bus User...");
            try
            {
                Init();

                BusUser busUserToAdd = new BusUser
                {
                    Type = _userType,
                    UserId = _userId
                };

                //busToAdd.setVariables();
                Debug.WriteLine($"Bus User Id: {busUserToAdd.UserId}");
                conn.Insert(busUserToAdd);

                Debug.WriteLine("Successfully added a new Bus");
            }
            catch (Exception ex){
                Debug.WriteLine(ex.ToString());
            }
        }

    }
}
