using ConstructionCompanyModel.ViewModels.Users;

namespace ConstructionCompanyModel
{
    public interface  IUserType
    {
        int Id { get; set; }
        UserVM User { get; set; }
    }
}