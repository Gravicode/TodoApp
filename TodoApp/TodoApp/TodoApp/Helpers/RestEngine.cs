using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Helpers
{
    public class RestEngine<T> : IDataStore<T> where T : class
    {
        static HttpClient client {set;get;}
        const string Prefix = "http://todoserviceapp.azurewebsites.net/api/Todoes";
        public RestEngine()
        {
            if (client == null)
            {
                client = new HttpClient();
            }
        }
        public async Task<bool> DeleteData(string PK)
        {
            var uri = new Uri(Prefix+$"/{PK}");
            var res = await client.DeleteAsync(uri);
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        
        public async Task<T> GetItem(string PK)
        {
            var uri = new Uri(Prefix + $"/{PK}");
            var res = await client.GetAsync(uri);
            if (res.IsSuccessStatusCode)
            {
                var json = await res.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<T>(json);
                return item;
            }
            return default(T);
        }

        public async Task<IEnumerable<T>> GetItems()
        {
            var uri = new Uri(Prefix);
            var res = await client.GetAsync(uri);
            if (res.IsSuccessStatusCode)
            {
                var json = await res.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<List<T>>(json);
                return item;
            }
            return default(IEnumerable<T>);
        }

        public async Task<bool> InsertData(T item)
        {
            var uri = new Uri(Prefix);
            var Json = JsonConvert.SerializeObject(item);
            var ItemContent = new StringContent(Json);
            var res = await client.PostAsync(uri, ItemContent);
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateData(string PK, T item)
        {
            var uri = new Uri(Prefix + $"/{PK}");
            var Json = JsonConvert.SerializeObject(item);
            var ItemContent = new StringContent(Json);
            var res = await client.PutAsync(uri,ItemContent);
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
