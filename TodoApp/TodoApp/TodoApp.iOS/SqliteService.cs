using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Helpers;
using TodoApp.iOS;
using System.IO;
using Xamarin.Forms;
using SQLite.Net;

[assembly: Dependency(typeof(SqliteService))]
namespace TodoApp.iOS
{
    public class SqliteService : TodoApp.Helpers.ISQLite
    {
        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "todo.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}
