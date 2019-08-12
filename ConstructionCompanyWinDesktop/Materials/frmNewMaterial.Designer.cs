namespace ConstructionCompanyWinDesktop.Materials
{
    partial class frmNewMaterial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMaterialAmount = new System.Windows.Forms.TextBox();
            this.lblMaterialTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listMaterialUnits = new System.Windows.Forms.ListBox();
            this.lblMaterialUnit = new System.Windows.Forms.Label();
            this.btnMaterialSave = new System.Windows.Forms.Button();
            this.lblNewMaterial = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(536, 327);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMaterialName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(522, 77);
            this.panel2.TabIndex = 0;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Location = new System.Drawing.Point(229, 28);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(271, 31);
            this.txtMaterialName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMaterialAmount);
            this.panel1.Controls.Add(this.lblMaterialTitle);
            this.panel1.Location = new System.Drawing.Point(3, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 81);
            this.panel1.TabIndex = 1;
            // 
            // txtMaterialAmount
            // 
            this.txtMaterialAmount.Location = new System.Drawing.Point(229, 27);
            this.txtMaterialAmount.Name = "txtMaterialAmount";
            this.txtMaterialAmount.Size = new System.Drawing.Size(271, 31);
            this.txtMaterialAmount.TabIndex = 1;
            // 
            // lblMaterialTitle
            // 
            this.lblMaterialTitle.AutoSize = true;
            this.lblMaterialTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.lblMaterialTitle.Location = new System.Drawing.Point(24, 27);
            this.lblMaterialTitle.Name = "lblMaterialTitle";
            this.lblMaterialTitle.Size = new System.Drawing.Size(88, 25);
            this.lblMaterialTitle.TabIndex = 0;
            this.lblMaterialTitle.Text = "Količina";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listMaterialUnits);
            this.panel3.Controls.Add(this.lblMaterialUnit);
            this.panel3.Location = new System.Drawing.Point(3, 173);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 142);
            this.panel3.TabIndex = 2;
            // 
            // listMaterialUnits
            // 
            this.listMaterialUnits.FormattingEnabled = true;
            this.listMaterialUnits.ItemHeight = 25;
            this.listMaterialUnits.Location = new System.Drawing.Point(229, 22);
            this.listMaterialUnits.Name = "listMaterialUnits";
            this.listMaterialUnits.Size = new System.Drawing.Size(271, 104);
            this.listMaterialUnits.TabIndex = 2;
            // 
            // lblMaterialUnit
            // 
            this.lblMaterialUnit.AutoSize = true;
            this.lblMaterialUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F);
            this.lblMaterialUnit.Location = new System.Drawing.Point(24, 22);
            this.lblMaterialUnit.Name = "lblMaterialUnit";
            this.lblMaterialUnit.Size = new System.Drawing.Size(92, 25);
            this.lblMaterialUnit.TabIndex = 0;
            this.lblMaterialUnit.Text = "Jedinica";
            // 
            // btnMaterialSave
            // 
            this.btnMaterialSave.Location = new System.Drawing.Point(216, 391);
            this.btnMaterialSave.Name = "btnMaterialSave";
            this.btnMaterialSave.Size = new System.Drawing.Size(132, 39);
            this.btnMaterialSave.TabIndex = 3;
            this.btnMaterialSave.Text = "Spremi";
            this.btnMaterialSave.UseVisualStyleBackColor = true;
            this.btnMaterialSave.Click += new System.EventHandler(this.BtnSaveMaterial_Click);
            // 
            // lblNewMaterial
            // 
            this.lblNewMaterial.AutoSize = true;
            this.lblNewMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewMaterial.Location = new System.Drawing.Point(188, 9);
            this.lblNewMaterial.Name = "lblNewMaterial";
            this.lblNewMaterial.Size = new System.Drawing.Size(211, 37);
            this.lblNewMaterial.TabIndex = 1;
            this.lblNewMaterial.Text = "Novi materijal";
            // 
            // frmNewMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 446);
            this.Controls.Add(this.lblNewMaterial);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnMaterialSave);
            this.Name = "frmNewMaterial";
            this.Text = "Materijal";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMaterialTitle;
        private System.Windows.Forms.Label lblNewMaterial;
        private System.Windows.Forms.TextBox txtMaterialAmount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox listMaterialUnits;
        private System.Windows.Forms.Label lblMaterialUnit;
        private System.Windows.Forms.Button btnMaterialSave;
    }
}