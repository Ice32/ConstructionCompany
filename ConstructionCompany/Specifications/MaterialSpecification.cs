using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class MaterialSpecification : BaseSpecification<Material>
    {
        public MaterialSpecification()
            : base(c => true)
        {
        }

        public MaterialSpecification(int id)
            : base(c => c.Id == id)
        {
        }
    }
}