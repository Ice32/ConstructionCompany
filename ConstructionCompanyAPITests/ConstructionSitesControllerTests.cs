using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ConstructionCompanyAPI;
using ConstructionCompanyAPITests.Helpers;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class ConstructionSitesControllerTests : IClassFixture<TestFixture<Startup>>

    {
        private readonly HttpClient _client;
        private readonly ConstructionSiteHelpers _constructionSiteHelpers;
        private readonly ConstructionSiteManagerHelpers _constructionSiteManagerHelpers;

        public ConstructionSitesControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
            _constructionSiteHelpers = new ConstructionSiteHelpers(fixture.Persistence, fixture.Client);
            _constructionSiteManagerHelpers = new ConstructionSiteManagerHelpers(fixture.Persistence);
        }

        [Fact]
        public async void CanRetrieveAllConstructionSites()
        {
            // arrange
            ConstructionSite inserted = _constructionSiteHelpers.CreateConstructionSite();


            // act
            HttpResponseMessage httpResponse = await _client.GetAsync("/api/constructionSites");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorkers = JsonConvert.DeserializeObject<List<ConstructionSiteVM>>(stringResponse);

            // assert
            Assert.Single(responseWorkers);
            Assert.Equal(inserted.Id, responseWorkers[0].Id);
        }
        
        [Fact]
        public async void CanCreateConstructionSite()
        {
            // arrange
            ConstructionSiteManager user = _constructionSiteManagerHelpers.CreateConstructionSiteManager();
            var constructionSite = new ConstructionSiteAddVM
            {
                Title = "Test title",
                Description = "Test description",
                ConstructionSiteManagerId = user.Id
            };

            string data = JsonConvert.SerializeObject(constructionSite);

            // act
            HttpResponseMessage httpResponse = await _client.PostAsync(
                "/api/constructionSites",
                new StringContent(data, Encoding.UTF8, "application/json")
            );
            httpResponse.EnsureSuccessStatusCode();
            string stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseConstructionSite = JsonConvert.DeserializeObject<ConstructionSiteVM>(stringResponse);

            // assert
            Assert.NotNull(responseConstructionSite);
            ConstructionSiteVM inserted = await _constructionSiteHelpers.GetConstructionSite(responseConstructionSite.Id);
            Assert.Equal(inserted.Title, constructionSite.Title);
            Assert.Equal(inserted.Description, constructionSite.Description);
            Assert.NotNull(inserted.ConstructionSiteManager);
            Assert.Equal(inserted.ConstructionSiteManager.Id, user.Id);
        }
        
    }
}
