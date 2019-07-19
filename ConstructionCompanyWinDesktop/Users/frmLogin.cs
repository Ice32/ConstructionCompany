using System;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.Managers;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Users
{
    public partial class frmLogin : Form
    {
        private readonly APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _service = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");
        private readonly UsersService _usersService = new UsersService();
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text;
            string password = txtLoginPassword.Text;

            APIClient.SetCredentials(username, password);

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
                new frmIndex().Show();
                Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Neispravni podaci");
            }
        }
    }
}
