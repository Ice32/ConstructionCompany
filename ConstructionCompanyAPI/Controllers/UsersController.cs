using AutoMapper;
using ConstructionCompany.BR.Users;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyAPI.Util;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.Managers;
using ConstructionCompanyModel.ViewModels.Workers;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    public class UsersController: CustomControllerBase

    {

        private readonly IUsersService _service;
        private readonly IMapper _mapper;
        private readonly IUserTypeRetriever _userTypeRetriever;

        public UsersController(IUsersService service, IMapper mapper, IUserTypeRetriever userTypeRetriever)
        {
            _service = service;
            _mapper = mapper;
            _userTypeRetriever = userTypeRetriever;
        }

        [HttpGet]
        [Route("/api/[controller]/current")]
        public IUserType GetCurrent()
        {
            int userId = GetCurrentUserId();
            
            User retrieved = _service.GetById(userId);
            ConstructionCompanyDataLayer.IUserType fullUser = _userTypeRetriever.Retrieve(retrieved);

            switch (fullUser)
            {
                case Worker _:
                    return _mapper.Map<WorkerVM>(fullUser);
                case Manager _:
                    return _mapper.Map<ManagerVM>(fullUser);
                default:
                    return _mapper.Map<ConstructionSiteManagerVM>(fullUser);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/type")]
        public ValueContainer<string> GetCurrentUserType()
        {
            int userId = GetCurrentUserId();

            User retrieved = _service.GetById(userId);
            ConstructionCompanyDataLayer.IUserType fullUser = _userTypeRetriever.Retrieve(retrieved);

            switch (fullUser)
            {
                case Worker _:
                    return new ValueContainer<string>("worker");
                case Manager _:
                    return new ValueContainer<string>("manager");
                default:
                    return new ValueContainer<string>("construction_site_manager");
            }
        }
    }
}
