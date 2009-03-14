namespace MoMoney.Presentation.Views.dialogs
{
public    partial class SaveChangesView
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
            this.save_button = new System.Windows.Forms.Button();
            this.do_not_save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.ux_image = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ux_image)).BeginInit();
            this.SuspendLayout();
            // 
            // ux_save_button
            // 
            this.save_button.Location = new System.Drawing.Point(12, 100);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(267, 63);
            this.save_button.TabIndex = 0;
            this.save_button.Text = "&Save";
            this.save_button.UseVisualStyleBackColor = true;
            // 
            // ux_do_not_save_button
            // 
            this.do_not_save_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.do_not_save_button.Location = new System.Drawing.Point(13, 185);
            this.do_not_save_button.Name = "do_not_save_button";
            this.do_not_save_button.Size = new System.Drawing.Size(267, 63);
            this.do_not_save_button.TabIndex = 2;
            this.do_not_save_button.Text = "Do&n\'t Save";
            this.do_not_save_button.UseVisualStyleBackColor = true;
            // 
            // ux_cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancel_button.Location = new System.Drawing.Point(13, 254);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(267, 63);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            // 
            // ux_image
            // 
            this.ux_image.Location = new System.Drawing.Point(12, 12);
            this.ux_image.Name = "ux_image";
            this.ux_image.Size = new System.Drawing.Size(115, 85);
            this.ux_image.TabIndex = 4;
            this.ux_image.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "You have unsaved changes.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "What would you like to do?";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(11, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 2);
            this.label3.TabIndex = 8;
            this.label3.Text = "                                                                                 " +
                               "       ";
            // 
            // UnsavedChangesView
            // 
            this.AcceptButton = this.save_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(295, 327);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ux_image);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.do_not_save_button);
            this.Controls.Add(this.save_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnsavedChangesView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unsaved Changes";
            ((System.ComponentModel.ISupportInitialize)(this.ux_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    public System.Windows.Forms.Button save_button;
        public System.Windows.Forms.Button do_not_save_button;
        public System.Windows.Forms.Button cancel_button;
        public System.Windows.Forms.PictureBox ux_image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}