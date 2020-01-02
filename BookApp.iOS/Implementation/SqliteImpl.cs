using System;
using System.IO;
using BookApp.iOS.Implementation;
using BookApp.SqliteDatabase;
using BookApp.Utilities.Const;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency(typeof(SqliteImpl))]
namespace BookApp.iOS.Implementation
{
    public class SqliteImpl : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            string filePath;
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            filePath = Path.Combine(libraryPath, BookAppConst.sqliteDatabaseName);

            var connection = new SQLiteConnection(filePath);
            return connection;
        }
    }
}
