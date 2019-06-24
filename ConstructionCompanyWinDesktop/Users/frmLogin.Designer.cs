namespace ConstructionCompanyWinDesktop.Users
{
    partial class frmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoginSubmit = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(75, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(632, 269);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.txtLoginUsername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 69);
            this.panel1.TabIndex = 0;
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.Location = new System.Drawing.Point(245, 35);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(269, 31);
            this.txtLoginUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisničko ime";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.txtLoginPassword);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 69);
            this.panel2.TabIndex = 1;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(245, 35);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(269, 31);
            this.txtLoginPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lozinka";
            // 
            // btnLoginSubmit
            // 
            this.btnLoginSubmit.Location = new System.Drawing.Point(323, 399);
            this.btnLoginSubmit.Name = "btnLoginSubmit";
            this.btnLoginSubmit.Size = new System.Drawing.Size(124, 39);
            this.btnLoginSubmit.TabIndex = 2;
            this.btnLoginSubmit.Text = "Prijavi se";
            this.btnLoginSubmit.UseVisualStyleBackColor = true;
            this.btnLoginSubmit.Click += new System.EventHandler(this.btnLoginSubmit_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLoginSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoginSubmit);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoginSubmit;
    }
}