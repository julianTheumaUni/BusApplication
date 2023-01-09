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
        
        public void AddDriver(DateTime dateOfBirth, string address, string phoneNumber, int userId)
        {
            Debug.WriteLine("Adding Driver...");
            try
            {
                Init();
                Driver driverToAdd = new Driver
                {
                    DateOfBirth = dateOfBirth,
                    Address = address,
                    MobileNumber = phoneNumber,
                    UserId = userId
                };

                conn.Insert(driverToAdd);
                Debug.WriteLine("Successfully added driver");
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }


            /*
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
            */
        }

        public void DeleteDriver(int UserId)
        {
            Init();
            conn.Delete<Driver>(UserId);
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
                if (driver.UserId == driverIdIn)
                {
                    return driver;
                }
            }
            return new Driver { Address="", DateOfBirth=DateTime.Now, MobileNumber=""};
        }
    }
}
