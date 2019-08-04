using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConstructionCompanyMobile.Services;
using ConstructionCompanyMobile.Util;
using ConstructionCompanyMobile.Views;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.Managers;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _service = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");
        private readonly UsersService _usersService = new UsersService();
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        
        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; set; }

        private async Task Login()
        {
            IsBusy = true;
            
            APIClient.SetCredentials(Username, Password);

            try
            {
                await _service.GetAll();
                string userType = await _usersService.GetCurrentUserType();
                switch (userType)
                {
                    case "manager":
                        {
                            ManagerVM user = await _usersService.GetCurrentUser<ManagerVM>();
                            CurrentUserManager.SetUser(user);
                            break;
                        }

                    case "worker":
                        {
                            WorkerVM user = await _usersService.GetCurrentUser<WorkerVM>();
                            CurrentUserManager.SetUser(user);
                            break;
                        }

                    default:
                        {
                            ConstructionSiteManagerVM user = await _usersService.GetCurrentUser<ConstructionSiteManagerVM>();
                            CurrentUserManager.SetUser(user);
                            break;
                        }
                }
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
