using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class worksheetMaterialUserControl : UserControl
    {
        private readonly APIClient _materialsClient = new APIClient("materials");
        private readonly WorksheetMaterialVM _material;
        private List<MaterialVM> _materials;
        public worksheetMaterialUserControl()
        {
            InitializeComponent();
        }

        public worksheetMaterialUserControl(WorksheetMaterialVM material, Action rerender, EventHandler removeHandler): this()
        {
            numWorksheetMaterialAmount.Text = material.Amount.ToString();
            numWorksheetMaterialAmount.KeyUp += (sender, args) => { material.Amount = Convert.ToDouble(((NumericUpDown)sender).Value); };
            _material = material;
            LoadMaterials();
        }

        private async void LoadMaterials()
        {
            List<MaterialVM> materials = await _materialsClient.Get<List<MaterialVM>>("");
            _materials = materials;
            cmbWorksheetMaterial.DataSource = materials;
            cmbWorksheetMaterial.DisplayMember = "Name";
            cmbWorksheetMaterial.ValueMember = "Id";

            cmbWorksheetMaterial.SelectedValue = _material.MaterialId;
            cmbWorksheetMaterial.SelectedIndexChanged += (sender, args) =>
            {
                int selectedMaterialId = (int)cmbWorksheetMaterial.SelectedValue;
                _material.MaterialId = selectedMaterialId;
                MaterialVM selectedMaterial = MaterialFromId(selectedMaterialId);

                if (selectedMaterial != null)
                {
                    lblWorksheetMaterialUnit.Text = selectedMaterial.Unit.ToString();
                }
            };
            numWorksheetMaterialAmount.ValueChanged += (sender, args) =>
            {
                double value = Convert.ToDouble(((NumericUpDown) sender).Value);
                _material.Amount = value;
            };
            if (_material.MaterialId != 0)
            {
                MaterialVM selectedMaterial = MaterialFromId(_material.MaterialId);
                lblWorksheetMaterialUnit.Text = selectedMaterial.Unit.ToString();
            }
        }

        private MaterialVM MaterialFromId(int selectedMaterialId)
        {
            return _materials.Find(m => m.Id == selectedMaterialId);
        }
    }
}
