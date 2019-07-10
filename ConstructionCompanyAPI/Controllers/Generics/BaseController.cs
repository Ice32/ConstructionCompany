using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using ConstructionCompany.BR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers.Generics
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TDatabase, TSearchVM, TSearch> : ControllerBase

    {

        protected readonly IService<TDatabase, TSearch> _service;
        protected readonly IMapper _mapper;

        public BaseController(IService<TDatabase, TSearch> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }



        

        [HttpGet]
        public virtual List<T> Get([FromQuery]TSearchVM searchVM)

        {
            var search = _mapper.Map<TSearch>(searchVM);
            List<TDatabase> retrieved = _service.Get(search);
            return _mapper.Map<List<T>>(retrieved);

        }



        [HttpGet("{id}")]

        public T GetById(int id)

        {

            TDatabase retrieved = _service.GetById(id);
            return _mapper.Map<T>(retrieved);
        }

        protected int GetCurrentUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            Claim nameClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            return int.Parse(nameClaim?.Value);
        }

    }
}