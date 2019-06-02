using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Worksheets;

namespace ConstructionCompanyWinDesktop
{
    public partial class frmWorksheetsList : Form
    {
        private readonly WorksheetsService _worksheetsService;
        private List<WorksheetVM> _worksheets;

        public frmWorksheetsList()
        {
            InitializeComponent();
            _worksheetsService = new WorksheetsService();
            LoadData();
        }

        private async void LoadData()
        {
            _worksheets = await _worksheetsService.GetAllWorksheets();
            var mappedResults = _worksheets.Select(w => new
            {
                ConstructionSite = w.ConstructionSite.Title,
                Equipment = w.Equipment != null ? string.Join(", ", w.Equipment.Select(e => e.Name)) : "",
                Workers = w.Workers != null ? string.Join(", ", w.Workers.Select(worker => worker.FirstName + ' ' + worker.LastName)) : "",
                w.Remarks,
                w.Date,
                w.Id,
            }).ToList();
            dgvMain.DataSource = mappedResults;
        }


        private void DgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            //object selectedId = dataGridView.SelectedRows[0].Cells[0].Value;
            int selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            WorksheetVM worksheet = _worksheets.FirstOrDefault(w => w.Id == selectedId);
            frmNewWorksheet worksheetForm = new frmNewWorksheet(worksheet, MdiParent);
            worksheetForm.Show();
        }
    }
}
