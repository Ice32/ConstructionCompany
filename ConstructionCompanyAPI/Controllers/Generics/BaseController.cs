using System.Collections.Generic;
using AutoMapper;
using ConstructionCompany.BR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers.Generics
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TDatabase, TSearch> : ControllerBase

    {

        protected readonly IService<TDatabase, TSearch> _service;
        protected readonly IMapper _mapper;

        public BaseController(IService<TDatabase, TSearch> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }



        

        [HttpGet]
        public List<T> Get([FromQuery]TSearch search)

        {

            List<TDatabase> retrieved = _service.Get(search);
            return _mapper.Map<List<T>>(retrieved);

        }



        [HttpGet("{id}")]

        public T GetById(int id)

        {

            TDatabase retrieved = _service.GetById(id);
            return _mapper.Map<T>(retrieved);
        }

    }
}