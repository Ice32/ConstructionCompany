using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.Materials
{
    public partial class frmMaterialsList : Form
    {
        private List<MaterialVM> _materials;
        private readonly APIService<MaterialVM, MaterialAddVM, MaterialAddVM> _materialsService = new APIService<MaterialVM, MaterialAddVM, MaterialAddVM>("materials");

        public frmMaterialsList()
        {
            InitializeComponent();
            LoadData();

            dgvMaterialsList.AutoGenerateColumns = false;
        }

        private async void LoadData()
        {
            _materials = await _materialsService.GetAll();
            var mappedResults = _materials.Select(m => new
            {
                m.Id,
                m.Name,
                m.Amount,
                m.Unit,
            }).ToList();
            dgvMaterialsList.DataSource = mappedResults;
        }


        private void DgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;

            if (e.RowIndex == -1)
            {
                return;
            }
            var selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            MaterialVM material = _materials.FirstOrDefault(w => w.Id == selectedId);
//            frmNewConstructionSite editForm = new frmNewConstructionSite(constructionSite, MdiParent);
//            editForm.Show();
        }
    }
}
