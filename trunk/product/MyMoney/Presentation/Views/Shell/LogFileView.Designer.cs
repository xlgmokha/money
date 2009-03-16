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
            this.ux_log_file.BackColor = System.Drawing.Color.Black;
            this.ux_log_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_log_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ux_log_file.ForeColor = System.Drawing.Color.White;
            this.ux_log_file.Location = new System.Drawing.Point(0, 0);
            this.ux_log_file.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ux_log_file.Multiline = true;
            this.ux_log_file.Name = "ux_log_file";
            this.ux_log_file.Size = new System.Drawing.Size(389, 327);
            this.ux_log_file.TabIndex = 0;
            // 
            // LogFileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 327);
            this.Controls.Add(this.ux_log_file);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LogFileView";
            this.TabText = "LogFileView";
            this.Text = "LogFileView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ux_log_file;
    }
}