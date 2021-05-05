
namespace HeThongQuanLyXe
{
    partial class fDGVListServices
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
            this.dtgvListServices = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListServices)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvListServices
            // 
            this.dtgvListServices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(244)))));
            this.dtgvListServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvListServices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvListServices.Location = new System.Drawing.Point(0, 0);
            this.dtgvListServices.Name = "dtgvListServices";
            this.dtgvListServices.RowHeadersWidth = 49;
            this.dtgvListServices.RowTemplate.Height = 24;
            this.dtgvListServices.Size = new System.Drawing.Size(579, 270);
            this.dtgvListServices.TabIndex = 20;
            this.dtgvListServices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvListServices_CellClick);
            // 
            // fDGVListServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 270);
            this.Controls.Add(this.dtgvListServices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fDGVListServices";
            this.Text = "DGVListServices";
            this.Load += new System.EventHandler(this.fDGVListServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvListServices;
    }
}