namespace MyMoney.Presentation.Views.Shell {
    partial class window_shell
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
            this.ux_main_menu_strip = new System.Windows.Forms.MenuStrip();
            this.ux_status_bar = new System.Windows.Forms.StatusStrip();
            this.ux_dock_panel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.ux_tool_bar_strip = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // ux_main_menu_strip
            // 
            this.ux_main_menu_strip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ux_main_menu_strip.Location = new System.Drawing.Point(0, 0);
            this.ux_main_menu_strip.Name = "ux_main_menu_strip";
            this.ux_main_menu_strip.Size = new System.Drawing.Size(756, 24);
            this.ux_main_menu_strip.TabIndex = 0;
            this.ux_main_menu_strip.Text = "menuStrip1";
            // 
            // ux_status_bar
            // 
            this.ux_status_bar.Location = new System.Drawing.Point(0, 485);
            this.ux_status_bar.Name = "ux_status_bar";
            this.ux_status_bar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ux_status_bar.Size = new System.Drawing.Size(756, 22);
            this.ux_status_bar.TabIndex = 2;
            this.ux_status_bar.Text = "statusStrip1";
            // 
            // ux_dock_panel
            // 
            this.ux_dock_panel.ActiveAutoHideContent = null;
            this.ux_dock_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ux_dock_panel.BackColor = System.Drawing.Color.Transparent;
            this.ux_dock_panel.DockBackColor = System.Drawing.Color.Transparent;
            this.ux_dock_panel.DockBottomPortion = 150;
            this.ux_dock_panel.DockLeftPortion = 200;
            this.ux_dock_panel.DockRightPortion = 200;
            this.ux_dock_panel.DockTopPortion = 150;
            this.ux_dock_panel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.ux_dock_panel.Location = new System.Drawing.Point(0, 52);
            this.ux_dock_panel.Name = "ux_dock_panel";
            this.ux_dock_panel.RightToLeftLayout = true;
            this.ux_dock_panel.Size = new System.Drawing.Size(756, 433);
            this.ux_dock_panel.TabIndex = 3;
            // 
            // ux_tool_bar_strip
            // 
            this.ux_tool_bar_strip.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ux_tool_bar_strip.Location = new System.Drawing.Point(0, 24);
            this.ux_tool_bar_strip.Name = "ux_tool_bar_strip";
            this.ux_tool_bar_strip.Size = new System.Drawing.Size(756, 25);
            this.ux_tool_bar_strip.TabIndex = 6;
            this.ux_tool_bar_strip.Text = "toolStrip1";
            // 
            // window_shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 507);
            this.Controls.Add(this.ux_tool_bar_strip);
            this.Controls.Add(this.ux_dock_panel);
            this.Controls.Add(this.ux_status_bar);
            this.Controls.Add(this.ux_main_menu_strip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ux_main_menu_strip;
            this.Name = "window_shell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMoney";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ux_main_menu_strip;
        private System.Windows.Forms.StatusStrip ux_status_bar;
        private WeifenLuo.WinFormsUI.Docking.DockPanel ux_dock_panel;
        private System.Windows.Forms.ToolStrip ux_tool_bar_strip;
    }
}