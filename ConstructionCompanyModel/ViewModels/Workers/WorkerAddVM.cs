using ConstructionCompanyModel.ViewModels.Users;

namespace ConstructionCompanyModel.ViewModels.Workers
{
    public class WorkerAddVM: IUserTypeAddVM
    {
        public int? Id { get; set; }
        public UserAddVM User { get; set; }
//        public List<Worksheet> Worksheets { get; set; }
//        public List<ConstructionSiteSiteManager> ConstructionSites { get; set; }
    }
}