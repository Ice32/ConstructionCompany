using System.Collections.Generic;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;


namespace ConstructionCompanyWinDesktop
{
    public partial class Form1 : Form
    {
        private readonly WorksheetsService _worksheetsService;

        public Form1()
        {
            InitializeComponent();
            _worksheetsService = new WorksheetsService();
        }

        private async void Button1_Click(object sender, System.EventArgs e)
        {
            List<WorksheetVM> results = await _worksheetsService.GetAllWorksheets();
            dgvMain.DataSource = results;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
