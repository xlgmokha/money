namespace MoMoney.Presentation.Views.Shell
{
    partial class WelcomeScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ux_create_new_file_button = new System.Windows.Forms.Button();
            this.ux_open_existing_file_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ux_create_new_file_button
            // 
            this.ux_create_new_file_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ux_create_new_file_button.Enabled = false;
            this.ux_create_new_file_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ux_create_new_file_button.Location = new System.Drawing.Point(101, 97);
            this.ux_create_new_file_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ux_create_new_file_button.Name = "ux_create_new_file_button";
            this.ux_create_new_file_button.Size = new System.Drawing.Size(100, 28);
            this.ux_create_new_file_button.TabIndex = 0;
            this.ux_create_new_file_button.Text = "Create New File";
            this.ux_create_new_file_button.UseVisualStyleBackColor = true;
            // 
            // ux_open_existing_file_button
            // 
            this.ux_open_existing_file_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ux_open_existing_file_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ux_open_existing_file_button.Location = new System.Drawing.Point(101, 164);
            this.ux_open_existing_file_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ux_open_existing_file_button.Name = "ux_open_existing_file_button";
            this.ux_open_existing_file_button.Size = new System.Drawing.Size(100, 28);
            this.ux_open_existing_file_button.TabIndex = 1;
            this.ux_open_existing_file_button.Text = "Open Existing File";
            this.ux_open_existing_file_button.UseVisualStyleBackColor = true;
            // 
            // WelcomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(963, 609);
            this.Controls.Add(this.ux_open_existing_file_button);
            this.Controls.Add(this.ux_create_new_file_button);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WelcomeScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ux_create_new_file_button;
        private System.Windows.Forms.Button ux_open_existing_file_button;

    }
}