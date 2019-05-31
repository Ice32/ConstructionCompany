using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompanyAPITests.Helpers
{
    public class WorksheetHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        
        public WorksheetHelpers(ConstructionCompanyContext persistence)
        {
            _persistence = persistence;
        }
        public Worksheet CreateWorksheet()
        {
            ConstructionSite constructionSite = new ConstructionSiteHelpers(_persistence).CreateConstructionSite();
            var worksheet = new Worksheet
            {
                ConstructionSiteId = constructionSite.Id,
            };
            var inserted = _persistence.Worksheets.Add(worksheet);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
    }
}
