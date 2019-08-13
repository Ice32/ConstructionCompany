using System.Collections.Generic;
using System.Linq;
using ConstructionCompany.Specifications;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Users
{
    public class BaseUserTypeService<T, TDefaultSpecification> : BaseService<T, UserSearch, TDefaultSpecification>, IUserTypeService<T> where T : class, IUserType where TDefaultSpecification : BaseSpecification<T>, new()
    {
        private readonly IUsersService _usersService;

        public BaseUserTypeService(IRepository<T> repository, IUsersService usersService) : base(repository)
        {
            _usersService = usersService;
        }
        
        public T Insert(T userType, string password)
        {
            User insertedUser = _usersService.Insert(userType.User, password);
            userType.User.Id = insertedUser.Id;
            T insertedUserType = _repository.Add(userType);

            return insertedUserType;
        }

        public T Update(T userType, string password)
        {
            _usersService.Update(userType.User, password);
            T updatedUserType  = _repository.Update(userType);

            return updatedUserType;
        }

//        public override List<T> Get(UserSearch search)
//        {
//            if (search.Name != default)
//            {
//                return _repository.List(new UserAllRelatedDataSpecification(search)).ToList();
//            }
////            return _repository.List(new TaskSpecification()).ToList();
//            return base.Get(search);
//        }
    }
}
