using System;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Users
{
    public partial class frmLogin : Form
    {
        private readonly APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _service = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");
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
                new frmIndex().Show();
                Hide();
            }
            catch
            {
                MessageBox.Show("Neispravni podaci");
            }
        }
    }
}
