using System.Linq;
using System.Net.Http;
using System.Text;
using ConstructionCompanyAPI;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Users;
using Newtonsoft.Json;
using Xunit;

namespace ConstructionCompanyAPITests
{
    public class UsersControllerTests : IClassFixture<TestFixture<Startup>>

    {
        private readonly HttpClient _client;
        private readonly ConstructionCompanyContext _persistence;

        public UsersControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
            _persistence = fixture.Persistence;
        }

        [Fact]
        public async void CanCreateUser()
        {
            // arrange
            var userAddVM = new UserAddVM
            {
              FirstName = "first name",
              LastName = "last name",
              UserName = "username",
              Password = "clear text password"
            };
            string data = JsonConvert.SerializeObject(userAddVM);


            // act
            HttpResponseMessage httpResponse = await _client.PostAsync("/api/users", new StringContent(data, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var responseUser = JsonConvert.DeserializeObject<User>(stringResponse);

            // assert
            Assert.NotNull(responseUser);
            User inserted = _persistence.Set<User>().Single(u => u.Id == responseUser.Id);
            Assert.Equal(userAddVM.UserName, inserted.UserName);
            // doesnt store password in clear text
            Assert.NotEqual(userAddVM.Password, inserted.PasswordHash);
        }

    }
}
