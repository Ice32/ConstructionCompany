using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Managers;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.Managers
{
    public partial class frmManagersList : Form
    {
        private readonly APIService<ManagerVM, ManagerAddVM, ManagerAddVM> _managersService = new APIService<ManagerVM, ManagerAddVM, ManagerAddVM>("managers");
        private List<ManagerVM> _managers;
        public frmManagersList()
        {
            InitializeComponent();
            LoadData();
        }
        
        private async void LoadData()
        {
            _managers = await _managersService.GetAll();
            var mappedResults = _managers.Select(u => new
            {
                u.Id,
                u.User.FullName,
                u.User.UserName
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
            var selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            ManagerVM manager = _managers.First(w => w.Id == selectedId);
            var editForm = new frmNewManager(manager, MdiParent);
            editForm.Show();
        }
    }
}