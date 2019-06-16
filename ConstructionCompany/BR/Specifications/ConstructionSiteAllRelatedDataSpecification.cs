using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Specifications
{

    public class ConstructionSiteAllRelatedDataSpecification : BaseSpecification<ConstructionSite>
    {
        public ConstructionSiteAllRelatedDataSpecification()
            : base(c => true)
        {
        }

        public ConstructionSiteAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
        }
    }
}