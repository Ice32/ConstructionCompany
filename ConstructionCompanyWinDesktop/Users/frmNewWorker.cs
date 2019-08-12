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

        public frmNewWorker(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            if (!CurrentUserManager.IsManager())
            {
                btnUserSubmit.Visible = false;
            }
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

            Form listForm = new frmWorkersList{ MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true };
            Close();
            listForm.Show();
        }
    }
}
