using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompanyAPITests.Helpers
{
    public class ConstructionSiteHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        
        public ConstructionSiteHelpers(ConstructionCompanyContext persistence)
        {
            _persistence = persistence;
        }
        public ConstructionSite CreateConstructionSite()
        {
            ConstructionSite constructionSite = new ConstructionSite();
            var inserted = _persistence.ConstructionSites.Add(constructionSite);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
    }
}
