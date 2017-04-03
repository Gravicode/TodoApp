using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using TodoApp.Droid;
using System.IO;
using TodoApp.Helpers;
using SQLite.Net;

[assembly: Dependency(typeof(SqliteService))]
namespace TodoApp.Droid
{
    public class SqliteService : ISQLite
    {
        public SqliteService() { }

        #region ISQLite implementation
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "todo.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            // Return the database connection 
            return conn;
        }

        #endregion


    }
}