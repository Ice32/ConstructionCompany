using ConstructionCompanyDataLayer;

namespace ConstructionCompany.BR
{
    public class BaseCRUDService<TDatabase, TSearch> : BaseService<TDatabase, TSearch>, ICRUDService<TDatabase, TSearch> where TDatabase: class

    {

        public BaseCRUDService(IRepository<TDatabase> repository) : base(repository)

        {

        }



        public virtual TDatabase Insert(TDatabase request)

        {
            var entity = _repository.Add(request);

            return entity;
        }



        public virtual TDatabase Update(int id, TDatabase request)

        {
            var entity = _repository.Update(request);

            return entity;
//
//            var entity = _context.Set<TDatabase>().Find(id);
//
//            _context.Set<TDatabase>().Attach(entity);
//
//            _context.Set<TDatabase>().Update(entity);
//
//
//
//            _mapper.Map(request, entity);
//
//
//
//            _context.SaveChanges();
//
//
//
//            return _mapper.Map<TModel>(entity);

        }

    }
}