using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using ConstructionCompanyAPI;
using ConstructionCompanyAPITests.Helpers;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class TaskControllerTest : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        private readonly ConstructionCompanyContext _persistence;
        private readonly WorkerHelpers _workerHelpers;

        public TaskControllerTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
            _persistence = fixture.Persistence;
            _workerHelpers = new WorkerHelpers(fixture.Persistence);
        }

        [Fact]
        public async void CanCreateTask()
        {
            // arrange
            Worker worker = _workerHelpers.CreateWorker();
            TaskAddVM task = new TaskAddVM
            {
                Title = "Test title",
                Description = "Test description",
                WorkerIds = new List<int>
                {
                    worker.Id,
                }
            };

            string data = JsonConvert.SerializeObject(task);

            // act
            var httpResponse = await _client.PostAsync(
                "/api/tasks",
                new StringContent(data, Encoding.UTF8, "application/json")
            );
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseTask = JsonConvert.DeserializeObject<TaskVM>(stringResponse);

            // assert
            Assert.NotNull(responseTask);
            Task inserted = _persistence.Tasks.Include("WorkerTasks.Worker").Single();
            Assert.Equal(inserted.Title, task.Title);
            Assert.Equal(inserted.Description, task.Description);
            Assert.NotEmpty(inserted.WorkerTasks);
            Assert.Equal(inserted.WorkerTasks[0].Worker.User.FirstName, worker.User.FirstName);
        }
        
    }
}