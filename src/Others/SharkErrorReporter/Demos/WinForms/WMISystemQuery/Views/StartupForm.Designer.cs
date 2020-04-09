namespace WMITest
{
    partial class StartupForm
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.lblMachine = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grdDisplay = new System.Windows.Forms.PropertyGrid();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnQuery);
            this.pnlLeft.Controls.Add(this.cbxQuery);
            this.pnlLeft.Controls.Add(this.lblQuery);
            this.pnlLeft.Controls.Add(this.txtPass);
            this.pnlLeft.Controls.Add(this.lblPassword);
            this.pnlLeft.Controls.Add(this.txtUser);
            this.pnlLeft.Controls.Add(this.lblUser);
            this.pnlLeft.Controls.Add(this.txtMachine);
            this.pnlLeft.Controls.Add(this.lblMachine);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(440, 542);
            this.pnlLeft.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(332, 160);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 28);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "&Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbxQuery
            // 
            this.cbxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuery.FormattingEnabled = true;
            this.cbxQuery.Location = new System.Drawing.Point(119, 127);
            this.cbxQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxQuery.Name = "cbxQuery";
            this.cbxQuery.Size = new System.Drawing.Size(312, 24);
            this.cbxQuery.TabIndex = 8;
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(16, 130);
            this.lblQuery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(80, 17);
            this.lblQuery.TabIndex = 7;
            this.lblQuery.Text = "&Query area";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(119, 95);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(312, 22);
            this.txtPass.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 98);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "&Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(119, 63);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(312, 22);
            this.txtUser.TabIndex = 4;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 66);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(77, 17);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "&User name";
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(119, 31);
            this.txtMachine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(312, 22);
            this.txtMachine.TabIndex = 2;
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Location = new System.Drawing.Point(16, 34);
            this.lblMachine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(100, 17);
            this.lblMachine.TabIndex = 1;
            this.lblMachine.Text = "&Machine name";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grdDisplay);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(440, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(565, 542);
            this.pnlRight.TabIndex = 1;
            // 
            // grdDisplay
            // 
            this.grdDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDisplay.Location = new System.Drawing.Point(0, 0);
            this.grdDisplay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdDisplay.Name = "grdDisplay";
            this.grdDisplay.Size = new System.Drawing.Size(565, 542);
            this.grdDisplay.TabIndex = 0;
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1005, 542);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StartupForm";
            this.Text = "WMI Query demo";
            this.Load += new System.EventHandler(this.StartupForm_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PropertyGrid grdDisplay;
        private System.Windows.Forms.ComboBox cbxQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Button btnQuery;
    }
}

