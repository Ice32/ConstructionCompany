using System;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.ConstructionSiteManagers
{
    public partial class frmNewConstructionSiteManager : Form
    {
        private Form _parent;
        private readonly ConstructionSiteManagerVM _originalConstructionSiteManager;
        private readonly APIService<ConstructionSiteManagerVM, ConstructionSiteManagerAddVM, ConstructionSiteManagerAddVM> _constructionSiteManagersService = new APIService<ConstructionSiteManagerVM, ConstructionSiteManagerAddVM, ConstructionSiteManagerAddVM>("constructionSiteManagers");
        private readonly ValidationUtil _validationUtil;

        public frmNewConstructionSiteManager(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            _validationUtil = new ValidationUtil(errorProvider1);
        }
        
        public frmNewConstructionSiteManager(ConstructionSiteManagerVM constructionSiteManager, Form parent) : this(parent)
        {
            _originalConstructionSiteManager = constructionSiteManager;

            txtUserFirstName.Text = constructionSiteManager.User.FirstName;
            txtUserLastName.Text = constructionSiteManager.User.LastName;
            txtUserUsername.Text = constructionSiteManager.User.UserName;
            lblNewUser.Text = "Uredi šefa gradilišta";
            chkActive.Checked = constructionSiteManager.User.Active;
        }

        private async void BtnUserSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
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

        private void TxtUserFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _validationUtil.AssertLength(3, textBox, e);
        }

        private void TxtUserLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _validationUtil.AssertLength(3, textBox, e);
        }

        private void TxtUserUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _validationUtil.AssertLength(3, textBox, e);
        }

        private void TxtUserPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_originalConstructionSiteManager == null)
            {
                TextBox textBox = (TextBox)sender;
                _validationUtil.AssertLength(3, textBox, e);
            }
        }

        private void TxtUserPasswordConfirmation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string password = txtUserPassword.Text;

            if (!string.IsNullOrEmpty(password))
            {
                if (textBox.Text != password)
                {
                    errorProvider1.SetError(textBox, "Lozinke se ne podudaraju");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(textBox, null);
                }
            }
            else
            {
                errorProvider1.SetError(textBox, null);
            }
        }
    }
}
