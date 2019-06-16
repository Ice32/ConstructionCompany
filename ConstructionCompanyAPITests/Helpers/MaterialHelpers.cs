using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Newtonsoft.Json;

namespace ConstructionCompanyAPITests.Helpers
{
    public class MaterialHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        private readonly HttpClient _client;
        
        public MaterialHelpers(ConstructionCompanyContext persistence, HttpClient client)
        {
            _persistence = persistence;
            _client = client;
        }
        public Material CreateMaterial()
        {
            var random = new Random();
            var material = new Material
            {
                Name = $"Material {random.Next()}",
                Amount = 300
            };
           
            var inserted = _persistence.Material.Add(material);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
        
        public async Task<MaterialVM> GetMaterialById(int id)
        {
            HttpResponseMessage retrievalHTTPResponse = await _client.GetAsync($"/api/materials/{id}");
            retrievalHTTPResponse.EnsureSuccessStatusCode();
            var stringResponse = await retrievalHTTPResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MaterialVM>(stringResponse);
        }
    }
}
