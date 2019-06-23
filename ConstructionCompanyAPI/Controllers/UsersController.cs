using AutoMapper;
using ConstructionCompany.BR.Users;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public User Insert(UserAddVM request)
        {
            var toInsert = _mapper.Map<User>(request);
            return _usersService.Insert(toInsert, request.Password);
        }
    }
}