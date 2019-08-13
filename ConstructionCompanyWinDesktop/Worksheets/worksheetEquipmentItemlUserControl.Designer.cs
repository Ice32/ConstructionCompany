using System.ComponentModel;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    partial class worksheetEquipmentItemUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbWorksheetEquipment = new System.Windows.Forms.ComboBox();
            this.numWorksheetMaterialAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numWorksheetMaterialAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbWorksheetEquipment
            // 
            this.cmbWorksheetEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorksheetEquipment.FormattingEnabled = true;
            this.cmbWorksheetEquipment.Location = new System.Drawing.Point(3, 15);
            this.cmbWorksheetEquipment.Name = "cmbWorksheetEquipment";
            this.cmbWorksheetEquipment.Size = new System.Drawing.Size(205, 33);
            this.cmbWorksheetEquipment.TabIndex = 0;
            // 
            // numWorksheetMaterialAmount
            // 
            this.numWorksheetMaterialAmount.Location = new System.Drawing.Point(214, 16);
            this.numWorksheetMaterialAmount.Name = "numWorksheetMaterialAmount";
            this.numWorksheetMaterialAmount.Size = new System.Drawing.Size(120, 31);
            this.numWorksheetMaterialAmount.TabIndex = 2;
            // 
            // worksheetEquipmentItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numWorksheetMaterialAmount);
            this.Controls.Add(this.cmbWorksheetEquipment);
            this.Name = "worksheetEquipmentItemUserControl";
            this.Size = new System.Drawing.Size(442, 62);
            ((System.ComponentModel.ISupportInitialize)(this.numWorksheetMaterialAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWorksheetEquipment;
        private System.Windows.Forms.NumericUpDown numWorksheetMaterialAmount;
    }
}