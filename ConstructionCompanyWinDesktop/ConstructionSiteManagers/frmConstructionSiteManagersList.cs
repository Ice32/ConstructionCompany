using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.ConstructionSiteManagers;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.ConstructionSiteManagers
{
    public partial class frmConstructionSiteManagersList : Form
    {
        private readonly APIService<ConstructionSiteManagerVM, ConstructionSiteManagerAddVM, ConstructionSiteManagerAddVM> _csmService = new APIService<ConstructionSiteManagerVM, ConstructionSiteManagerAddVM, ConstructionSiteManagerAddVM>("constructionSiteManagers");
        private List<ConstructionSiteManagerVM> _constructionSiteManagers;
        public frmConstructionSiteManagersList()
        {
            InitializeComponent();
            LoadData();
        }
        
        private async void LoadData()
        {
            _constructionSiteManagers = await _csmService.GetAll();
            var mappedResults = _constructionSiteManagers.Select(u => new
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
            int selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            ConstructionSiteManagerVM constructionSiteManager = _constructionSiteManagers.First(w => w.Id == selectedId);
            var editForm = new frmNewConstructionSiteManager(constructionSiteManager, MdiParent);
            editForm.Show();
        }
    }
}