using System.Collections.Generic;
using System.Net.Http;
using ConstructionCompanyAPI;
using ConstructionCompanyAPITests.Helpers;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class ConstructionSitesControllerTests : IClassFixture<TestFixture<Startup>>

    {
        private readonly HttpClient _client;
        private readonly ConstructionSitesHelpers _constructionSitesHelpers;
        public ConstructionSitesControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
            _constructionSitesHelpers = new ConstructionSitesHelpers(fixture.Persistence);
        }

        [Fact]
        public async void CanRetrieveAllConstructionSites()
        {
            // arrange
            ConstructionSite inserted = _constructionSitesHelpers.CreateConstructionSite();


            // act
            var httpResponse = await _client.GetAsync("/api/constructionSites");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorkers = JsonConvert.DeserializeObject<List<ConstructionSiteVM>>(stringResponse);

            // assert
            Assert.Single(responseWorkers);
            Assert.Equal(inserted.Id, responseWorkers[0].Id);
        }
        
    }
}
