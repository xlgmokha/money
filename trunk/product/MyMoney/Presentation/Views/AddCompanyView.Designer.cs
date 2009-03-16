namespace MoMoney.Presentation.Views
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
            this.ux_submit_button = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ux_company_name = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.ux_cancel_button = new System.Windows.Forms.Button();
            this.kryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.ux_companys_listing = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ux_company_search_textbox = new System.Windows.Forms.TextBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).BeginInit();
            this.kryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).BeginInit();
            this.kryptonSplitContainer2.Panel2.SuspendLayout();
            this.kryptonSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_companys_listing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(1037, 876);
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
            this.kryptonSplitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.objectListView1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.listView2);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.ux_company_search_textbox);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.listView1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.ux_submit_button);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonLabel1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.ux_company_name);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.ux_cancel_button);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonSplitContainer2);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1035, 813);
            this.kryptonSplitContainer1.SplitterDistance = 764;
            this.kryptonSplitContainer1.TabIndex = 25;
            // 
            // ux_submit_button
            // 
            this.ux_submit_button.Location = new System.Drawing.Point(147, 78);
            this.ux_submit_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ux_submit_button.Name = "ux_submit_button";
            this.ux_submit_button.Size = new System.Drawing.Size(120, 31);
            this.ux_submit_button.TabIndex = 2;
            this.ux_submit_button.Text = "&Submit";
            this.ux_submit_button.Values.ExtraText = "";
            this.ux_submit_button.Values.Image = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedNormal = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedPressed = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedTracking = null;
            this.ux_submit_button.Values.Text = "&Submit";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(15, 27);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(125, 24);
            this.kryptonLabel1.TabIndex = 20;
            this.kryptonLabel1.Text = "Company Name:";
            this.kryptonLabel1.Values.ExtraText = "";
            this.kryptonLabel1.Values.Image = null;
            this.kryptonLabel1.Values.Text = "Company Name:";
            // 
            // ux_company_name
            // 
            this.ux_company_name.Location = new System.Drawing.Point(147, 27);
            this.ux_company_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ux_company_name.Name = "ux_company_name";
            this.ux_company_name.Size = new System.Drawing.Size(547, 24);
            this.ux_company_name.TabIndex = 1;
            // 
            // ux_cancel_button
            // 
            this.ux_cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ux_cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ux_cancel_button.Location = new System.Drawing.Point(275, 78);
            this.ux_cancel_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ux_cancel_button.Name = "ux_cancel_button";
            this.ux_cancel_button.Size = new System.Drawing.Size(76, 31);
            this.ux_cancel_button.TabIndex = 3;
            this.ux_cancel_button.Text = "Cancel";
            this.ux_cancel_button.UseVisualStyleBackColor = true;
            // 
            // kryptonSplitContainer2
            // 
            this.kryptonSplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonSplitContainer2.Name = "kryptonSplitContainer2";
            this.kryptonSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer2.Panel1
            // 
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.kryptonHeader1);
            // 
            // kryptonSplitContainer2.Panel2
            // 
            this.kryptonSplitContainer2.Panel2.Controls.Add(this.ux_companys_listing);
            this.kryptonSplitContainer2.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonSplitContainer2.Size = new System.Drawing.Size(266, 813);
            this.kryptonSplitContainer2.SplitterDistance = 46;
            this.kryptonSplitContainer2.TabIndex = 26;
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Location = new System.Drawing.Point(4, 4);
            this.kryptonHeader1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(144, 37);
            this.kryptonHeader1.TabIndex = 25;
            this.kryptonHeader1.Text = "Companys";
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "Companys";
            this.kryptonHeader1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeader1.Values.Image")));
            // 
            // ux_companys_listing
            // 
            this.ux_companys_listing.AllowUserToAddRows = false;
            this.ux_companys_listing.AllowUserToDeleteRows = false;
            this.ux_companys_listing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ux_companys_listing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_companys_listing.Location = new System.Drawing.Point(0, 0);
            this.ux_companys_listing.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ux_companys_listing.Name = "ux_companys_listing";
            this.ux_companys_listing.ReadOnly = true;
            this.ux_companys_listing.Size = new System.Drawing.Size(266, 762);
            this.ux_companys_listing.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.ux_companys_listing.TabIndex = 25;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(28, 241);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(706, 97);
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ux_company_search_textbox
            // 
            this.ux_company_search_textbox.Location = new System.Drawing.Point(518, 389);
            this.ux_company_search_textbox.Name = "ux_company_search_textbox";
            this.ux_company_search_textbox.Size = new System.Drawing.Size(216, 22);
            this.ux_company_search_textbox.TabIndex = 22;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(28, 417);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(706, 80);
            this.listView2.TabIndex = 23;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // objectListView1
            // 
            this.objectListView1.ItemRenderer = null;
            this.objectListView1.Location = new System.Drawing.Point(28, 514);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(706, 203);
            this.objectListView1.TabIndex = 24;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // AddCompanyView
            // 
            this.AcceptButton = this.ux_submit_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ux_cancel_button;
            this.ClientSize = new System.Drawing.Size(1037, 876);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddCompanyView";
            this.TabText = "AddExpenseView";
            this.Text = "Add A New Bill";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).EndInit();
            this.kryptonSplitContainer2.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).EndInit();
            this.kryptonSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).EndInit();
            this.kryptonSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ux_companys_listing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ux_company_name;
        private System.Windows.Forms.Button ux_cancel_button;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton ux_submit_button;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView ux_companys_listing;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox ux_company_search_textbox;
        private System.Windows.Forms.ListView listView2;
        private BrightIdeasSoftware.ObjectListView objectListView1;

    }
}