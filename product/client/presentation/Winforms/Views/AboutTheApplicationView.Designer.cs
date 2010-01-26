namespace MoMoney.Presentation.Winforms.Views
{
    public partial class AboutTheApplicationView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ux_logo = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.uxCopyright = new System.Windows.Forms.Label();
            this.uxCompanyName = new System.Windows.Forms.Label();
            this.uxDescription = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.ux_logo, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.uxCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.uxCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.uxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.ux_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_logo.Location = new System.Drawing.Point(3, 3);
            this.ux_logo.Name = "ux_logo";
            this.tableLayoutPanel.SetRowSpan(this.ux_logo, 6);
            this.ux_logo.Size = new System.Drawing.Size(131, 259);
            this.ux_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ux_logo.TabIndex = 12;
            this.ux_logo.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(143, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(271, 17);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(143, 26);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(271, 17);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxCopyright
            // 
            this.uxCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxCopyright.Location = new System.Drawing.Point(143, 52);
            this.uxCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.uxCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.uxCopyright.Name = "uxCopyright";
            this.uxCopyright.Size = new System.Drawing.Size(271, 17);
            this.uxCopyright.TabIndex = 21;
            this.uxCopyright.Text = "Copyright";
            this.uxCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxCompanyName
            // 
            this.uxCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxCompanyName.Location = new System.Drawing.Point(143, 78);
            this.uxCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.uxCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
            this.uxCompanyName.Name = "uxCompanyName";
            this.uxCompanyName.Size = new System.Drawing.Size(271, 17);
            this.uxCompanyName.TabIndex = 22;
            this.uxCompanyName.Text = "Company Name";
            this.uxCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxDescription
            // 
            this.uxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxDescription.Location = new System.Drawing.Point(143, 107);
            this.uxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.uxDescription.Multiline = true;
            this.uxDescription.Name = "uxDescription";
            this.uxDescription.ReadOnly = true;
            this.uxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uxDescription.Size = new System.Drawing.Size(271, 126);
            this.uxDescription.TabIndex = 23;
            this.uxDescription.TabStop = false;
            this.uxDescription.Text = "Description";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(339, 239);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // about_the_application_view
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "about_the_application_view";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About MoMoney";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox ux_logo;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label uxCopyright;
        private System.Windows.Forms.Label uxCompanyName;
        private System.Windows.Forms.TextBox uxDescription;
        private System.Windows.Forms.Button okButton;
    }
}