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

        public int AddUser(UserType userType )
        {
            Debug.WriteLine("Adding User...");
            try
            {
                Init();

                User userToAdd = new User { UserType = userType };

                //busToAdd.setVariables();
                Debug.WriteLine($"User Id: {userToAdd.UserId}");
                Debug.WriteLine($"User Type: {userToAdd.UserType}");
                int insertedId = conn.Insert(userToAdd);
                Debug.WriteLine("Successfully added a new User");
                
                return insertedId;
            }
            catch (Exception ex){
                Debug.WriteLine(ex.ToString());
                return -1;
            }
        }
        public User GetUserFromId(int userId)
        {
            Init();
            var item = conn.Table<User>().Where(i => i.UserId == userId).FirstOrDefault();
            return item;
        }

        public List<User> GetAllUsers()
        {
            Init();
            var userList = conn.Table<User>().ToList();
            return userList;
        }

        public void DeleteUser(int UserId)
        {
            Init();
            conn.Delete<User>(UserId);
        }

        public UserType GetUserTypeFromId(int UserId)
        {
            try
            {

            Init();
            var item = conn.Table<User>().Where(i => i.UserId == App.LoggedInUserId).FirstOrDefault();
            return item.UserType;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return UserType.BusUser;
            }
        }

        public void EditUser(int userIdToChange, User updatedUser)
        {
            Init();

            var item = conn.Table<User>().Where(i => i.UserId == userIdToChange).FirstOrDefault();

            if(item != null)
            {
                item = updatedUser;
                conn.Update(item);
            }
        }
    }
}
