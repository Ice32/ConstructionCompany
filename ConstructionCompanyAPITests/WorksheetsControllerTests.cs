using ConstructionCompanyAPI;
using ConstructionCompanyAPI.ViewModels.Worksheets;
using DataLayer;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class PlayersControllerIntegrationTests : IClassFixture<TestFixture<Startup>>

    {

        private readonly HttpClient _client;
        private readonly ConstructionCompanyContext _persistence;



        public PlayersControllerIntegrationTests(TestFixture<Startup> fixture)

        {

            _client = fixture.Client;
            _persistence = fixture.Persistence;
        }



        [Fact]

        public async void CanCreateWorksheet()
        {

            string remarks = "Test remark";
            WorksheetAddVM worksheetVM = new WorksheetAddVM
            {
                Remark = remarks,
            };
            string data = JsonConvert.SerializeObject(worksheetVM);

            var httpResponse = await _client.PostAsync("/api/worksheets", new StringContent(data, Encoding.UTF8, "application/json"));



            // Must be successful.

            httpResponse.EnsureSuccessStatusCode();



            // Deserialize and examine results.

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();


            var responseWorksheet = JsonConvert.DeserializeObject<WorksheetVM>(stringResponse);

            Assert.NotEqual(0, responseWorksheet.Id);

            var inserted = _persistence.Worksheets.Find(responseWorksheet.Id);

            Assert.NotNull(inserted);
            Assert.Equal(remarks, inserted.Remarks);

        }


    }
}
