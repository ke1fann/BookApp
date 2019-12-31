using System;
using BookApp.SqliteDatabase.SQLiteDomain;
using SQLite;

namespace BookApp.SqliteDatabase.SQLiteDAL
{
    public class SqliteDal : ISqliteDal
    {
        private readonly SQLiteConnection _database;
        public SqliteDal(ISqlite sqlite)
        {
            _database = sqlite.GetConnection();
            _database.CreateTable<UserInformation>();
        }
    }
}
