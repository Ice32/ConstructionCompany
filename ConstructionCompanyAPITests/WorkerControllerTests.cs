using System.Linq;
using System.Net.Http;
using System.Text;
using ConstructionCompanyAPI;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyModel.ViewModels.Workers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class WorkerControllerTests : IClassFixture<TestFixture<Startup>>

    {
        private readonly HttpClient _client;
        private readonly ConstructionCompanyContext _persistence;

        public WorkerControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
            _persistence = fixture.Persistence;
        }

        [Fact]
        public async void CanCreateWorker()
        {
            // arrange
            var workerAddVM = new WorkerAddVM
            {
              User = new UserAddVM
              {
                  FirstName = "first name",
                  LastName = "last name",
                  UserName = "username",
                  Password = "clear text password"
              }
            };
            string data = JsonConvert.SerializeObject(workerAddVM);


            // act
            HttpResponseMessage httpResponse = await _client.PostAsync("/api/workers", new StringContent(data, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            string stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseUser = JsonConvert.DeserializeObject<User>(stringResponse);

            // assert
            Assert.NotNull(responseUser);
            Worker inserted = _persistence.Set<Worker>().Include("User").Single(u => u.Id == responseUser.Id);
            Assert.Equal(workerAddVM.User.UserName, inserted.User.UserName);
            // doesnt store password in clear text
            Assert.NotEqual(workerAddVM.User.Password, inserted.User.PasswordHash);
        }

    }
}
