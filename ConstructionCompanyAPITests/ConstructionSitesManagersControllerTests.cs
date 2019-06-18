using System.Collections.Generic;
using System.Net.Http;
using ConstructionCompanyAPI;
using ConstructionCompanyAPITests.Helpers;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class ConstructionSitesManagerControllersTests : IClassFixture<TestFixture<Startup>>

    {
        private readonly HttpClient _client;
        private readonly ConstructionSiteManagerHelpers _constructionSiteManagerHelpers;
        public ConstructionSitesManagerControllersTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
            _constructionSiteManagerHelpers = new ConstructionSiteManagerHelpers(fixture.Persistence);
        }

        [Fact]
        public async void CanRetrieveAllConstructionSiteManagers()
        {
            // arrange
            ConstructionSiteManager inserted = _constructionSiteManagerHelpers.CreateConstructionSiteManager();


            // act
            HttpResponseMessage httpResponse = await _client.GetAsync("/api/constructionSiteManagers");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseConstructionSIteManagers = JsonConvert.DeserializeObject<List<ConstructionSiteManagerVM>>(stringResponse);

            // assert
            Assert.Single(responseConstructionSIteManagers);
            Assert.Equal(inserted.Id, responseConstructionSIteManagers[0].Id);
        }
        
    }
}
