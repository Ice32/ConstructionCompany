using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using ConstructionCompanyAPI;
using ConstructionCompanyAPITests.Helpers;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class WorksheetsControllerIntegrationTests : IClassFixture<TestFixture<Startup>>

    {

        private readonly HttpClient _client;
        private readonly ConstructionCompanyContext _persistence;
        private readonly WorksheetHelpers _worksheetHelpers;
        private readonly WorkerHelpers _workerHelpers;



        public WorksheetsControllerIntegrationTests(TestFixture<Startup> fixture)

        {

            _client = fixture.Client;
            _persistence = fixture.Persistence;
            _worksheetHelpers = new WorksheetHelpers(fixture.ServiceProvider, fixture.Client);
            _workerHelpers = new WorkerHelpers(fixture.Persistence);
        }



        [Fact]

        public async void CanCreateWorksheet()
        {
            // arrange
            const string remarks = "Test remark";
            Worker worker = _workerHelpers.CreateWorker();
            WorksheetAddVM worksheetVM = new WorksheetAddVM
            {
                Remarks = remarks,
                Tasks = new List<TaskAddVM>
                {
                    new TaskAddVM
                    {
                        Title = "Title",
                        WorkerIds = new List<int>
                        {
                            worker.Id
                        }
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
        public async void CanStoreTasksAndWorkers()
        {
            // arrange
            Worker worker = _workerHelpers.CreateWorker();
            var worksheetVM = new WorksheetAddVM
            {
                Tasks = new List<TaskAddVM>
                {
                    new TaskAddVM
                    {
                        Title = "Title",
                        WorkerIds = new List<int> { worker.Id }
                    }
                }
            };
            string data = JsonConvert.SerializeObject(worksheetVM);


            // act
            HttpResponseMessage httpResponse = await _client.PostAsync("/api/worksheets", new StringContent(data, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorksheet = JsonConvert.DeserializeObject<WorksheetVM>(stringResponse);
            
            // assert
            Worksheet inserted = _persistence.Worksheets.Include("Tasks.WorkerTasks").Single(w => w.Id == responseWorksheet.Id);

            Assert.NotNull(inserted.Tasks);
            Assert.Single(inserted.Tasks);
            Assert.NotNull(inserted.Tasks[0].WorkerTasks);
            Assert.Single(inserted.Tasks[0].WorkerTasks);
        }
        
        [Fact]
        public async void CanUpdateTasksAndWorkers()
        {
            // arrange
            Worksheet worksheet = _worksheetHelpers.CreateWorksheet();
            Worker worker = _workerHelpers.CreateWorker();
            const string taskTitle = "Edited task";
            var editedWorksheet = new WorksheetAddVM
            {
                Id = worksheet.Id,
                Tasks = new List<TaskAddVM>
                {
                    new TaskAddVM
                    {
                        Title = taskTitle,
                        WorkerIds = new List<int> { worker.Id }
                    }
                },
                ConstructionSiteId = worksheet.ConstructionSiteId
            };
            string data = JsonConvert.SerializeObject(editedWorksheet);


            // act
            HttpResponseMessage httpResponse = await _client.PostAsync($"/api/worksheets/{worksheet.Id}", new StringContent(data, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            
            // assert
            WorksheetVM inserted = await _worksheetHelpers.GetWorksheetById(worksheet.Id);

            Assert.Equal(taskTitle ,inserted.Tasks[0].Title);
            Assert.Single(inserted.Tasks[0].Workers);
            Assert.Equal(inserted.Tasks[0].Workers[0].Id, worker.Id);
        }

        [Fact]
        public async void CanRetrieveAllWorksheets()
        {
            // arrange
            Worksheet inserted = _worksheetHelpers.CreateWorksheet();

            // act
            HttpResponseMessage httpResponse = await _client.GetAsync("/api/worksheets");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorksheets = JsonConvert.DeserializeObject<List<WorksheetVM>>(stringResponse);

            // assert
            Assert.NotEmpty(responseWorksheets);
            Assert.NotNull(responseWorksheets.SingleOrDefault(w => w.Id == inserted.Id));
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
        
        [Fact]
        public async void RetrievingWorksheetByIdReturnsTasks()
        {
            // arrange
            Worksheet inserted = _worksheetHelpers.CreateWorksheet();
            const string description = "task description";
            EntityEntry<Task> taskEntry =_persistence.Tasks.Add(new Task
            {
                WorksheetId = inserted.Id,
                Description = description,
            });
            _persistence.SaveChanges();


            // act
            var httpResponse = await _client.GetAsync("/api/worksheets");
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseWorksheets = JsonConvert.DeserializeObject<List<WorksheetVM>>(stringResponse);

            // assert
            Assert.Single(responseWorksheets);
            Assert.NotEmpty(responseWorksheets[0].Tasks);
            Assert.NotNull(
                responseWorksheets.Single(w => w.Tasks.Single(t => t.Id == taskEntry.Entity.Id) != null ));
        }

    }
}