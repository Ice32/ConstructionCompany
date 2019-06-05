using AutoMapper;
using ConstructionCompany.BR;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers
{
    public class BaseCRUDController<T, TDatabase, TSearch, TInsert, TUpdate> : BaseController<T, TDatabase, TSearch>

    {

        private readonly ICRUDService<TDatabase, TSearch> _service = null;

        public BaseCRUDController(ICRUDService<TDatabase, TSearch> service, IMapper mapper) : base(service, mapper)

        {

            _service = service;

        }



        [HttpPost]

        public T Insert(T request)

        {

            var toInsert = _mapper.Map<TDatabase>(request);
            TDatabase inserted = _service.Insert(toInsert);

            return _mapper.Map<T>(inserted);

        }



        [HttpPut("{id}")]

        public T Update(int id, [FromBody]TUpdate request)

        {
            TDatabase toUpdate = _mapper.Map<TDatabase>(request);
            TDatabase updated = _service.Update(id, toUpdate);

            return _mapper.Map<T>(updated);
        }

    }

}