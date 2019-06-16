using System;
using System.Net.Http;
using AutoMapper;
using ConstructionCompany.BR;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers.Generics
{
    public class BaseCRUDController<T, TDatabase, TSearch, TInsert, TUpdate> : BaseController<T, TDatabase, TSearch>

    {

        private readonly ICRUDService<TDatabase, TSearch> _service;

        public BaseCRUDController(ICRUDService<TDatabase, TSearch> service, IMapper mapper) : base(service, mapper)

        {

            _service = service;

        }



        [HttpPost]

        public T Insert(TInsert request)

        {

            var toInsert = _mapper.Map<TDatabase>(request);
            TDatabase inserted = _service.Insert(toInsert);

            return _mapper.Map<T>(inserted);
        }



        [HttpPut("{id}")]

        public T Update(int id, [FromBody]TUpdate request)

        {
            TDatabase existing = _service.GetById(id);
            if (existing == null)
            {
                throw new HttpRequestException();
            }
            TDatabase toUpdate = _mapper.Map(request, existing);
            _service.Update(id, toUpdate);
            TDatabase updated = _service.GetById(id);
            return _mapper.Map<T>(updated);
        }

    }

}