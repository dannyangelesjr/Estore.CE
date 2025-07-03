using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Estore.Ce.Services;
using Estore.Ce.LocationService;
using Estore.Ce.ProductService;
using Estore.Ce.Infrastructure.Repositories;
using Estore.Ce.Models;

namespace Estore.Ce.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuCount_Click(object sender, EventArgs e)
        {
            Form form = new PreStockCountForm();
            form.Show();            
        }

        private void menuDamaged_Click(object sender, EventArgs e)
        {
            Form form = new PreStockDamageForm();
            form.Show();
        }

        private void menuDeliveries_Click(object sender, EventArgs e)
        {
            Form form = new PreStockReceiptListForm();
            form.Show();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void menuLocations_Click(object sender, EventArgs e)
        {
            Form form = new LocationForm();
            form.Show();
        }        

        private void menuProducts_Click(object sender, EventArgs e)
        {
            Form form = new ProductSearchForm();
            form.Show();
        }

        private void menuRestock_Click(object sender, EventArgs e)
        {
            Form form = new PreStockReplenishmentForm();
            form.Show();
        }        

        private void menuSync_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new SynchronizeForm();
                form.Show();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }       
    }
}