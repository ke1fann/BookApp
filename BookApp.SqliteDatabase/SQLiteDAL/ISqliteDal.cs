using System;
using BookApp.SqliteDatabase.SQLiteDomain;

namespace BookApp.SqliteDatabase.SQLiteDAL
{
    public interface ISqliteDal 
    {
        bool Register(UserInformation userInformation);
        bool Login(string email, string password);
        bool IsInvalidUser(string email);
        UserInformation GetUserInformation(string email);
    }
}
