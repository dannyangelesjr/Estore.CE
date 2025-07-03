namespace Estore.Ce.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuDeliveries = new System.Windows.Forms.MenuItem();
            this.menuDamaged = new System.Windows.Forms.MenuItem();
            this.menuCount = new System.Windows.Forms.MenuItem();
            this.menuRestock = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuProducts = new System.Windows.Forms.MenuItem();
            this.menuLocations = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuSync = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 245);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(318, 24);
            this.statusBar1.Text = "Welcome to JC Plaza Supermarket";
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuItem1);
            this.mainMenu.MenuItems.Add(this.menuItem3);
            this.mainMenu.MenuItems.Add(this.menuItem4);
            this.mainMenu.MenuItems.Add(this.menuItem9);
            this.mainMenu.MenuItems.Add(this.menuExit);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuDeliveries);
            this.menuItem1.MenuItems.Add(this.menuDamaged);
            this.menuItem1.MenuItems.Add(this.menuCount);
            this.menuItem1.MenuItems.Add(this.menuRestock);
            this.menuItem1.Text = "Inventory";
            // 
            // menuDeliveries
            // 
            this.menuDeliveries.Text = "Incoming Deliveries";
            this.menuDeliveries.Click += new System.EventHandler(this.menuDeliveries_Click);
            // 
            // menuDamaged
            // 
            this.menuDamaged.Text = "Damaged Items";
            this.menuDamaged.Click += new System.EventHandler(this.menuDamaged_Click);
            // 
            // menuCount
            // 
            this.menuCount.Text = "Physical Count";
            this.menuCount.Click += new System.EventHandler(this.menuCount_Click);
            // 
            // menuRestock
            // 
            this.menuRestock.Text = "Restock Selling Area";
            this.menuRestock.Click += new System.EventHandler(this.menuRestock_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.MenuItems.Add(this.menuProducts);
            this.menuItem3.MenuItems.Add(this.menuLocations);
            this.menuItem3.Text = "Search";
            // 
            // menuProducts
            // 
            this.menuProducts.Text = "Products";
            this.menuProducts.Click += new System.EventHandler(this.menuProducts_Click);
            // 
            // menuLocations
            // 
            this.menuLocations.Text = "Locations";
            this.menuLocations.Click += new System.EventHandler(this.menuLocations_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.MenuItems.Add(this.menuSync);
            this.menuItem4.Text = "Tools";
            // 
            // menuSync
            // 
            this.menuSync.Text = "Sync Tables";
            this.menuSync.Click += new System.EventHandler(this.menuSync_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.MenuItems.Add(this.menuItem10);
            this.menuItem9.MenuItems.Add(this.menuItem11);
            this.menuItem9.Text = "Settings";
            // 
            // menuItem10
            // 
            this.menuItem10.Text = "Configuration";
            // 
            // menuItem11
            // 
            this.menuItem11.Text = "Help";
            // 
            // menuExit
            // 
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuProducts;
        private System.Windows.Forms.MenuItem menuCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuSync;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuDeliveries;
        private System.Windows.Forms.MenuItem menuDamaged;
        private System.Windows.Forms.MenuItem menuRestock;
        private System.Windows.Forms.MenuItem menuLocations;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
    }
}