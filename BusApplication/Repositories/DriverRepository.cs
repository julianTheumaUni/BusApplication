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
    public class DriverRepository
    {
        string _dbPath;

        SQLiteConnection conn = null;

        private void Init()
        {
            if(conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Driver>();
        }

        public DriverRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddDriver(DateTime dateOfBirth, string address, string phoneNumber, string name)
        {
            Debug.WriteLine("Adding Driver...");
            try
            {
                Init();

                conn.Insert(new Driver
                {
                    DateOfBirth = dateOfBirth,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    Name = name
                });

                Debug.WriteLine("Successfully added a new Driver");
            }
            catch {
                Debug.WriteLine("Error in adding Driver");
            }
        }

        public List<Driver> GetAllDrivers()
        {
            try
            {
                Init();
                List<Driver> list = conn.Table<Driver>().ToList();
                Debug.WriteLine($"{list.Count}Drivers");
                return conn.Table<Driver>().ToList();
            }

            catch
            {
                Console.WriteLine("Error getting all drivers");
                return new List<Driver>();
            }
        }

        public Driver GetDriverByID(int driverIdIn)
        {
            foreach (Driver driver in App.DriverRepo.GetAllDrivers())
            {
                if (driver.Id == driverIdIn)
                {
                    return driver;
                }
            }
            Driver nullDriver = new Driver { Id = 0, DateOfBirth = System.DateTime.Now, Name = "N/A", PhoneNumber = "N/A", Address = "N/A", BusNumber = 0 };
            return nullDriver;
        }
    }
}
