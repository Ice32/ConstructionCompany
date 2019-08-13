using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.Equipment
{
    public partial class frmEquipmentList : Form
    {

        private List<EquipmentVM> _equipment;
        private readonly APIService<EquipmentVM, EquipmentAddVM, EquipmentAddVM> _equipmentService = new APIService<EquipmentVM, EquipmentAddVM, EquipmentAddVM>("equipment");
        private string _nameSearch = "";
        private string _serialNumberSearch = "";
        public frmEquipmentList()
        {
            InitializeComponent();
            LoadData();

            dgvEquipmentList.AutoGenerateColumns = false;
        }

        private async void LoadData()
        {
            var search = new Dictionary<string, string>();
            if (_nameSearch != default)
            {
                search.Add("Name", _nameSearch);
            }
            if (_serialNumberSearch != default)
            {
                search.Add("SerialNumber", _serialNumberSearch);
            }
            _equipment = await _equipmentService.GetAll(search);
            var mappedResults = _equipment.Select(m => new
            {
                m.Id,
                m.Name,
                m.Quantity,
                m.Description,
                m.SerialNumber,
                m.PurchaseDate,
            }).ToList();
            dgvEquipmentList.DataSource = mappedResults;
        }


        private void DgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;

            if (e.RowIndex == -1)
            {
                return;
            }
            var selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            EquipmentVM equipment = _equipment.FirstOrDefault(w => w.Id == selectedId);
            var editForm = new frmNewEquipment(equipment, MdiParent);
            editForm.Show();
        }

        private void TextBox1_TextChanged(object sender, System.EventArgs e)
        {
            _nameSearch = ((TextBox)sender).Text;
            LoadData();
        }

        private void TextBox2_TextChanged(object sender, System.EventArgs e)
        {
            _serialNumberSearch = ((TextBox)sender).Text;
            LoadData();
        }
    }
}
