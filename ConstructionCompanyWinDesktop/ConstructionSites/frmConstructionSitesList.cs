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
        private string _nameSearch = "";
        public frmConstructionSitesList()
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
            _constructionSites = await _constructionSitesService.GetAll(search);
            var mappedResults = _constructionSites.Select(cs => new
            {
                cs.Id,
                cs.Title,
                cs.Address,
                cs.ProjectWorth,
                ConstructionSiteManager = cs.ConstructionSiteManager.User.FullName
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
            ConstructionSiteVM constructionSite = _constructionSites.FirstOrDefault(w => w.Id == selectedId);
            frmNewConstructionSite editForm = new frmNewConstructionSite(constructionSite, MdiParent);
            editForm.Show();
        }

        private void TextBox1_TextChanged(object sender, System.EventArgs e)
        {
            _nameSearch = ((TextBox)sender).Text;
            LoadData();
        }
    }
}