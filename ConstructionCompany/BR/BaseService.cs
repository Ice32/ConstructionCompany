using System;
using System.Collections.Generic;
using System.Linq;
using ConstructionCompanyDataLayer;

namespace ConstructionCompany.BR
{
    public class BaseService<TDatabase, TSearch, TDefaultSpecification> : IService<TDatabase, TSearch> where TDatabase: class where TDefaultSpecification : BaseSpecification<TDatabase>, new()

    {

        protected readonly IRepository<TDatabase> _repository;

        public BaseService(IRepository<TDatabase> repository)

        {
            _repository = repository;
        }



        public virtual List<TDatabase> Get(TSearch search)
        {

            var list = _repository.List(new TDefaultSpecification()).ToList();

            return list;

        }



        public virtual TDatabase GetById(int id)
        {

            return _repository.GetSingle((TDefaultSpecification)Activator.CreateInstance(typeof(TDefaultSpecification), id));
        }

    }
}