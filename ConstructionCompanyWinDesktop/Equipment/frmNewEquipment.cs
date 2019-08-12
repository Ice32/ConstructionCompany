using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;
using System;
using System.Windows.Forms;

namespace ConstructionCompanyWinDesktop.Equipment
{
    public partial class frmNewEquipment : Form
    {

        private readonly Form _parent;
        private readonly APIService<EquipmentVM, EquipmentAddVM, EquipmentAddVM> _equipmentService = new APIService<EquipmentVM, EquipmentAddVM, EquipmentAddVM>("equipment");
        private readonly EquipmentVM _originalEquipment;
        private readonly ValidationUtil _validationUtil;

        public frmNewEquipment(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            _validationUtil = new ValidationUtil(errorProvider1);
        }

        public frmNewEquipment(EquipmentVM equipment, Form parent) : this(parent)
        {
            _originalEquipment = equipment;

            txtEquipmentName.Text = equipment.Name;
            txtEquipmentSerialNumber.Text = equipment.SerialNumber;
            numEquipmentQuantity.Value = equipment.Quantity;
            txtEquipmentDescription.Text = equipment.Description;
            dtEquipmentPurchaseDate.Value = equipment.PurchaseDate ?? DateTime.Now;

            lblNewEquipment.Text = "Uredi opremu";

            if (!CurrentUserManager.IsManager())
            {
                btnSaveEquipment.Visible = false;
            }
        }


        private async void BtnSaveEquipment_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            var equipment = new EquipmentAddVM
            {
                Name = txtEquipmentName.Text,
                Description = txtEquipmentDescription.Text,
                Quantity = (int)numEquipmentQuantity.Value,
                PurchaseDate = dtEquipmentPurchaseDate.Value,
                SerialNumber = txtEquipmentSerialNumber.Text
            };
            if (_originalEquipment != null)
            {
                equipment.Id = _originalEquipment.Id;
                await _equipmentService.Update(_originalEquipment.Id, equipment);
            }
            else
            {
                await _equipmentService.Create(equipment);
            }
            Form listForm = new frmEquipmentList { MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true };
            Close();
            listForm.Show();
        }

        private void TxtEquipmentName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _validationUtil.AssertLength(3, textBox, e);
        }
    }
}
