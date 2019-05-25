using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ConstructionCompanyAPI;
using ConstructionCompanyAPITests.Helpers;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class WorksheetsControllerIntegrationTests : IClassFixture<TestFixture<Startup>>

    {

        private readonly HttpClient _client;
        private readonly ConstructionCompanyContext _persistence;
        private readonly WorksheetHelpers _worksheetHelpers;



        public WorksheetsControllerIntegrationTests(TestFixture<Startup> fixture)

        {

            _client = fixture.Client;
            _persistence = fixture.Persistence;
            _worksheetHelpers = new WorksheetHelpers(fixture.Persistence);
        }



        [Fact]

        public async void CanCreateWorksheet()
        {
            // arrange
            const string remarks = "Test remark";
            WorksheetAddVM worksheetVM = new WorksheetAddVM
            {
                Remarks = remarks,
                Tasks = new List<TaskAddVM>
                {
                    new TaskAddVM
                    {
                        Title = "Title",
                    },
                }
            };
            string data = JsonConvert.SerializeObject(worksheetVM);



            // act
            var httpResponse = await _client.PostAsync("/api/worksheets", new StringContent(data, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorksheet = JsonConvert.DeserializeObject<WorksheetVM>(stringResponse);
            
            // assert
            Assert.NotEqual(0, responseWorksheet.Id);

            var inserted = _persistence.Worksheets.Find(responseWorksheet.Id);

            Assert.NotNull(inserted);
            Assert.Equal(remarks, inserted.Remarks);
        }

        [Fact]
        public async void CanRetrieveAllWorksheets()
        {
            // arrange
            Worksheet inserted = _worksheetHelpers.CreateWorksheet();


            // act
            var httpResponse = await _client.GetAsync("/api/worksheets");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorksheets = JsonConvert.DeserializeObject<List<WorksheetVM>>(stringResponse);

            // assert
            Assert.Single(responseWorksheets);
            Assert.Equal(inserted.Id, responseWorksheets[0].Id);
        }

        [Fact]
        public async void CanRetrieveWorksheetById()
        {
            // arrange
            Worksheet inserted = _worksheetHelpers.CreateWorksheet();

            // act
            var httpResponse = await _client.GetAsync($"/api/worksheets/{inserted.Id}");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorksheet = JsonConvert.DeserializeObject<WorksheetVM>(stringResponse);

            // assert
            Assert.NotNull(responseWorksheet);
            Assert.Equal(inserted.Id, responseWorksheet.Id);
        }

    }
}