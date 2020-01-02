using System;
using BookApp.SqliteDatabase.SQLiteDAL;
using BookApp.SqliteDatabase.SQLiteDomain;
using SQLite;
using Xamarin.Forms;


namespace BookApp.SqliteDatabase.SQLiteDAL
{
    public class SqliteDal : ISqliteDal
    {
        private readonly SQLiteConnection _database;

        public SqliteDal()
        {
            _database = DependencyService.Get<ISqlite>().GetConnection();
            
            _database.CreateTable<UserInformation>();
        }

        public UserInformation GetUserInformation(string email)
        {
            return _database.Table<UserInformation>().FirstOrDefault(t => t.Email == email);

        }

        public bool IsInvalidUser(string email)
        {
            return _database.Table<UserInformation>().FirstOrDefault(t => t.Email == email) != null;
        }

        public bool Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return false;
            return _database.Table<UserInformation>().FirstOrDefault(t => t.Email == email && t.Password == password) != null;
        }

        public bool Register(UserInformation userInformation)
        {
            try
            {
                if (userInformation == null) return false;
                int result = 0;
                var user = _database.Table<UserInformation>().FirstOrDefault(t => t.Email == userInformation.Email);
                if (user == null)
                {
                    result = _database.Insert(userInformation);
                }
                else
                {
                    result = _database.Update(userInformation);
                }

                return result > 0;
            }
            catch (Exception e)
            {

            }
            return false;
        }


    }
}
