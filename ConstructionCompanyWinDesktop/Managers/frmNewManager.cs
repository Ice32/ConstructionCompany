using System;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Managers;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.Managers
{
    public partial class frmNewManager : Form
    {
        private readonly Form _parent;
        private readonly ManagerVM _originalManager;
        private readonly APIService<ManagerVM, ManagerAddVM, ManagerAddVM> _managersService = new APIService<ManagerVM, ManagerAddVM, ManagerAddVM>("managers");

        public frmNewManager(Form parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        
        public frmNewManager(ManagerVM manager, Form parent) : this(parent)
        {
            _originalManager = manager;

            txtUserFirstName.Text = manager.User.FirstName;
            txtUserLastName.Text = manager.User.LastName;
            txtUserUsername.Text = manager.User.UserName;
            lblNewUser.Text = "Uredi korisnika";
        }

        private async void BtnUserSubmit_Click(object sender, EventArgs e)
        {
            var manager = new ManagerAddVM
            {
                User = new UserAddVM
                {
                    FirstName = txtUserFirstName.Text,
                    LastName = txtUserLastName.Text,
                    UserName = txtUserUsername.Text,
                    Password = txtUserPassword.Text,
                    Active = true
                },
            };
            if (_originalManager != null)
            {
                manager.Id = _originalManager.Id;
                manager.User.Id = _originalManager.User.Id;
                await _managersService.Update(_originalManager.Id, manager);
            }
            else
            {
                await _managersService.Create(manager);
            }

            Form listForm = new frmManagersList{ MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true };
            Close();
            listForm.Show();
        }
    }
}
