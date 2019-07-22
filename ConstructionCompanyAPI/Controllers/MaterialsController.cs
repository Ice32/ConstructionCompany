using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    public class MaterialsController : BaseCRUDController<MaterialVM, Material, object, object, MaterialAddVM, MaterialAddVM>
    {
        public MaterialsController(ICRUDService<Material, object> service, IMapper mapper) : base(service, mapper)
        {
        }
        
        [HttpPost]
        [Authorize(Roles="Manager")]
        public override MaterialVM Insert(MaterialAddVM request)
        {
            return base.Insert(request);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Manager")]
        public override MaterialVM Update(int id, MaterialAddVM request)
        {
            return base.Update(id, request);
        }
    }
}
