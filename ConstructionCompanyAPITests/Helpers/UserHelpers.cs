using System;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompanyAPITests.Helpers
{
    public class UserHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        
        public UserHelpers(ConstructionCompanyContext persistence)
        {
            _persistence = persistence;
        }
        public User CreateUser()
        {
            var random = new Random();
            var user = new User
            {
                FirstName = $"Name {random.Next()}",
                LastName = $"Last name {random.Next()}",
            };
           
            var inserted = _persistence.Set<User>().Add(user);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
    }
}
