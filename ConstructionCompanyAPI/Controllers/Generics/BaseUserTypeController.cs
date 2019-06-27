using System.Net.Http;
using AutoMapper;
using ConstructionCompany.BR.Users;
using ConstructionCompanyModel;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers.Generics
{
    public class BaseUserTypeController<T, TDatabase, TInsert>: BaseController<T, TDatabase, object> where TInsert : IUserTypeAddVM
    {
        private readonly IUserTypeService<TDatabase> _userTypeService;
        public BaseUserTypeController(IUserTypeService<TDatabase> service, IMapper mapper) : base(service, mapper)
        {
            _userTypeService = service;
        }
        
        [HttpPost]
        public T Insert(TInsert request)
        {
            var toInsert = _mapper.Map<TDatabase>(request);
            TDatabase inserted = _userTypeService.Insert(toInsert, request.User.Password);

            return _mapper.Map<T>(inserted);
        }
        
        [HttpPut("{id}")]
        public T Update(int id, [FromBody]TInsert request)

        {
            TDatabase existing = _service.GetById(id);
            if (existing == null)
            {
                throw new HttpRequestException();
            }
            TDatabase toUpdate = _mapper.Map(request, existing);
            _userTypeService.Update(toUpdate, request.User.Password);
            TDatabase updated = _service.GetById(id);
            return _mapper.Map<T>(updated);
        }
    }
}