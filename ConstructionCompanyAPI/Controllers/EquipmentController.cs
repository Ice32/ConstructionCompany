using AutoMapper;
using ConstructionCompany;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    public class EquipmentController : BaseCRUDController<EquipmentVM, Equipment, EquipmentSearchVM, EquipmentSearch, EquipmentAddVM, EquipmentAddVM>
    {
        public EquipmentController(ICRUDService<Equipment, EquipmentSearch> service, IMapper mapper) : base(service, mapper)
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
