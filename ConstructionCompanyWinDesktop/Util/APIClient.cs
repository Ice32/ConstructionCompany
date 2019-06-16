using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConstructionCompanyWinDesktop.Util
{
    public class APIClient
    {
        private readonly HttpClient _client;
        private readonly string _route;

        public APIClient(string route)
        {
            _client = new HttpClient {BaseAddress = new Uri(Properties.Settings.Default.APIUrl)};
            _route = route;
        }

        public async Task<T> Get<T>(string url = "")
        {
            HttpResponseMessage response = await _client.GetAsync(_route + url);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }
        
        public async Task<T> Post<T>(string url, object data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = await _client.PostAsync(_route + url, new StringContent(serializedData, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }
        
        public async Task<T> Put<T>(string url, object data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = await _client.PutAsync(_route + url, new StringContent(serializedData, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }
    }
}
