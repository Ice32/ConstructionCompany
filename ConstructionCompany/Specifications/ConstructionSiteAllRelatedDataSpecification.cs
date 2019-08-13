using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class ConstructionSiteAllRelatedDataSpecification : BaseSpecification<ConstructionSite>
    {
        public ConstructionSiteAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude("ConstructionSiteManagers.ConstructionSiteManager.User");
        }

        public ConstructionSiteAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude("ConstructionSiteManagers.ConstructionSiteManager.User");
        }
        
        public ConstructionSiteAllRelatedDataSpecification(ConstructionSiteSearch search)
            : base(c => (search.Name != default ? c.Title.Contains(search.Name) : true))
        {
            AddInclude("ConstructionSiteManagers.ConstructionSiteManager.User");
        }
    }
}