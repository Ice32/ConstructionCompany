using System.Threading.Tasks;
using ConstructionCompanyModel;
using ConstructionCompanyModel.ViewModels.Users;

namespace ConstructionCompanyWinDesktop.Services
{
    public class UsersService: APIService<UserVM, object, object>
    {
        public UsersService() : base("users")
        {
        }

        public async Task<string> GetCurrentUserType()
        {
            ValueContainer<string> userType = await Client.Get<ValueContainer<string>>("/type");

            return userType.Value;
        }
        
        public async Task<T> GetCurrentUser<T>()
        {
            T userType = await Client.Get<T>("/current");

            return userType;
        }
    }
}
