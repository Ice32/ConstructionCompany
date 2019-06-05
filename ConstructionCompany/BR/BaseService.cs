using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ConstructionCompanyDataLayer;

namespace ConstructionCompany.BR
{
    public class BaseService<TDatabase, TSearch> : IService<TDatabase, TSearch> where TDatabase: class

    {

        protected readonly IRepository<TDatabase> _repository;

        public BaseService(IRepository<TDatabase> repository)

        {
            _repository = repository;
        }



        public virtual List<TDatabase> Get(TSearch search)

        {

            var list = _repository.List().ToList();

            return list;
//            return _mapper.Map<List<TModel>>(list);

        }



        public virtual TDatabase GetById(int id)

        {

            var entity = _repository.GetById(id);

            return entity;


//            return _mapper.Map<TModel>(entity);

        }

    }
}