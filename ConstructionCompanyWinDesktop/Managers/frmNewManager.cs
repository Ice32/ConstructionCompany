using ConstructionCompanyModel.ViewModels.Managers;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;
using System;
using System.Windows.Forms;

namespace ConstructionCompanyWinDesktop.Managers
{
    public partial class frmNewManager : Form
    {
        private readonly Form _parent;
        private readonly ManagerVM _originalManager;
        private readonly APIService<ManagerVM, ManagerAddVM, ManagerAddVM> _managersService = new APIService<ManagerVM, ManagerAddVM, ManagerAddVM>("managers");
        private readonly ValidationUtil _validationUtil;

        public frmNewManager(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            _validationUtil = new ValidationUtil(errorProvider1);
        }

        public frmNewManager(ManagerVM manager, Form parent) : this(parent)
        {
            _originalManager = manager;

            txtUserFirstName.Text = manager.User.FirstName;
            txtUserLastName.Text = manager.User.LastName;
            txtUserUsername.Text = manager.User.UserName;
            lblNewUser.Text = "Uredi administratora";
        }

        private async void BtnUserSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
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
            try
            {
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
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Bad Request"))
                {
                    MessageBox.Show("Korisničko ime se koristi");
                    return;
                }
            }
            Form listForm = new frmManagersList { MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true };
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
            if (_originalManager == null)
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
