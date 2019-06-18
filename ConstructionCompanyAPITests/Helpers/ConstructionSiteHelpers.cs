using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using Newtonsoft.Json;

namespace ConstructionCompanyAPITests.Helpers
{
    public class ConstructionSiteHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        private readonly HttpClient _client;

        public ConstructionSiteHelpers(ConstructionCompanyContext persistence, HttpClient client)
        {
            _persistence = persistence;
            _client = client;
        }
        public ConstructionSite CreateConstructionSite()
        {
            var random = new Random();
            var constructionSiteManager = new ConstructionSiteManager
            {
                User = new User()
            };
            var constructionSite = new ConstructionSite
            {
                Title = $"construction site {random.Next()}",
                ProjectWorth = random.Next() * 100,
                Address = $"address {random.Next()}",
                ConstructionSiteManagers = new List<ConstructionSiteSiteManager>
                {
                    new ConstructionSiteSiteManager
                    {
                        ConstructionSiteManager = constructionSiteManager
                    }
                },
                DateStart = DateTime.Now.Add(new TimeSpan(3, 0, 0)),
                DateFinish = DateTime.Now.Add(new TimeSpan(500, 3, 0, 0))
            };
            var inserted = _persistence.ConstructionSites.Add(constructionSite);
            _persistence.SaveChanges();

            return inserted.Entity;
        }
        public async Task<ConstructionSiteVM> GetConstructionSite(int id)
        {
            HttpResponseMessage retrievalHTTPResponse = await _client.GetAsync($"/api/constructionSites/{id}");
            retrievalHTTPResponse.EnsureSuccessStatusCode();
            var stringResponse = await retrievalHTTPResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ConstructionSiteVM>(stringResponse);
        }
    }
}
