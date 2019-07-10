using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ConstructionCompanyAPI;
using ConstructionCompanyAPITests.Helpers;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Tasks;
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
        private readonly WorksheetHelpers _worksheetHelpers;

        public TaskControllerTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
            _persistence = fixture.Persistence;
            _workerHelpers = new WorkerHelpers(fixture.Persistence);
            _worksheetHelpers = new WorksheetHelpers(fixture.ServiceProvider, fixture.Client);
        }

        [Fact]
        public async void CanCreateTask()
        {
            // arrange
            (Worker worker, string _) = _workerHelpers.CreateWorker();
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
            HttpResponseMessage httpResponse = await _client.PostAsync(
                "/api/tasks",
                new StringContent(data, Encoding.UTF8, "application/json")
            );
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseTask = JsonConvert.DeserializeObject<TaskVM>(stringResponse);

            // assert
            Assert.NotNull(responseTask);
            Task inserted = _persistence.Tasks.Include("WorkerTasks.Worker").Single(t => t.Id == responseTask.Id);
            Assert.Equal(inserted.Title, task.Title);
            Assert.Equal(inserted.Description, task.Description);
            Assert.NotEmpty(inserted.WorkerTasks);
            Assert.Equal(inserted.WorkerTasks[0].Worker.User.FirstName, worker.User.FirstName);
        }
        
        [Fact]
        public async void ReturnsAllTasksForAWorker()
        {
            // arrange
            (Worker worker, string password) = _workerHelpers.CreateWorker();
            Worksheet firstWorksheet = _worksheetHelpers.CreateWorksheet(new [] { worker.Id });
            Worksheet secondWorksheet = _worksheetHelpers.CreateWorksheet(new [] { worker.Id });

            // act
            byte[] plainTextBytes = Encoding.UTF8.GetBytes($"{worker.User.UserName}:{password}");
            string encoded = Convert.ToBase64String(plainTextBytes);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
            HttpResponseMessage httpResponse = await _client.GetAsync(
                "/api/tasks"
            );
            httpResponse.EnsureSuccessStatusCode();
            string stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseTasks = JsonConvert.DeserializeObject<List<TaskVM>>(stringResponse);

            // assert
            Assert.Equal(2, responseTasks.Count);
            Assert.Contains(responseTasks,
                task => task.Id == firstWorksheet.Tasks.First(t =>
                            t.WorkerTasks.Find(wt => wt.WorkerId == worker.Id) != null).Id);
            Assert.Contains(responseTasks,
                task => task.Id == secondWorksheet.Tasks.First(t =>
                            t.WorkerTasks.Find(wt => wt.WorkerId == worker.Id) != null).Id);
        }
        
    }
}