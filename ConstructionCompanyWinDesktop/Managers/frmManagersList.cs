using System;
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
        private string _nameSearch = "";
        public frmManagersList()
        {
            InitializeComponent();
            LoadData();
        }
        
        private async void LoadData()
        {
            var search = new Dictionary<string, string>();
            if (_nameSearch != default)
            {
                search.Add("Name", _nameSearch);
            }
            _managers = await _managersService.GetAll(search);
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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            _nameSearch = ((TextBox)sender).Text;
            LoadData();
        }
    }
}