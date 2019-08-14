using ConstructionCompany.Specifications;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Users
{
    public class UserTypeRetriever: IUserTypeRetriever
    {
        private readonly IRepository<Manager> _managersRepository;
        private readonly IRepository<ConstructionSiteManager> _constructionSiteManagersRepository;
        private readonly IRepository<Worker> _workersRepository;

        public UserTypeRetriever(IRepository<Manager> managersRepository, IRepository<ConstructionSiteManager> constructionSiteManagersRepository, IRepository<Worker> workersRepository)
        {
            _managersRepository = managersRepository;
            _constructionSiteManagersRepository = constructionSiteManagersRepository;
            _workersRepository = workersRepository;
        }

        public IUserType Retrieve(User user)
        {
            Manager manager = _managersRepository.GetSingle(new ManagerSpecification(user));
            if (manager != null)
            {
                return manager;
            }
            
            ConstructionSiteManager constructionSiteManager = _constructionSiteManagersRepository.GetSingle(new ConstructionSiteManagerSpecification(user));
            if (constructionSiteManager != null)
            {
                return constructionSiteManager;
            }
            
            Worker worker = _workersRepository.GetSingle(new WorkerSpecification(user));
            return worker;
        }
    }
}