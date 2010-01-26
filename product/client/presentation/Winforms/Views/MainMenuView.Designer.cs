namespace MoMoney.Presentation.Winforms.Views
{
    partial class MainMenuView
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
            this.ux_system_task_pane = new XPExplorerBar.TaskPane();
            ((System.ComponentModel.ISupportInitialize)(this.ux_system_task_pane)).BeginInit();
            this.SuspendLayout();
            // 
            // ux_system_task_pane
            // 
            this.ux_system_task_pane.AllowDrop = true;
            this.ux_system_task_pane.AutoScrollMargin = new System.Drawing.Size(12, 12);
            this.ux_system_task_pane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ux_system_task_pane.CausesValidation = false;
            this.ux_system_task_pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_system_task_pane.Location = new System.Drawing.Point(0, 0);
            this.ux_system_task_pane.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ux_system_task_pane.Name = "ux_system_task_pane";
            this.ux_system_task_pane.Size = new System.Drawing.Size(316, 914);
            this.ux_system_task_pane.TabIndex = 2;
            this.ux_system_task_pane.Text = "taskPane1";
            // 
            // MainMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 914);
            this.Controls.Add(this.ux_system_task_pane);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenuView";
            this.TabText = "actions_task_list";
            this.Text = "actions_task_list";
            ((System.ComponentModel.ISupportInitialize)(this.ux_system_task_pane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XPExplorerBar.TaskPane ux_system_task_pane;
    }
}