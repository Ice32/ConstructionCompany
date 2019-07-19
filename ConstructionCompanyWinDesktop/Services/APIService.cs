using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Services
{
    public class APIService<T, TInsertion, TUpdate>
    {
        protected readonly APIClient Client;

        public APIService(string apiRoute)
        {
            Client =  new APIClient(apiRoute);
        }
        
        

        public Task<List<T>> GetAll()
        {
            return Client.Get<List<T>>();
        }
        
        public Task<T> Create(TInsertion data)
        {
            return Client.Post<T>("", data);
        }
        
        public Task<T> Update(int id, TUpdate data)
        {
            return Client.Put<T>($"/{id}", data);
        }
    }
}