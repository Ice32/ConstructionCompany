using System;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.Users
{
    public partial class frmNewUser : Form
    {
        private Form _parent;
        private readonly UserVM _originalUser;
        private readonly APIService<UserVM, UserAddVM, UserAddVM> _usersService = new APIService<UserVM, UserAddVM, UserAddVM>("users");

        public frmNewUser(Form parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        
        public frmNewUser(UserVM user, Form parent) : this(parent)
        {
            _originalUser = user;

            txtUserFirstName.Text = user.FirstName;
            txtUserLastName.Text = user.LastName;
            txtUserUsername.Text = user.UserName;
            lblNewUser.Text = "Uredi korisnika";
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            var user = new UserAddVM
            {
                FirstName = txtUserFirstName.Text,
                LastName = txtUserLastName.Text,
                UserName = txtUserUsername.Text,
                Password = txtUserPassword.Text,
            };
            if (_originalUser != null)
            {
                user.Id = _originalUser.Id;
                await _usersService.Update(_originalUser.Id, user);
            }
            else
            {
                await _usersService.Create(user);
            }
            Form listForm = new frmUsersList { MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true };
            Close();
            listForm.Show();
        }
    }
}
