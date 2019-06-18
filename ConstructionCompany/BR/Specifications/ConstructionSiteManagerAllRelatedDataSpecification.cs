using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Specifications
{

    public class ConstructionSiteManagerAllRelatedDataSpecification : BaseSpecification<ConstructionSiteManager>
    {
        public ConstructionSiteManagerAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude(cs => cs.User);
        }

        public ConstructionSiteManagerAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude(cs => cs.User);
        }
    }
}