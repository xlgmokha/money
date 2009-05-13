namespace MoMoney.Presentation.Views.income
{
    partial class ViewAllIncome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAllIncome));
            this.ux_view_all_income = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ux_view_all_income)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ux_view_all_income
            // 
            this.ux_view_all_income.AllowUserToAddRows = false;
            this.ux_view_all_income.AllowUserToDeleteRows = false;
            this.ux_view_all_income.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ux_view_all_income.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ux_view_all_income.Location = new System.Drawing.Point(0, 0);
            this.ux_view_all_income.Name = "ux_view_all_income";
            this.ux_view_all_income.ReadOnly = true;
            this.ux_view_all_income.Size = new System.Drawing.Size(699, 712);
            this.ux_view_all_income.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.ux_view_all_income.TabIndex = 0;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.ux_view_all_income);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(701, 762);
            this.kryptonHeaderGroup1.TabIndex = 1;
            this.kryptonHeaderGroup1.Text = "View All Income";
            this.kryptonHeaderGroup1.ValuesPrimary.Description = "";
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "View All Income";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeaderGroup1.ValuesPrimary.Image")));
            this.kryptonHeaderGroup1.ValuesSecondary.Description = "";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Description";
            this.kryptonHeaderGroup1.ValuesSecondary.Image = null;
            // 
            // view_all_income
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 762);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "view_all_income";
            this.TabText = "view_all_income";
            this.Text = "view_all_income";
            ((System.ComponentModel.ISupportInitialize)(this.ux_view_all_income)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView ux_view_all_income;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
    }
}