using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Services
{
    public class APIService<T, TInsertion, TUpdate>
    {
        private readonly APIClient _client;

        public APIService(string apiRoute)
        {
            _client =  new APIClient(apiRoute);
        }
        
        

        public Task<List<T>> GetAll()
        {
            return _client.Get<List<T>>();
        }
        
        public Task<T> Create(TInsertion data)
        {
            return _client.Post<T>("", data);
        }
        
        public Task<T> Update(int id, TUpdate data)
        {
            return _client.Put<T>($"/{id}", data);
        }
    }
}