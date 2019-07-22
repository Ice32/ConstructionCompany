using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    public class EquipmentController : BaseCRUDController<EquipmentVM, Equipment, object, object, EquipmentAddVM, EquipmentAddVM>
    {
        public EquipmentController(ICRUDService<Equipment, object> service, IMapper mapper) : base(service, mapper)
        {
        }
        
        [HttpPost]
        [Authorize(Roles="Manager")]
        public override EquipmentVM Insert(EquipmentAddVM request)
        {
            return base.Insert(request);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Manager")]
        public override EquipmentVM Update(int id, EquipmentAddVM request)
        {
            return base.Update(id, request);
        }
    }
}
