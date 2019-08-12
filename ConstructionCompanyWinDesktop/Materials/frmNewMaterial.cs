using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Materials
{
    public partial class frmNewMaterial : Form
    {
        private readonly Form _parent;
        private readonly APIService<MaterialVM, MaterialAddVM, MaterialAddVM> _materialsService = new APIService<MaterialVM, MaterialAddVM, MaterialAddVM>("materials");
        private readonly MaterialVM _originalMaterial;
        private readonly ValidationUtil _validationUtil;

        public frmNewMaterial(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            SetUnits();
            _validationUtil = new ValidationUtil(errorProvider1);
        }
        
        public frmNewMaterial(MaterialVM material, Form parent) : this(parent)
        {
            _originalMaterial = material;

            txtMaterialName.Text = material.Name;
            numMaterialQuantity.Value = Convert.ToDecimal(material.Amount);

            lblNewMaterial.Text = "Uredi materijal";

            listMaterialUnits.SelectedValue = (int)_originalMaterial.Unit;

            if (!CurrentUserManager.IsManager())
            {
                btnMaterialSave.Visible = false;
            }
        }
        
        private void SetUnits()
        {
            List<MeasurementUnit> measurementUnits = Enum.GetValues(typeof(MeasurementUnit)).Cast<MeasurementUnit>().ToList();
            listMaterialUnits.DataSource = measurementUnits.Select(v => new ListBoxItem((int)v, v.ToString()) ).ToList();
            listMaterialUnits.DisplayMember = "Name";
            listMaterialUnits.ValueMember = "Id";
        }

        private async void BtnSaveMaterial_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            var material = new MaterialAddVM
            {
                Name = txtMaterialName.Text,
                Amount = Convert.ToDouble(numMaterialQuantity.Value),
                Unit = (MeasurementUnit)((ListBoxItem)listMaterialUnits.SelectedItem).Id
            };
            if (_originalMaterial != null)
            {
                material.Id = _originalMaterial.Id;
                await _materialsService.Update(_originalMaterial.Id, material);
            }
            else
            {
                await _materialsService.Create(material);
            }
            Form listForm = new frmMaterialsList { MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true};
            Close();
            listForm.Show();
        }

        private void TxtMaterialName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _validationUtil.AssertLength(3, textBox, e);
        }
    }
}
