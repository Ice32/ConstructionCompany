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
        
        public EquipmentSpecification(EquipmentSearch search)
            : base(c => (search.Name != default ? c.Name.Contains(search.Name) : true) && (search.SerialNumber != default ? c.SerialNumber.Contains(search.SerialNumber) : true))
        {
        }
    }
}