using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Users;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.Users
{
    public partial class frmUsersList : Form
    {
        private readonly APIService<UserVM, UserAddVM, UserAddVM> _usersService = new APIService<UserVM, UserAddVM, UserAddVM>("users");
        private List<UserVM> _users;
        public frmUsersList()
        {
            InitializeComponent();
            LoadData();
        }
        
        private async void LoadData()
        {
            _users = await _usersService.GetAll();
            var mappedResults = _users.Select(u => new
            {
                u.Id,
                u.FullName,
                u.UserName
            }).ToList();
            dgvUsersList.DataSource = mappedResults;
        }


        private void DgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;

            if (e.RowIndex == -1)
            {
                return;
            }
            int selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            UserVM user = _users.First(w => w.Id == selectedId);
            var editForm = new frmNewUser(user, MdiParent);
            editForm.Show();
        }
    }
}
