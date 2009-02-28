namespace MyMoney.Presentation.Views.reporting
{
    partial class report_viewer
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
            this.ux_report_viewer = new DataDynamics.ActiveReports.Viewer.Viewer();
            this.SuspendLayout();
            // 
            // ux_report_viewer
            // 
            this.ux_report_viewer.BackColor = System.Drawing.SystemColors.Control;
            this.ux_report_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_report_viewer.Document = new DataDynamics.ActiveReports.Document.Document("ARNet Document");
            this.ux_report_viewer.Location = new System.Drawing.Point(0, 0);
            this.ux_report_viewer.Name = "ux_report_viewer";
            this.ux_report_viewer.ReportViewer.CurrentPage = 0;
            this.ux_report_viewer.ReportViewer.MultiplePageCols = 3;
            this.ux_report_viewer.ReportViewer.MultiplePageRows = 2;
            this.ux_report_viewer.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal;
            this.ux_report_viewer.Size = new System.Drawing.Size(770, 625);
            this.ux_report_viewer.TabIndex = 0;
            this.ux_report_viewer.TableOfContents.Text = "Table Of Contents";
            this.ux_report_viewer.TableOfContents.Width = 200;
            this.ux_report_viewer.TabTitleLength = 35;
            this.ux_report_viewer.Toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // report_viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 625);
            this.Controls.Add(this.ux_report_viewer);
            this.Name = "report_viewer";
            this.Text = "report_viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private DataDynamics.ActiveReports.Viewer.Viewer ux_report_viewer;
    }
}