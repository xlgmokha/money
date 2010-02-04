namespace MoMoney.Presentation.Winforms.Views
{
    partial class AddCompanyView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCompanyView));
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.companiesListView = new System.Windows.Forms.ListView();
            this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ux_cancel_button = new System.Windows.Forms.Button();
            this.ux_company_name = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.ux_submit_button = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).BeginInit();
            this.kryptonGroup2.Panel.SuspendLayout();
            this.kryptonGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).BeginInit();
            this.kryptonSplitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.FormMain;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            this.kryptonHeaderGroup1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(778, 712);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.Text = "Add Company";
            this.kryptonHeaderGroup1.ValuesPrimary.Description = "";
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Add Company";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeaderGroup1.ValuesPrimary.Image")));
            this.kryptonHeaderGroup1.ValuesSecondary.Description = "";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Description";
            this.kryptonHeaderGroup1.ValuesSecondary.Image = null;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonGroup2);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonGroup1);
            this.kryptonSplitContainer1.Panel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.FormMain;
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonSplitContainer2);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(776, 655);
            this.kryptonSplitContainer1.SplitterDistance = 570;
            this.kryptonSplitContainer1.TabIndex = 25;
            // 
            // kryptonGroup2
            // 
            this.kryptonGroup2.Location = new System.Drawing.Point(9, 141);
            this.kryptonGroup2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonGroup2.Name = "kryptonGroup2";
            // 
            // kryptonGroup2.Panel
            // 
            this.kryptonGroup2.Panel.Controls.Add(this.companiesListView);
            this.kryptonGroup2.Size = new System.Drawing.Size(552, 273);
            this.kryptonGroup2.TabIndex = 24;
            // 
            // listView1
            // 
            this.companiesListView.Location = new System.Drawing.Point(2, 34);
            this.companiesListView.Margin = new System.Windows.Forms.Padding(2);
            this.companiesListView.Name = "listView1";
            this.companiesListView.Size = new System.Drawing.Size(550, 182);
            this.companiesListView.TabIndex = 21;
            this.companiesListView.UseCompatibleStateImageBehavior = false;
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.Location = new System.Drawing.Point(8, 3);
            this.kryptonGroup1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroup1.Panel.Controls.Add(this.ux_cancel_button);
            this.kryptonGroup1.Panel.Controls.Add(this.ux_company_name);
            this.kryptonGroup1.Panel.Controls.Add(this.ux_submit_button);
            this.kryptonGroup1.Size = new System.Drawing.Size(532, 110);
            this.kryptonGroup1.TabIndex = 23;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 21);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(101, 20);
            this.kryptonLabel1.TabIndex = 20;
            this.kryptonLabel1.Text = "Company Name:";
            this.kryptonLabel1.Values.ExtraText = "";
            this.kryptonLabel1.Values.Image = null;
            this.kryptonLabel1.Values.Text = "Company Name:";
            // 
            // ux_cancel_button
            // 
            this.ux_cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ux_cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ux_cancel_button.Location = new System.Drawing.Point(206, 63);
            this.ux_cancel_button.Name = "ux_cancel_button";
            this.ux_cancel_button.Size = new System.Drawing.Size(57, 25);
            this.ux_cancel_button.TabIndex = 3;
            this.ux_cancel_button.Text = "Cancel";
            this.ux_cancel_button.UseVisualStyleBackColor = true;
            // 
            // ux_company_name
            // 
            this.ux_company_name.Location = new System.Drawing.Point(110, 21);
            this.ux_company_name.Name = "ux_company_name";
            this.ux_company_name.Size = new System.Drawing.Size(410, 20);
            this.ux_company_name.TabIndex = 1;
            // 
            // ux_submit_button
            // 
            this.ux_submit_button.Location = new System.Drawing.Point(110, 63);
            this.ux_submit_button.Name = "ux_submit_button";
            this.ux_submit_button.Size = new System.Drawing.Size(90, 25);
            this.ux_submit_button.TabIndex = 2;
            this.ux_submit_button.Text = "&Submit";
            this.ux_submit_button.Values.ExtraText = "";
            this.ux_submit_button.Values.Image = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedNormal = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedPressed = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedTracking = null;
            this.ux_submit_button.Values.Text = "&Submit";
            // 
            // kryptonSplitContainer2
            // 
            this.kryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer2.Name = "kryptonSplitContainer2";
            this.kryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer2.Panel1
            // 
            this.kryptonSplitContainer2.Panel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.FormCustom1;
            this.kryptonSplitContainer2.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonSplitContainer2.Size = new System.Drawing.Size(201, 655);
            this.kryptonSplitContainer2.SplitterDistance = 66;
            this.kryptonSplitContainer2.TabIndex = 26;
            // 
            // AddCompanyView
            // 
            this.AcceptButton = this.ux_submit_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ux_cancel_button;
            this.ClientSize = new System.Drawing.Size(778, 712);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddCompanyView";
            this.TabText = "AddExpenseView";
            this.Text = "Add A New Bill";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).EndInit();
            this.kryptonGroup2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).EndInit();
            this.kryptonGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            this.kryptonGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).EndInit();
            this.kryptonSplitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup2;
        private System.Windows.Forms.ListView companiesListView;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.Button ux_cancel_button;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ux_company_name;
        private ComponentFactory.Krypton.Toolkit.KryptonButton ux_submit_button;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer2;

    }
}