using System.Collections.Generic;
using System.Net.Http;
using ConstructionCompanyAPI;
using ConstructionCompanyAPITests.Helpers;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Workers;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class WorkersControllerIntegrationTests : IClassFixture<TestFixture<Startup>>

    {
        private readonly HttpClient _client;
        private readonly WorkerHelpers _workerHelpers;
        public WorkersControllerIntegrationTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
            _workerHelpers = new WorkerHelpers(fixture.Persistence);
        }

        [Fact]
        public async void CanRetrieveAllWorkers()
        {
            // arrange
            Worker inserted = _workerHelpers.CreateWorker();


            // act
            var httpResponse = await _client.GetAsync("/api/workers");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorkers = JsonConvert.DeserializeObject<List<WorkerVM>>(stringResponse);

            // assert
            Assert.Single(responseWorkers);
            Assert.Equal(inserted.Id, responseWorkers[0].Id);
        }
        
    }
}
