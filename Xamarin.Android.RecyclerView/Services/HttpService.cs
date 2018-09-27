using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Android.RecyclerView.Model;

namespace Xamarin.Android.RecyclerView.Services
{
    public class HttpService<T> : IHttpService<T> where T : class
    {
        private static string base_url = "https://jsonplaceholder.typicode.com/comments";

        public async Task<List<T>> GetDataAsync()
        {
            List<T> jsonResult= null;

            var request = new HttpRequestMessage();
            var client = new HttpClient();

            request.RequestUri = new Uri(base_url);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent content = response.Content;
                var json = await content.ReadAsStringAsync();
                jsonResult = JsonConvert.DeserializeObject<List<T>>(json);
            }

            return jsonResult;

        }

        public void DeleteData(int id)
        {
            throw new NotImplementedException();
        }

        public void PutData(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(int id)
        {
            throw new NotImplementedException();
        }
    }
}