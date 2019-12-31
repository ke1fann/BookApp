using System;
using SQLite;

namespace BookApp.SqliteDatabase
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
