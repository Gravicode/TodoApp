using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Helpers;
using TodoApp.UWP;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteService))]

namespace TodoApp.UWP
{
    public class SqliteService : ISQLite
    {
        public SqliteService()
        {
        }
        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "todo.db3";
            string documentsPath = KnownFolders.DocumentsLibrary.Path;
            //Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            //string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Debug.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var plat = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}
