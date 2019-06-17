using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Specifications
{

    public class ConstructionSiteAllRelatedDataSpecification : BaseSpecification<ConstructionSite>
    {
        public ConstructionSiteAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude(cs => cs.CreatedBy);
        }

        public ConstructionSiteAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude(cs => cs.CreatedBy);
        }
    }
}