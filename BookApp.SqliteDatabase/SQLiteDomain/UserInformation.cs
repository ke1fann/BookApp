using System;
using SQLite;

namespace BookApp.SqliteDatabase.SQLiteDomain
{
    public class UserInformation
    {
        [PrimaryKey]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
