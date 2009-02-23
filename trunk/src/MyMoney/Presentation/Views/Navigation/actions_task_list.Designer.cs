namespace MyMoney.Presentation.Views.Navigation
{
    partial class actions_task_list
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
            this.ux_system_task_pane = new XPExplorerBar.TaskPane();
            this.ux_company_pane = new XPExplorerBar.Expando();
            this.ux_add_company = new XPExplorerBar.TaskItem();
            this.ux_income_pane = new XPExplorerBar.Expando();
            this.ux_add_new_income = new XPExplorerBar.TaskItem();
            this.ux_view_all_income = new XPExplorerBar.TaskItem();
            this.ux_billing_pane = new XPExplorerBar.Expando();
            this.ux_add_bill_payment = new XPExplorerBar.TaskItem();
            this.ux_view_all_bill_payments = new XPExplorerBar.TaskItem();
            this.ux_reporing_pane = new XPExplorerBar.Expando();
            this.ux_view_all_bill_payments_report = new XPExplorerBar.TaskItem();
            ((System.ComponentModel.ISupportInitialize)(this.ux_system_task_pane)).BeginInit();
            this.ux_system_task_pane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_company_pane)).BeginInit();
            this.ux_company_pane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_income_pane)).BeginInit();
            this.ux_income_pane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_billing_pane)).BeginInit();
            this.ux_billing_pane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_reporing_pane)).BeginInit();
            this.ux_reporing_pane.SuspendLayout();
            this.SuspendLayout();
            // 
            // ux_system_task_pane
            // 
            this.ux_system_task_pane.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.ux_system_task_pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_system_task_pane.Expandos.AddRange(new XPExplorerBar.Expando[] {
            this.ux_company_pane,
            this.ux_income_pane,
            this.ux_billing_pane,
            this.ux_reporing_pane});
            this.ux_system_task_pane.Location = new System.Drawing.Point(0, 0);
            this.ux_system_task_pane.Name = "ux_system_task_pane";
            this.ux_system_task_pane.Size = new System.Drawing.Size(237, 743);
            this.ux_system_task_pane.TabIndex = 2;
            this.ux_system_task_pane.Text = "taskPane1";
            // 
            // ux_company_pane
            // 
            this.ux_company_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_company_pane.AutoLayout = true;
            this.ux_company_pane.ExpandedHeight = 62;
            this.ux_company_pane.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ux_company_pane.Items.AddRange(new System.Windows.Forms.Control[] {
            this.ux_add_company});
            this.ux_company_pane.Location = new System.Drawing.Point(12, 12);
            this.ux_company_pane.Name = "ux_company_pane";
            this.ux_company_pane.Size = new System.Drawing.Size(213, 62);
            this.ux_company_pane.SpecialGroup = true;
            this.ux_company_pane.TabIndex = 5;
            this.ux_company_pane.Text = "Company";
            // 
            // ux_add_company
            // 
            this.ux_add_company.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_add_company.BackColor = System.Drawing.Color.Transparent;
            this.ux_add_company.Image = null;
            this.ux_add_company.Location = new System.Drawing.Point(12, 35);
            this.ux_add_company.Name = "ux_add_company";
            this.ux_add_company.Size = new System.Drawing.Size(187, 16);
            this.ux_add_company.TabIndex = 0;
            this.ux_add_company.Text = "Add Company";
            this.ux_add_company.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ux_add_company.UseVisualStyleBackColor = false;
            // 
            // ux_income_pane
            // 
            this.ux_income_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_income_pane.AutoLayout = true;
            this.ux_income_pane.ExpandedHeight = 82;
            this.ux_income_pane.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ux_income_pane.Items.AddRange(new System.Windows.Forms.Control[] {
            this.ux_add_new_income,
            this.ux_view_all_income});
            this.ux_income_pane.Location = new System.Drawing.Point(12, 86);
            this.ux_income_pane.Name = "ux_income_pane";
            this.ux_income_pane.Size = new System.Drawing.Size(213, 82);
            this.ux_income_pane.SpecialGroup = true;
            this.ux_income_pane.TabIndex = 4;
            this.ux_income_pane.Text = "Income";
            // 
            // ux_add_new_income
            // 
            this.ux_add_new_income.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_add_new_income.BackColor = System.Drawing.Color.Transparent;
            this.ux_add_new_income.Image = null;
            this.ux_add_new_income.Location = new System.Drawing.Point(12, 35);
            this.ux_add_new_income.Name = "ux_add_new_income";
            this.ux_add_new_income.Size = new System.Drawing.Size(187, 16);
            this.ux_add_new_income.TabIndex = 2;
            this.ux_add_new_income.Text = "Add Income";
            this.ux_add_new_income.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ux_add_new_income.UseVisualStyleBackColor = false;
            // 
            // ux_view_all_income
            // 
            this.ux_view_all_income.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_view_all_income.BackColor = System.Drawing.Color.Transparent;
            this.ux_view_all_income.Image = null;
            this.ux_view_all_income.Location = new System.Drawing.Point(12, 55);
            this.ux_view_all_income.Name = "ux_view_all_income";
            this.ux_view_all_income.Size = new System.Drawing.Size(187, 16);
            this.ux_view_all_income.TabIndex = 3;
            this.ux_view_all_income.Text = "View All Income";
            this.ux_view_all_income.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ux_view_all_income.UseVisualStyleBackColor = false;
            // 
            // ux_billing_pane
            // 
            this.ux_billing_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_billing_pane.AutoLayout = true;
            this.ux_billing_pane.ExpandedHeight = 82;
            this.ux_billing_pane.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ux_billing_pane.Items.AddRange(new System.Windows.Forms.Control[] {
            this.ux_add_bill_payment,
            this.ux_view_all_bill_payments});
            this.ux_billing_pane.Location = new System.Drawing.Point(12, 180);
            this.ux_billing_pane.Name = "ux_billing_pane";
            this.ux_billing_pane.Size = new System.Drawing.Size(213, 82);
            this.ux_billing_pane.SpecialGroup = true;
            this.ux_billing_pane.TabIndex = 0;
            this.ux_billing_pane.Text = "Bills";
            // 
            // ux_add_bill_payment
            // 
            this.ux_add_bill_payment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_add_bill_payment.BackColor = System.Drawing.Color.Transparent;
            this.ux_add_bill_payment.Image = null;
            this.ux_add_bill_payment.Location = new System.Drawing.Point(12, 35);
            this.ux_add_bill_payment.Name = "ux_add_bill_payment";
            this.ux_add_bill_payment.Size = new System.Drawing.Size(187, 16);
            this.ux_add_bill_payment.TabIndex = 1;
            this.ux_add_bill_payment.Text = "Add Bill Payments";
            this.ux_add_bill_payment.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ux_add_bill_payment.UseVisualStyleBackColor = false;
            // 
            // ux_view_all_bill_payments
            // 
            this.ux_view_all_bill_payments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_view_all_bill_payments.BackColor = System.Drawing.Color.Transparent;
            this.ux_view_all_bill_payments.Image = null;
            this.ux_view_all_bill_payments.Location = new System.Drawing.Point(12, 55);
            this.ux_view_all_bill_payments.Name = "ux_view_all_bill_payments";
            this.ux_view_all_bill_payments.Size = new System.Drawing.Size(187, 16);
            this.ux_view_all_bill_payments.TabIndex = 2;
            this.ux_view_all_bill_payments.Text = "View All Bill Payments";
            this.ux_view_all_bill_payments.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ux_view_all_bill_payments.UseVisualStyleBackColor = false;
            // 
            // ux_reporing_pane
            // 
            this.ux_reporing_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_reporing_pane.AutoLayout = true;
            this.ux_reporing_pane.ExpandedHeight = 62;
            this.ux_reporing_pane.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ux_reporing_pane.Items.AddRange(new System.Windows.Forms.Control[] {
            this.ux_view_all_bill_payments_report});
            this.ux_reporing_pane.Location = new System.Drawing.Point(12, 274);
            this.ux_reporing_pane.Name = "ux_reporing_pane";
            this.ux_reporing_pane.Size = new System.Drawing.Size(213, 62);
            this.ux_reporing_pane.SpecialGroup = true;
            this.ux_reporing_pane.TabIndex = 3;
            this.ux_reporing_pane.Text = "Reports";
            // 
            // ux_view_all_bill_payments_report
            // 
            this.ux_view_all_bill_payments_report.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_view_all_bill_payments_report.BackColor = System.Drawing.Color.Transparent;
            this.ux_view_all_bill_payments_report.Image = null;
            this.ux_view_all_bill_payments_report.Location = new System.Drawing.Point(12, 35);
            this.ux_view_all_bill_payments_report.Name = "ux_view_all_bill_payments_report";
            this.ux_view_all_bill_payments_report.Size = new System.Drawing.Size(187, 16);
            this.ux_view_all_bill_payments_report.TabIndex = 2;
            this.ux_view_all_bill_payments_report.Text = "View All Bill Payments";
            this.ux_view_all_bill_payments_report.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ux_view_all_bill_payments_report.UseVisualStyleBackColor = false;
            // 
            // actions_task_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 743);
            this.Controls.Add(this.ux_system_task_pane);
            this.Name = "actions_task_list";
            this.TabText = "actions_task_list";
            this.Text = "actions_task_list";
            ((System.ComponentModel.ISupportInitialize)(this.ux_system_task_pane)).EndInit();
            this.ux_system_task_pane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ux_company_pane)).EndInit();
            this.ux_company_pane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ux_income_pane)).EndInit();
            this.ux_income_pane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ux_billing_pane)).EndInit();
            this.ux_billing_pane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ux_reporing_pane)).EndInit();
            this.ux_reporing_pane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private XPExplorerBar.TaskPane ux_system_task_pane;
        private XPExplorerBar.Expando ux_billing_pane;
        private XPExplorerBar.TaskItem ux_add_company;
        private XPExplorerBar.TaskItem ux_add_bill_payment;
        private XPExplorerBar.TaskItem ux_view_all_bill_payments;
        private XPExplorerBar.Expando ux_reporing_pane;
        private XPExplorerBar.TaskItem ux_view_all_bill_payments_report;
        private XPExplorerBar.Expando ux_income_pane;
        private XPExplorerBar.TaskItem ux_add_new_income;
        private XPExplorerBar.Expando ux_company_pane;
        private XPExplorerBar.TaskItem ux_view_all_income;
    }
}