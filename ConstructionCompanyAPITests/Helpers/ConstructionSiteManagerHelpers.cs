using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompanyAPITests.Helpers
{
    public class ConstructionSiteManagerHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        private readonly UserHelpers _userHelpers;

        public ConstructionSiteManagerHelpers(ConstructionCompanyContext persistence)
        {
            _persistence = persistence;
            _userHelpers = new UserHelpers(persistence);
        }
        public ConstructionSiteManager CreateConstructionSiteManager()
        {
            User user = _userHelpers.CreateUser();
            var constructionSiteManager = new ConstructionSiteManager
            {
                User = user
            };
            var inserted = _persistence.ConstructionSiteManagers.Add(constructionSiteManager);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
    }
}
