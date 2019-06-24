using System.Net.Http;
using AutoMapper;
using ConstructionCompany.BR;
using ConstructionCompany.BR.Users;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: BaseController<UserVM, User, object>
    {
        private readonly IUsersService _usersService;

        public UsersController(IService<User, object> service, IMapper mapper, IUsersService usersService) : base(service, mapper)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public User Insert(UserAddVM request)
        {
            var toInsert = _mapper.Map<User>(request);
            return _usersService.Insert(toInsert, request.Password);
        }
        
        [HttpPut("{id}")]
        public UserVM Update(int id, [FromBody]UserAddVM request)

        {
            User existing = _service.GetById(id);
            if (existing == null)
            {
                throw new HttpRequestException();
            }
            User toUpdate = _mapper.Map(request, existing);
            _usersService.Update(toUpdate, request.Password);
            User updated = _service.GetById(id);
            return _mapper.Map<UserVM>(updated);
        }
    }
}