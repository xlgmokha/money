namespace MoMoney.Presentation.Views.Shell
{
    partial class LogFileView
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
            this.ux_log_file = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ux_log_file
            // 
            this.ux_log_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_log_file.Location = new System.Drawing.Point(0, 0);
            this.ux_log_file.Multiline = true;
            this.ux_log_file.Name = "ux_log_file";
            this.ux_log_file.Size = new System.Drawing.Size(292, 266);
            this.ux_log_file.TabIndex = 0;
            // 
            // LogFileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.ux_log_file);
            this.Name = "LogFileView";
            this.Text = "LogFileView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ux_log_file;
    }
}