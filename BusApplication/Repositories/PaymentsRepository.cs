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
    public class PaymentsRepository
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
            conn.CreateTable<Bus>();
        }

        public PaymentsRepository(string dbPathBuses)
        {
            _dbPathBuses = dbPathBuses;
        }

        public void AddPayment()
        {
            Debug.WriteLine("Adding Payment...");
            try
            {
                Init();

                Payments paymentsToAdd = new Payments
                {
                    HasPaid = false,
                    UserId = 1,
                    BusId = 1,
                };

                //busToAdd.setVariables();
                Debug.WriteLine($"Bus Id: {paymentsToAdd.PaymentId}");
                conn.Insert(paymentsToAdd);

                Debug.WriteLine("Successfully added a new Payment");
            }
            catch (Exception ex){
                Debug.WriteLine(ex.ToString());
            }
        }

        public List<Bus> GetAllBuses()
        {
            try
            {
                Init();
                List<Bus> list = conn.Table<Bus>().ToList();
                Debug.WriteLine($"{list.Count}Buses");
                return conn.Table<Bus>().ToList();
            }

            catch
            {
                Console.WriteLine("Error getting all buses");
                return new List<Bus>();
            }
        }

    }
}
