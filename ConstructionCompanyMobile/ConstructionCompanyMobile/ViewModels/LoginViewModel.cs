using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConstructionCompanyMobile.Services;
using ConstructionCompanyMobile.Util;
using ConstructionCompanyMobile.Views;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _service = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");
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
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
