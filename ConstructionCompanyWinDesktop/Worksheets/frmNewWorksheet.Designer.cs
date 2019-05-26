using System.ComponentModel;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    partial class frmNewWorksheet
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWorksheetCreateEditHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtWorksheetDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDodajZadatak = new System.Windows.Forms.Button();
            this.btnSaveEditWorksheet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWorksheetCreateEditHeader
            // 
            this.lblWorksheetCreateEditHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorksheetCreateEditHeader.Location = new System.Drawing.Point(647, 67);
            this.lblWorksheetCreateEditHeader.Name = "lblWorksheetCreateEditHeader";
            this.lblWorksheetCreateEditHeader.Size = new System.Drawing.Size(348, 43);
            this.lblWorksheetCreateEditHeader.TabIndex = 0;
            this.lblWorksheetCreateEditHeader.Text = "Novi radni list";
            this.lblWorksheetCreateEditHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum";
            // 
            // dtWorksheetDate
            // 
            this.dtWorksheetDate.Location = new System.Drawing.Point(561, 165);
            this.dtWorksheetDate.Name = "dtWorksheetDate";
            this.dtWorksheetDate.Size = new System.Drawing.Size(411, 31);
            this.dtWorksheetDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Zadaci";
            // 
            // btnDodajZadatak
            // 
            this.btnDodajZadatak.Location = new System.Drawing.Point(561, 309);
            this.btnDodajZadatak.Name = "btnDodajZadatak";
            this.btnDodajZadatak.Size = new System.Drawing.Size(200, 47);
            this.btnDodajZadatak.TabIndex = 7;
            this.btnDodajZadatak.Text = "Dodaj zadatak";
            this.btnDodajZadatak.UseVisualStyleBackColor = true;
            this.btnDodajZadatak.Click += new System.EventHandler(this.BtnDodajZadatak_Click);
            // 
            // btnSaveEditWorksheet
            // 
            this.btnSaveEditWorksheet.Location = new System.Drawing.Point(561, 672);
            this.btnSaveEditWorksheet.Name = "btnSaveEditWorksheet";
            this.btnSaveEditWorksheet.Size = new System.Drawing.Size(143, 47);
            this.btnSaveEditWorksheet.TabIndex = 8;
            this.btnSaveEditWorksheet.Text = "Spremi";
            this.btnSaveEditWorksheet.UseVisualStyleBackColor = true;
            this.btnSaveEditWorksheet.Click += new System.EventHandler(this.BtnSaveEditWorksheet_Click);
            // 
            // frmNewWorksheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1629, 767);
            this.Controls.Add(this.btnSaveEditWorksheet);
            this.Controls.Add(this.btnDodajZadatak);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtWorksheetDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWorksheetCreateEditHeader);
            this.Name = "frmNewWorksheet";
            this.Text = "frmNewWorksheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWorksheetCreateEditHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtWorksheetDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDodajZadatak;
        private System.Windows.Forms.Button btnSaveEditWorksheet;
    }
}