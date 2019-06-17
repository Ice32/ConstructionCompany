using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.ConstructionSites
{
    public partial class frmConstructionSitesList : Form
    {
        private readonly APIService<ConstructionSiteVM, ConstructionSiteAddVM, ConstructionSiteAddVM> _constructionSitesService = new APIService<ConstructionSiteVM, ConstructionSiteAddVM, ConstructionSiteAddVM>("constructionSites");
        private List<ConstructionSiteVM> _constructionSites;
        public frmConstructionSitesList()
        {
            InitializeComponent();
            LoadData();
        }
        
        private async void LoadData()
        {
            _constructionSites = await _constructionSitesService.GetAll();
            var mappedResults = _constructionSites.Select(cs => new
            {
                cs.Title,
                cs.Address,
                cs.ProjectWorth,
                CreatedBy = cs.CreatedBy.FullName
            }).ToList();
            dgvConstructionSitesList.DataSource = mappedResults;
        }


        private void DgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (e.RowIndex == -1)
            {
                return;
            }
            int selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            ConstructionSiteVM worksheet = _constructionSites.FirstOrDefault(w => w.Id == selectedId);
//            frmNewWorksheet worksheetForm = new frmNewWorksheet(worksheet, MdiParent);
//            worksheetForm.Show();
        }
    }
}