namespace MoMoney.Presentation.Views.billing
{
    partial class AddBillPaymentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBillPaymentView));
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ux_amount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ux_due_date = new System.Windows.Forms.DateTimePicker();
            this.ux_submit_button = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ux_company_names = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonSplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.ux_bil_payments_grid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
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
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).BeginInit();
            this.kryptonSplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).BeginInit();
            this.kryptonSplitContainer2.Panel2.SuspendLayout();
            this.kryptonSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_bil_payments_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(777, 838);
            this.kryptonHeaderGroup1.TabIndex = 7;
            this.kryptonHeaderGroup1.Text = "Add Bill Payment";
            this.kryptonHeaderGroup1.ValuesPrimary.Description = "";
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Add Bill Payment";
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonSplitContainer2);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(775, 788);
            this.kryptonSplitContainer1.SplitterDistance = 335;
            this.kryptonSplitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ux_amount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.ux_due_date, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.ux_submit_button, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.ux_company_names, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(306, 130);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount: $";
            // 
            // ux_amount
            // 
            this.ux_amount.Location = new System.Drawing.Point(110, 35);
            this.ux_amount.Name = "ux_amount";
            this.ux_amount.Size = new System.Drawing.Size(193, 20);
            this.ux_amount.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "When:";
            // 
            // ux_due_date
            // 
            this.ux_due_date.Location = new System.Drawing.Point(110, 67);
            this.ux_due_date.Name = "ux_due_date";
            this.ux_due_date.Size = new System.Drawing.Size(193, 20);
            this.ux_due_date.TabIndex = 5;
            // 
            // ux_submit_button
            // 
            this.ux_submit_button.Location = new System.Drawing.Point(110, 99);
            this.ux_submit_button.Name = "ux_submit_button";
            this.ux_submit_button.Size = new System.Drawing.Size(90, 25);
            this.ux_submit_button.TabIndex = 7;
            this.ux_submit_button.Text = "&Submit";
            this.ux_submit_button.Values.ExtraText = "";
            this.ux_submit_button.Values.Image = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedNormal = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedPressed = null;
            this.ux_submit_button.Values.ImageStates.ImageCheckedTracking = null;
            this.ux_submit_button.Values.Text = "&Submit";
            // 
            // ux_company_names
            // 
            this.ux_company_names.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ux_company_names.DropDownWidth = 121;
            this.ux_company_names.FormattingEnabled = false;
            this.ux_company_names.Location = new System.Drawing.Point(110, 3);
            this.ux_company_names.Name = "ux_company_names";
            this.ux_company_names.Size = new System.Drawing.Size(193, 22);
            this.ux_company_names.TabIndex = 8;
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
            this.kryptonSplitContainer2.Panel1.Controls.Add(this.kryptonHeader1);
            // 
            // kryptonSplitContainer2.Panel2
            // 
            this.kryptonSplitContainer2.Panel2.Controls.Add(this.ux_bil_payments_grid);
            this.kryptonSplitContainer2.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonSplitContainer2.Size = new System.Drawing.Size(435, 788);
            this.kryptonSplitContainer2.SplitterDistance = 38;
            this.kryptonSplitContainer2.TabIndex = 0;
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Location = new System.Drawing.Point(4, 4);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(140, 29);
            this.kryptonHeader1.TabIndex = 0;
            this.kryptonHeader1.Text = "Bill Payments";
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "Bill Payments";
            this.kryptonHeader1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeader1.Values.Image")));
            // 
            // ux_bil_payments_grid
            // 
            this.ux_bil_payments_grid.AllowUserToAddRows = false;
            this.ux_bil_payments_grid.AllowUserToDeleteRows = false;
            this.ux_bil_payments_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ux_bil_payments_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_bil_payments_grid.Location = new System.Drawing.Point(0, 0);
            this.ux_bil_payments_grid.Name = "ux_bil_payments_grid";
            this.ux_bil_payments_grid.ReadOnly = true;
            this.ux_bil_payments_grid.Size = new System.Drawing.Size(435, 745);
            this.ux_bil_payments_grid.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.ux_bil_payments_grid.TabIndex = 0;
            // 
            // add_bill_payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 838);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "add_bill_payment";
            this.TabText = "bill_payments";
            this.Text = "bill_payments";
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel1)).EndInit();
            this.kryptonSplitContainer2.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2.Panel2)).EndInit();
            this.kryptonSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer2)).EndInit();
            this.kryptonSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ux_bil_payments_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ux_amount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ux_due_date;
        private ComponentFactory.Krypton.Toolkit.KryptonButton ux_submit_button;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox ux_company_names;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer2;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView ux_bil_payments_grid;
    }
}