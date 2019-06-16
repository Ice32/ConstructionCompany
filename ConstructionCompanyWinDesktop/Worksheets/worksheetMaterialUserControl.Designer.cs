using System.ComponentModel;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    partial class worksheetMaterialUserControl
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
            this.cmbWorksheetMaterial = new System.Windows.Forms.ComboBox();
            this.numWorksheetMaterialAmount = new System.Windows.Forms.NumericUpDown();
            this.lblWorksheetMaterialUnit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numWorksheetMaterialAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbWorksheetMaterial
            // 
            this.cmbWorksheetMaterial.FormattingEnabled = true;
            this.cmbWorksheetMaterial.Location = new System.Drawing.Point(3, 15);
            this.cmbWorksheetMaterial.Name = "cmbWorksheetMaterial";
            this.cmbWorksheetMaterial.Size = new System.Drawing.Size(205, 33);
            this.cmbWorksheetMaterial.TabIndex = 0;
            // 
            // numWorksheetMaterialAmount
            // 
            this.numWorksheetMaterialAmount.Location = new System.Drawing.Point(214, 19);
            this.numWorksheetMaterialAmount.Name = "numWorksheetMaterialAmount";
            this.numWorksheetMaterialAmount.Size = new System.Drawing.Size(120, 31);
            this.numWorksheetMaterialAmount.TabIndex = 2;
            // 
            // lblWorksheetMaterialUnit
            // 
            this.lblWorksheetMaterialUnit.AutoSize = true;
            this.lblWorksheetMaterialUnit.Location = new System.Drawing.Point(340, 25);
            this.lblWorksheetMaterialUnit.Name = "lblWorksheetMaterialUnit";
            this.lblWorksheetMaterialUnit.Size = new System.Drawing.Size(47, 25);
            this.lblWorksheetMaterialUnit.TabIndex = 3;
            this.lblWorksheetMaterialUnit.Text = "unit";
            // 
            // worksheetMaterialUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblWorksheetMaterialUnit);
            this.Controls.Add(this.numWorksheetMaterialAmount);
            this.Controls.Add(this.cmbWorksheetMaterial);
            this.Name = "worksheetMaterialUserControl";
            this.Size = new System.Drawing.Size(442, 62);
            ((System.ComponentModel.ISupportInitialize)(this.numWorksheetMaterialAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWorksheetMaterial;
        private System.Windows.Forms.NumericUpDown numWorksheetMaterialAmount;
        private System.Windows.Forms.Label lblWorksheetMaterialUnit;
    }
}