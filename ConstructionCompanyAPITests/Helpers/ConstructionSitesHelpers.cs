using System;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompanyAPITests.Helpers
{
    public class ConstructionSitesHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        
        public ConstructionSitesHelpers(ConstructionCompanyContext persistence)
        {
            _persistence = persistence;
        }
        public ConstructionSite CreateConstructionSite()
        {
            var random = new Random();
            var user = new User
            {
                FirstName = "Name",
                LastName = "Last name",
            };
            var constructionSite = new ConstructionSite
            {
                Title = $"construction site {random.Next()}",
                ProjectWorth = random.Next() * 100,
                Address = $"address {random.Next()}",
                CreatedBy = user,
                DateStart = DateTime.Now.Add(new TimeSpan(3, 0, 0)),
                DateFinish = DateTime.Now.Add(new TimeSpan(500, 3, 0, 0))
            };
            var inserted = _persistence.ConstructionSites.Add(constructionSite);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
    }
}
