using System;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Users
{
    public partial class frmNewWorker : Form
    {
        private Form _parent;
        private readonly WorkerVM _originalWorker;
        private readonly APIService<WorkerVM, WorkerAddVM, WorkerAddVM> _workersService = new APIService<WorkerVM, WorkerAddVM, WorkerAddVM>("workers");
        private readonly ValidationUtil _validationUtil;

        public frmNewWorker(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            if (!CurrentUserManager.IsManager())
            {
                btnUserSubmit.Visible = false;
            }
            _validationUtil = new ValidationUtil(errorProvider1);
        }
        
        public frmNewWorker(WorkerVM worker, Form parent) : this(parent)
        {
            _originalWorker = worker;

            txtUserFirstName.Text = worker.User.FirstName;
            txtUserLastName.Text = worker.User.LastName;
            txtUserUsername.Text = worker.User.UserName;
            lblNewUser.Text = "Uredi radnika";
            chkActive.Checked = worker.User.Active;
        }

        private async void BtnUserSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            var worker = new WorkerAddVM
            {
                User = new UserAddVM
                {
                    FirstName = txtUserFirstName.Text,
                    LastName = txtUserLastName.Text,
                    UserName = txtUserUsername.Text,
                    Password = txtUserPassword.Text,
                    Active = chkActive.Checked,
                },
            };
            try
            {
                if (_originalWorker != null)
                {
                    worker.Id = _originalWorker.Id;
                    worker.User.Id = _originalWorker.User.Id;
                    await _workersService.Update(_originalWorker.Id, worker);
                }
                else
                {
                    await _workersService.Create(worker);
                }
            } catch(Exception ex)
            {
                if (ex.Message.Contains("Bad Request"))
                {
                    MessageBox.Show("Korisničko ime se koristi");
                    return;
                }
            }

            Form listForm = new frmWorkersList{ MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true };
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
            if (_originalWorker == null)
            {
                TextBox textBox = (TextBox)sender;
                _validationUtil.AssertLength(3, textBox, e);
            }
        }

        private void TxtUserPasswordConfirmation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string password = txtUserPassword.Text;

            if (!string.IsNullOrEmpty(password)) {
                if (textBox.Text != password)
                {
                    errorProvider1.SetError(textBox, "Lozinke se ne podudaraju");
                    e.Cancel = true;
                } else
                {
                    errorProvider1.SetError(textBox, null);
                }
            } else
            {
                errorProvider1.SetError(textBox, null);
            }
        }
    }
}
