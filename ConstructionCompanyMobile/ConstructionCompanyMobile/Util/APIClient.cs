using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConstructionCompanyMobile.Util
{
    public class APIClient
    {
        private const string APIUrl = "http://localhost:52374/api/";
        private static string _username;
        private static string _password;
        public static void SetCredentials(string username, string password)
        {
            _username = username;
            _password = password;
        }
        
        private readonly HttpClient _client;
        private readonly string _route;

        public APIClient(string route)
        {
            _client = new HttpClient {BaseAddress = new Uri(APIUrl)};
            _route = route;
        }

        private void ReadCredentials()
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes($"{_username}:{_password}");
            string encoded = Convert.ToBase64String(plainTextBytes);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
        }

        public async Task<T> Get<T>(string url = "")
        {
            ReadCredentials();
            HttpResponseMessage response = await _client.GetAsync(_route + url);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }
        
        public async Task<T> Post<T>(string url, object data)
        {
            ReadCredentials();
            string serializedData = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = await _client.PostAsync(_route + url, new StringContent(serializedData, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }
        
        public async Task<T> Put<T>(string url, object data)
        {
            ReadCredentials();
            string serializedData = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = await _client.PutAsync(_route + url, new StringContent(serializedData, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }
    }
}
