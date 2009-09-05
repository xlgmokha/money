namespace MoMoney.Presentation.Views.billing
{
    /// <summary>
    /// Summary description for view_all_bills.
    /// </summary>
    partial class ViewAllBillsReport
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAllBillsReport));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.ux_company_name = new DataDynamics.ActiveReports.RichTextBox();
            this.ux_due_date = new DataDynamics.ActiveReports.RichTextBox();
            this.ux_amount = new DataDynamics.ActiveReports.RichTextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0.25F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                                                                                         this.ux_company_name,
                                                                                         this.ux_due_date,
                                                                                         this.ux_amount});
            this.detail.Height = 2F;
            this.detail.Name = "detail";
            // 
            // ux_company_name
            // 
            this.ux_company_name.AutoReplaceFields = true;
            this.ux_company_name.Border.BottomColor = System.Drawing.Color.Black;
            this.ux_company_name.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_company_name.Border.LeftColor = System.Drawing.Color.Black;
            this.ux_company_name.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_company_name.Border.RightColor = System.Drawing.Color.Black;
            this.ux_company_name.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_company_name.Border.TopColor = System.Drawing.Color.Black;
            this.ux_company_name.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_company_name.Font = new System.Drawing.Font("Arial", 10F);
            this.ux_company_name.Height = 0.25F;
            this.ux_company_name.Left = 0.875F;
            this.ux_company_name.Name = "ux_company_name";
            this.ux_company_name.RTF = resources.GetString("ux_company_name.RTF");
            this.ux_company_name.Top = 0.125F;
            this.ux_company_name.Width = 1.625F;
            // 
            // ux_due_date
            // 
            this.ux_due_date.AutoReplaceFields = true;
            this.ux_due_date.Border.BottomColor = System.Drawing.Color.Black;
            this.ux_due_date.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_due_date.Border.LeftColor = System.Drawing.Color.Black;
            this.ux_due_date.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_due_date.Border.RightColor = System.Drawing.Color.Black;
            this.ux_due_date.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_due_date.Border.TopColor = System.Drawing.Color.Black;
            this.ux_due_date.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_due_date.Font = new System.Drawing.Font("Arial", 10F);
            this.ux_due_date.Height = 0.25F;
            this.ux_due_date.Left = 0.875F;
            this.ux_due_date.Name = "ux_due_date";
            this.ux_due_date.RTF = resources.GetString("ux_due_date.RTF");
            this.ux_due_date.Top = 0.4375F;
            this.ux_due_date.Width = 1.6875F;
            // 
            // ux_amount
            // 
            this.ux_amount.AutoReplaceFields = true;
            this.ux_amount.Border.BottomColor = System.Drawing.Color.Black;
            this.ux_amount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_amount.Border.LeftColor = System.Drawing.Color.Black;
            this.ux_amount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_amount.Border.RightColor = System.Drawing.Color.Black;
            this.ux_amount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_amount.Border.TopColor = System.Drawing.Color.Black;
            this.ux_amount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ux_amount.Font = new System.Drawing.Font("Arial", 10F);
            this.ux_amount.Height = 0.25F;
            this.ux_amount.Left = 0.875F;
            this.ux_amount.Name = "ux_amount";
            this.ux_amount.RTF = resources.GetString("ux_amount.RTF");
            this.ux_amount.Top = 0.75F;
            this.ux_amount.Width = 1.6875F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.25F;
            this.pageFooter.Name = "pageFooter";
            // 
            // view_all_bills_report
            // 
            this.MasterReport = true;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                                                            "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                                                            "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.RichTextBox ux_company_name;
        private DataDynamics.ActiveReports.RichTextBox ux_due_date;
        private DataDynamics.ActiveReports.RichTextBox ux_amount;
    }
}