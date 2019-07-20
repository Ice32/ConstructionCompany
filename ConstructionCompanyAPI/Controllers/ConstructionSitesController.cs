using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    public class ConstructionSitesController : BaseCRUDController<ConstructionSiteVM, ConstructionSite, object, object, ConstructionSiteAddVM, ConstructionSiteAddVM>
    {
        public ConstructionSitesController(ICRUDService<ConstructionSite, object> service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpPost]
        [Authorize(Roles="Manager")]
        public override ConstructionSiteVM Insert(ConstructionSiteAddVM request)
        {
            return base.Insert(request);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Manager")]
        public override ConstructionSiteVM Update(int id, ConstructionSiteAddVM request)
        {
            return base.Update(id, request);
        }
    }
}