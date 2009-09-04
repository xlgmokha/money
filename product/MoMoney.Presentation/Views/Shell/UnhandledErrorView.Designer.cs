namespace MoMoney.Presentation.Views.Shell
{
    partial class UnhandledErrorView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ux_message = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ux_image = new System.Windows.Forms.PictureBox();
            this.restart_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_image)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ux_image);
            this.groupBox1.Controls.Add(this.restart_button);
            this.groupBox1.Controls.Add(this.close_button);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 467);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "I\'m really sorry, but something crashed in the application.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ux_message);
            this.groupBox2.Location = new System.Drawing.Point(12, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 250);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "The gory details...";
            // 
            // ux_message
            // 
            this.ux_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_message.Location = new System.Drawing.Point(3, 18);
            this.ux_message.Multiline = true;
            this.ux_message.Name = "ux_message";
            this.ux_message.ReadOnly = true;
            this.ux_message.Size = new System.Drawing.Size(709, 229);
            this.ux_message.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "What would you like to do?";
            // 
            // ux_image
            // 
            this.ux_image.Location = new System.Drawing.Point(9, 13);
            this.ux_image.Margin = new System.Windows.Forms.Padding(4);
            this.ux_image.Name = "ux_image";
            this.ux_image.Size = new System.Drawing.Size(153, 105);
            this.ux_image.TabIndex = 8;
            this.ux_image.TabStop = false;
            // 
            // restart_button
            // 
            this.restart_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.restart_button.Location = new System.Drawing.Point(373, 126);
            this.restart_button.Margin = new System.Windows.Forms.Padding(4);
            this.restart_button.Name = "restart_button";
            this.restart_button.Size = new System.Drawing.Size(356, 78);
            this.restart_button.TabIndex = 3;
            this.restart_button.Text = "I want to &Restart the application";
            this.restart_button.UseVisualStyleBackColor = true;
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(9, 126);
            this.close_button.Margin = new System.Windows.Forms.Padding(4);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(356, 78);
            this.close_button.TabIndex = 2;
            this.close_button.Text = "&Ignore and continue";
            this.close_button.UseVisualStyleBackColor = true;
            // 
            // UnhandledErrorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(736, 467);
            this.Controls.Add(this.groupBox1);
            this.Name = "UnhandledErrorView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnhandledErrorView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ux_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button close_button;
        public System.Windows.Forms.Button restart_button;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox ux_image;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ux_message;
        private System.Windows.Forms.Label label1;
    }
}