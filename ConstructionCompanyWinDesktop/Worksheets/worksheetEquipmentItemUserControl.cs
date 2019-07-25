using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class worksheetEquipmentItemUserControl : UserControl
    {
        private readonly APIClient _equipmentClient = new APIClient("equipment");
        private readonly WorksheetEquipmentVM _equipmentItem;
        private List<EquipmentVM> _equipment;
        public worksheetEquipmentItemUserControl()
        {
            InitializeComponent();
        }

        public worksheetEquipmentItemUserControl(WorksheetEquipmentVM equipment, Action rerender, EventHandler removeHandler): this()
        {
            numWorksheetMaterialAmount.Text = equipment.Quantity.ToString();
            numWorksheetMaterialAmount.KeyUp += (sender, args) => { equipment.Quantity = Convert.ToDouble(((NumericUpDown)sender).Value); };
            _equipmentItem = equipment;
            LoadEquipment();
        }

        private async void LoadEquipment()
        {
            List<EquipmentVM> equipment = await _equipmentClient.Get<List<EquipmentVM>>("");
            _equipment = equipment;
            cmbWorksheetEquipment.DataSource = equipment;
            cmbWorksheetEquipment.DisplayMember = "Name";
            cmbWorksheetEquipment.ValueMember = "Id";

            cmbWorksheetEquipment.SelectedValue = _equipmentItem.EquipmentId;
            cmbWorksheetEquipment.SelectedIndexChanged += (sender, args) =>
            {
                int selectedEquipmentId = (int)cmbWorksheetEquipment.SelectedValue;
                _equipmentItem.EquipmentId = selectedEquipmentId;

            };
            numWorksheetMaterialAmount.ValueChanged += (sender, args) =>
            {
                double value = Convert.ToDouble(((NumericUpDown) sender).Value);
                _equipmentItem.Quantity = value;
            };
        }
    }
}
