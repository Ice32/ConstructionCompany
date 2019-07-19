using ConstructionCompanyModel;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.Managers;
using ConstructionCompanyModel.ViewModels.Workers;

namespace ConstructionCompanyWinDesktop.Util
{
    public static class CurrentUserManager
    {
        private static IUserType _user;

        public static void SetUser(IUserType userVM)
        {
            _user = userVM;
        }

        public static bool IsManager()
        {
            return _user is ManagerVM;
        }
        public static bool IsWorker()
        {
            return _user is WorkerVM;
        }
        public static bool IsConstructionSiteManager()
        {
            return _user is ConstructionSiteManagerVM;
        }
        
    }
}