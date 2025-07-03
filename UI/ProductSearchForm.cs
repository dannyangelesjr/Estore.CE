using System;
using System.ComponentModel;
using System.Windows.Forms;
using Estore.Ce.Infrastructure.Repositories;
using Estore.Ce.Models;
using Estore.Ce.Helpers;
using Estore.Ce.Contracts;

namespace Estore.Ce.UI
{
    public partial class ProductSearchForm : Form
    {
        #region Fields
        //-------------
        private IProductRepository _productRepository;
        #endregion

        #region Constructor
        //-----------------
        public ProductSearchForm()
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            InitializeServices();
            InitializeScanner();

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Form Events
        //-----------------
        private void ProductForm_Closing(object sender, CancelEventArgs e)
        {
            barcode1.EnableScanner = false;
        }
        #endregion

        #region Control Events
        //--------------------
        private void barcode1_OnRead(object sender, Symbol.Barcode.ReaderData readerData)
        {
            string currentScannedBarcode = BarcodeHelper.PadWithZerosAndDropCheckDigit(readerData);
            CheckBarcode(currentScannedBarcode);
        }

        private void txtBarcode_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtBarcode.Text != "")
            {
                CheckBarcode(this.txtBarcode.Text);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                barcode1.Reader.Actions.ToggleSoftTrigger();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Scan trigger failed: " + ex.Message, "Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region User Defined Functions
        //----------------------------
        private void InitializeScanner()
        {
            try
            {
                barcode1.EnableScanner = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Scanner enable failed: " + ex.Message);
            }
        }

        private void InitializeServices()
        {
            _productRepository = new ProductRepository();
        }

        private void CheckBarcode(string barcode)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Focus();

            Product product = null;
            try
            {
                this.txtBarcode.Text = barcode.PadLeft(18, '0');

                // check if barcode exists.
                product = _productRepository.GetByBarcode(barcode);
                if (product == null)
                {
                    MessageBox.Show("Barcode not found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                PopulateControls(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            Cursor.Current = Cursors.Default;
        }

        private void PopulateControls(Product product)
        {
            if (product == null)
            {
                this.txtBarcode.Text = "";
                this.BrandTextBox.Text = "";
                this.CategoryTextBox.Text = "";
                this.PackingQuantityTextBox.Text = "";
                this.ProductNameTextBox.Text = "";
                this.SellingPriceTextBox.Text = "";
            }
            else
            {
                this.txtBarcode.Text = product.Barcode;
                this.BrandTextBox.Text = product.Brand;
                this.CategoryTextBox.Text = product.Category;
                this.PackingQuantityTextBox.Text = product.PackingSize.ToString("N0") + ' ' + product.PackingUnit;
                this.ProductNameTextBox.Text = product.ProductName;
                this.SellingPriceTextBox.Text = product.SellingPrice.ToString("N2");
            }
        }
        #endregion
    }
}