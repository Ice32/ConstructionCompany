using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Specifications
{

    public class MaterialAllRelatedDataSpecification : BaseSpecification<Material>
    {
        public MaterialAllRelatedDataSpecification()
            : base(c => true)
        {
        }

        public MaterialAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
        }
    }
}