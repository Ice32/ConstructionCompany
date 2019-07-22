using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class EquipmentSpecification : BaseSpecification<Equipment>
    {
        public EquipmentSpecification()
            : base(c => true)
        {
        }

        public EquipmentSpecification(int id)
            : base(c => c.Id == id)
        {
        }
    }
}