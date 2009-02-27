namespace MyMoney.Presentation.Views.updates
{
    partial class check_for_updates
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
            this.label1 = new System.Windows.Forms.Label();
            this.ux_image = new System.Windows.Forms.PictureBox();
            this.ux_cancel_button = new System.Windows.Forms.Button();
            this.ux_dont_update_button = new System.Windows.Forms.Button();
            this.ux_update_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ux_image)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(12, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 2);
            this.label3.TabIndex = 15;
            this.label3.Text = "                                                                                 " +
                "       ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "What would you like to do?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "You have unsaved changes.";
            // 
            // ux_image
            // 
            this.ux_image.Location = new System.Drawing.Point(13, 13);
            this.ux_image.Margin = new System.Windows.Forms.Padding(4);
            this.ux_image.Name = "ux_image";
            this.ux_image.Size = new System.Drawing.Size(153, 105);
            this.ux_image.TabIndex = 12;
            this.ux_image.TabStop = false;
            // 
            // ux_cancel_button
            // 
            this.ux_cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ux_cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ux_cancel_button.Location = new System.Drawing.Point(14, 311);
            this.ux_cancel_button.Margin = new System.Windows.Forms.Padding(4);
            this.ux_cancel_button.Name = "ux_cancel_button";
            this.ux_cancel_button.Size = new System.Drawing.Size(356, 78);
            this.ux_cancel_button.TabIndex = 11;
            this.ux_cancel_button.Text = "Cancel";
            this.ux_cancel_button.UseVisualStyleBackColor = true;
            // 
            // ux_dont_update_button
            // 
            this.ux_dont_update_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ux_dont_update_button.Location = new System.Drawing.Point(14, 226);
            this.ux_dont_update_button.Margin = new System.Windows.Forms.Padding(4);
            this.ux_dont_update_button.Name = "ux_dont_update_button";
            this.ux_dont_update_button.Size = new System.Drawing.Size(356, 78);
            this.ux_dont_update_button.TabIndex = 10;
            this.ux_dont_update_button.Text = "Do&n\'t Update";
            this.ux_dont_update_button.UseVisualStyleBackColor = true;
            // 
            // ux_update_button
            // 
            this.ux_update_button.Enabled = false;
            this.ux_update_button.Location = new System.Drawing.Point(13, 121);
            this.ux_update_button.Margin = new System.Windows.Forms.Padding(4);
            this.ux_update_button.Name = "ux_update_button";
            this.ux_update_button.Size = new System.Drawing.Size(356, 78);
            this.ux_update_button.TabIndex = 9;
            this.ux_update_button.Text = "&Update";
            this.ux_update_button.UseVisualStyleBackColor = true;
            // 
            // check_for_updatescs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 403);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ux_image);
            this.Controls.Add(this.ux_cancel_button);
            this.Controls.Add(this.ux_dont_update_button);
            this.Controls.Add(this.ux_update_button);
            this.Name = "check_for_updatescs";
            this.Text = "check_for_updatescs";
            ((System.ComponentModel.ISupportInitialize)(this.ux_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ux_image;
        private System.Windows.Forms.Button ux_cancel_button;
        private System.Windows.Forms.Button ux_dont_update_button;
        private System.Windows.Forms.Button ux_update_button;

    }
}