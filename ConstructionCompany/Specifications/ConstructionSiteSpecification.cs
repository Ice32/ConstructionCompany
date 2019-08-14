using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class ConstructionSiteSpecification : BaseSpecification<ConstructionSite>
    {
        public ConstructionSiteSpecification()
            : base(c => true)
        {
            AddInclude("ConstructionSiteManagers.ConstructionSiteManager.User");
        }

        public ConstructionSiteSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude("ConstructionSiteManagers.ConstructionSiteManager.User");
        }
        
        public ConstructionSiteSpecification(ConstructionSiteSearch search)
            : base(c => (search.Name != default ? c.Title.Contains(search.Name) : true))
        {
            AddInclude("ConstructionSiteManagers.ConstructionSiteManager.User");
        }
    }
}