using System;
using SQLite;

namespace BookApp.SqliteDatabase.SQLiteDomain
{
    public class UserInformation
    {
        public string Email { get; set; }
        [PrimaryKey]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
