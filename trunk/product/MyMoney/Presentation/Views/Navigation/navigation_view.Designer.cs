namespace MyMoney.Presentation.Views.Navigation
{
    partial class navigation_view
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
            this.uxNavigationTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // uxNavigationTreeView
            // 
            this.uxNavigationTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxNavigationTreeView.Location = new System.Drawing.Point(0, 0);
            this.uxNavigationTreeView.Name = "uxNavigationTreeView";
            this.uxNavigationTreeView.Size = new System.Drawing.Size(292, 273);
            this.uxNavigationTreeView.TabIndex = 0;
            // 
            // NavigationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.uxNavigationTreeView);
            this.Name = "NavigationView";
            this.TabText = "Action Items";
            this.Text = "Action Items";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView uxNavigationTreeView;
    }
}