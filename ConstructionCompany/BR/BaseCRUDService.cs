using ConstructionCompanyDataLayer;

namespace ConstructionCompany.BR
{
    public class BaseCRUDService<TDatabase, TSearch, TDefaultSpecification> : BaseService<TDatabase, TSearch, TDefaultSpecification>, ICRUDService<TDatabase, TSearch> where TDatabase: class where TDefaultSpecification : BaseSpecification<TDatabase>, new()

    {

        public BaseCRUDService(IRepository<TDatabase> repository) : base(repository)
        {

        }



        public virtual TDatabase Insert(TDatabase request)
        {
            TDatabase entity = _repository.Add(request);

            return entity;
        }



        public virtual TDatabase Update(int id, TDatabase request)
        {
            TDatabase entity = _repository.Update(request);

            return entity;

        }

    }
}