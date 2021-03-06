﻿using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoApp.Helpers
{
    public class LocalDb<T> : IDataStore<T> where T : class
    {
        static SQLiteConnection db { set; get; }
        public LocalDb()
        {
            if (db == null)
            {
                db = DependencyService.Get<ISQLite>().GetConnection();

            }
            db.CreateTable<T>();
        }
        public Task<bool> DeleteData(string PK)
        {
            try
            {
                var xx = db.Delete<T>(PK);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<T> GetItem(string PK)
        {
            try
            {
                var res = db.Get<T>(PK);
                return Task.FromResult(res);
            }
            catch (Exception)
            {
                return Task.FromResult( default(T));
            }
        }

        public Task<IEnumerable<T>> GetItems()
        {
            try
            {
                var res = db.Query<T>("select * from Todo");
                return Task.FromResult(res.AsEnumerable());
            }
            catch
            {
                return Task.FromResult(default(IEnumerable<T>));
            }
        }

        public Task<bool> InsertData(T item)
        {
            try
            {
                db.Insert(item);
                return Task.FromResult( true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateData(string PK, T item)
        {
            try
            {
                db.Update(item);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
