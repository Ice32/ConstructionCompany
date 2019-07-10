using System;
using ConstructionCompany.BR.Users;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompanyAPITests.Helpers
{
    public class UserHelpers
    {
        private readonly IUsersService _usersService;

        public UserHelpers(ConstructionCompanyContext persistence)
        {
            _usersService = new UsersService(new Repository<User>(persistence));
        }
        public (User user, string password) CreateUser()
        {
            var random = new Random();
            string password = $"password {random.Next()}";
            var user = new User
            {
                FirstName = $"Name {random.Next()}",
                LastName = $"Last name {random.Next()}",
                UserName = $"Username {random.Next()}"
            };
            User inserted = _usersService.Insert(user, password);
           
            return (inserted, password);
        } 
    }
}
