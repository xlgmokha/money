namespace MoMoney.Presentation.Winforms.Views
{
    partial class CheckForUpdatesView
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ux_current_version = new System.Windows.Forms.Label();
            this.ux_image = new System.Windows.Forms.PictureBox();
            this.ux_cancel_button = new System.Windows.Forms.Button();
            this.ux_dont_update_button = new System.Windows.Forms.Button();
            this.ux_update_button = new System.Windows.Forms.Button();
            this.ux_new_version = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ux_image)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(9, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 2);
            this.label3.TabIndex = 15;
            this.label3.Text = "                                                                                 " +
                "       ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "What would you like to do?";
            // 
            // ux_current_version
            // 
            this.ux_current_version.AutoSize = true;
            this.ux_current_version.Location = new System.Drawing.Point(134, 11);
            this.ux_current_version.Name = "ux_current_version";
            this.ux_current_version.Size = new System.Drawing.Size(44, 13);
            this.ux_current_version.TabIndex = 13;
            this.ux_current_version.Text = "Current:";
            // 
            // ux_image
            // 
            this.ux_image.Location = new System.Drawing.Point(10, 11);
            this.ux_image.Name = "ux_image";
            this.ux_image.Size = new System.Drawing.Size(115, 85);
            this.ux_image.TabIndex = 12;
            this.ux_image.TabStop = false;
            // 
            // ux_cancel_button
            // 
            this.ux_cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ux_cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ux_cancel_button.Location = new System.Drawing.Point(10, 253);
            this.ux_cancel_button.Name = "ux_cancel_button";
            this.ux_cancel_button.Size = new System.Drawing.Size(267, 63);
            this.ux_cancel_button.TabIndex = 11;
            this.ux_cancel_button.Text = "Cancel";
            this.ux_cancel_button.UseVisualStyleBackColor = true;
            // 
            // ux_dont_update_button
            // 
            this.ux_dont_update_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ux_dont_update_button.Location = new System.Drawing.Point(10, 184);
            this.ux_dont_update_button.Name = "ux_dont_update_button";
            this.ux_dont_update_button.Size = new System.Drawing.Size(267, 63);
            this.ux_dont_update_button.TabIndex = 10;
            this.ux_dont_update_button.Text = "Do&n\'t Update";
            this.ux_dont_update_button.UseVisualStyleBackColor = true;
            // 
            // ux_update_button
            // 
            this.ux_update_button.Enabled = false;
            this.ux_update_button.Location = new System.Drawing.Point(10, 98);
            this.ux_update_button.Name = "ux_update_button";
            this.ux_update_button.Size = new System.Drawing.Size(267, 63);
            this.ux_update_button.TabIndex = 9;
            this.ux_update_button.Text = "&Update";
            this.ux_update_button.UseVisualStyleBackColor = true;
            // 
            // ux_new_version
            // 
            this.ux_new_version.AutoSize = true;
            this.ux_new_version.Location = new System.Drawing.Point(136, 40);
            this.ux_new_version.Name = "ux_new_version";
            this.ux_new_version.Size = new System.Drawing.Size(32, 13);
            this.ux_new_version.TabIndex = 16;
            this.ux_new_version.Text = "New:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "to";
            // 
            // CheckForUpdatesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ux_cancel_button;
            this.ClientSize = new System.Drawing.Size(291, 327);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ux_new_version);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ux_current_version);
            this.Controls.Add(this.ux_image);
            this.Controls.Add(this.ux_cancel_button);
            this.Controls.Add(this.ux_dont_update_button);
            this.Controls.Add(this.ux_update_button);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckForUpdatesView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoMoney - Check For Updates";
            ((System.ComponentModel.ISupportInitialize)(this.ux_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ux_current_version;
        private System.Windows.Forms.PictureBox ux_image;
        private System.Windows.Forms.Button ux_cancel_button;
        private System.Windows.Forms.Button ux_dont_update_button;
        private System.Windows.Forms.Button ux_update_button;
        private System.Windows.Forms.Label ux_new_version;
        private System.Windows.Forms.Label label5;

    }
}