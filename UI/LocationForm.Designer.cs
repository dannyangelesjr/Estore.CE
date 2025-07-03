namespace Estore.Ce.UI
{
    partial class LocationForm
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
            this.grdItems = new System.Windows.Forms.DataGrid();
            this.SuspendLayout();
            // 
            // grdItems
            // 
            this.grdItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.grdItems.BackgroundColor = System.Drawing.SystemColors.Info;
            this.grdItems.HeaderBackColor = System.Drawing.Color.ForestGreen;
            this.grdItems.HeaderForeColor = System.Drawing.Color.White;
            this.grdItems.Location = new System.Drawing.Point(3, 3);
            this.grdItems.Name = "grdItems";
            this.grdItems.SelectionBackColor = System.Drawing.Color.White;
            this.grdItems.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItems.Size = new System.Drawing.Size(312, 263);
            this.grdItems.TabIndex = 11;
            // 
            // LocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.grdItems);
            this.Name = "LocationForm";
            this.Text = "Locations";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid grdItems;
    }
}