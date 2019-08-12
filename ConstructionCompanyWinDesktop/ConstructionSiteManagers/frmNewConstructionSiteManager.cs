using System;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.ConstructionSiteManagers
{
    public partial class frmNewConstructionSiteManager : Form
    {
        private Form _parent;
        private readonly ConstructionSiteManagerVM _originalConstructionSiteManager;
        private readonly APIService<ConstructionSiteManagerVM, ConstructionSiteManagerAddVM, ConstructionSiteManagerAddVM> _constructionSiteManagersService = new APIService<ConstructionSiteManagerVM, ConstructionSiteManagerAddVM, ConstructionSiteManagerAddVM>("constructionSiteManagers");

        public frmNewConstructionSiteManager(Form parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        
        public frmNewConstructionSiteManager(ConstructionSiteManagerVM constructionSiteManager, Form parent) : this(parent)
        {
            _originalConstructionSiteManager = constructionSiteManager;

            txtUserFirstName.Text = constructionSiteManager.User.FirstName;
            txtUserLastName.Text = constructionSiteManager.User.LastName;
            txtUserUsername.Text = constructionSiteManager.User.UserName;
            lblNewUser.Text = "Uredi korisnika";
            chkActive.Checked = constructionSiteManager.User.Active;
        }

        private async void BtnUserSubmit_Click(object sender, EventArgs e)
        {
            var manager = new ConstructionSiteManagerAddVM
            {
                User = new UserAddVM
                {
                    FirstName = txtUserFirstName.Text,
                    LastName = txtUserLastName.Text,
                    UserName = txtUserUsername.Text,
                    Password = txtUserPassword.Text,
                    Active = chkActive.Checked
                },
            };
            if (_originalConstructionSiteManager != null)
            {
                manager.Id = _originalConstructionSiteManager.Id;
                manager.User.Id = _originalConstructionSiteManager.User.Id;
                await _constructionSiteManagersService.Update(_originalConstructionSiteManager.Id, manager);
            }
            else
            {
                await _constructionSiteManagersService.Create(manager);
            }

            Form listForm = new frmConstructionSiteManagersList{ MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true };
            Close();
            listForm.Show();
        }
    }
}
