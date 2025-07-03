using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Estore.Ce.Helpers;
using Estore.Ce.Models;
using Estore.Ce.Services;
using Estore.Ce.Infrastructure.Repositories;
using Estore.Ce.PreStockReceiptService;
using System.Drawing;
using System.Data;

namespace Estore.Ce
{
    public partial class SupplierDeliveryForm : Form
    {
        #region Private Fields
        //-------------
        PreStockReceiptRepository _repository;
        ProductRepository _productRepository;
        IPreStockReceiptSoapService _soapService;

        List<PreStockReceipt> _preStockReceipts = new List<PreStockReceipt>();
        int _origQuantityDelivered;
        #endregion

        #region Constructor
        //-------------
        public SupplierDeliveryForm(string supplierInvoiceNumber)
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            InitializeServices();
            GetAllFromLocalDb(supplierInvoiceNumber);
            
            SetupForm(true);
            InitializeScanner();

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region form events
        //-------------
        private void SupplierDeliveryForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            barcode1.EnableScanner = false;
        }
        #endregion

        #region Control events
        //---------------
        private void barcode1_OnRead(object sender, Symbol.Barcode.ReaderData readerData)
        {
            Cursor.Current = Cursors.WaitCursor;
            Focus();

            string barcodeScanned = BarcodeHelper.PadWithZerosAndDropCheckDigit(readerData);

            try
            {
                // check if barcode already scanned
                PreStockReceipt item = FindInListByBarcode(barcodeScanned);
                if (item == null)
                {
                    // check if product is in Supplier Delivery
                    // Note: all items had been previously entered manually in tblForRrHd and tblForRrDt thus no new item can be added here
                    Product product = GetProduct(barcodeScanned);
                    if (product == null)
                    {
                        MessageBox.Show("Barcode not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return;
                    }            

                    item = FindInListByProductId(product.ProductId);
                    if (item == null)
                    {
                        MessageBox.Show("Item not in PO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                if (item != null)
                {
                    item.Quantity++;
                    item = ItemUpdateAndUpdateList(item);

                    SaveItem(item);
                    PopulateControls(item);

                    txtQuantityDelivered.Focus();
                    txtQuantityDelivered.Text = item.Quantity.ToString();

                    tabControl1.Focus();
                    item.Quantity = Convert.ToInt32(txtQuantityDelivered.Text); // update the value in case there was a validation error

                }                
            }
            catch (Exception)
            {
                throw;
            }

            Cursor.Current = Cursors.Default;
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
                throw ex;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_preStockReceipts.Count() == 0)
            {
                MessageBox.Show("Nothing to submit", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            if (MessageBox.Show("Proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Submission aborted", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!NetworkHelper.IsConnectedToServer())
            {
                MessageBox.Show("No connection. Submission aborted", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            SetupForm(false);
            Cursor.Current = Cursors.WaitCursor;

            List<CreatePreStockReceiptCommandRequestDto> dtos = new List<CreatePreStockReceiptCommandRequestDto>();

            try
            {
                foreach (PreStockReceipt row in _preStockReceipts)
                {
                    dtos.Add(ObjectMapper.MapTo<PreStockReceipt, CreatePreStockReceiptCommandRequestDto>(row));
                }
                ApiResponse response = _soapService.Post(dtos.ToArray());
                if (response.IsSuccess == true)
                {
                    foreach (PreStockReceipt item in _preStockReceipts)
                    {
                        _repository.DeleteById(item.Id);
                    }
                    MessageBox.Show("Submission successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);                    
                }
                else
                {
                    MessageBox.Show("Submission failed. Check wifi.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                Cursor.Current = Cursors.WaitCursor;
                Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void grdItems_Click(object sender, EventArgs e)
        {
            if (grdItems.CurrentRowIndex >= 0)
            {
                ((DataGrid)sender).Select(((DataGrid)sender).CurrentRowIndex);
                PreStockReceipt item = _preStockReceipts[((DataGrid)sender).CurrentRowIndex];
                PopulateControls(item);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.Focus();
            if (tabControl1.SelectedIndex == 1)
            {
                barcode1.EnableScanner = false;
                if (_preStockReceipts.Count() > 0)
                {
                    PopulateDataGrid();
                    if (grdItems.CurrentRowIndex >= 0)
                    {
                        txtProductName2.Text = grdItems[grdItems.CurrentRowIndex, 4].ToString();
                    }
                }

                int i = 0;
                decimal totalCases = 0;
                decimal totalPieces = 0;
                foreach (PreStockReceipt record in _preStockReceipts)
                {
                    totalCases += record.PackingUnit == "CASE" ? record.Quantity : 0;
                    totalPieces += record.PackingUnit == "PIECE" ? record.Quantity : 0;
                    if (txtProductId.Text != "" && record.ProductId == Convert.ToInt32(txtProductId.Text))
                    {
                        grdItems.Select(i);
                        grdItems.CurrentRowIndex = i;                        
                    }
                    i++;
                }

                txtProductName2.Text = grdItems[grdItems.CurrentRowIndex, 5].ToString();

                txtTotalCases.Text = totalCases.ToString("N0");
                txtTotalPieces.Text = totalPieces.ToString("N0");
            }
            else
            {
                if (grdItems.CurrentRowIndex >= 0)
                {
                    int lineNumber = Convert.ToInt32(grdItems[grdItems.CurrentRowIndex, 0]);
                    PreStockReceipt item = _preStockReceipts.Where(t => t.LineNumber == lineNumber).FirstOrDefault();
                    PopulateControls(item);
                    SetupForm(true);
                }
                barcode1.EnableScanner = true;
            }
        }

        private void txtQuantityDelivered_GotFocus(object sender, EventArgs e)
        {
            txtQuantityDelivered.SelectAll();
        }

        private void txtQuantityDelivered_Validated(object sender, EventArgs e)
        {
            if (txtBarcode.Text != null)
            {
                PreStockReceipt item = _preStockReceipts.Find(i => i.ProductId == Convert.ToInt32(txtProductId.Text));
                if (item != null) 
                {
                    item.Quantity = Convert.ToInt32(txtQuantityDelivered.Text);
                    _repository.InsertUpdate(item);
                }
            }
        }

        private void txtQuantityDelivered_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal quantity = Convert.ToInt32(txtQuantityDelivered.Text);
            decimal poQuantity = Convert.ToInt32(txtQuantityOnOrder.Text);
            e.Cancel = !IsQuantityValid(quantity, poQuantity);
            if (e.Cancel)
            {
                txtQuantityDelivered.Text = _origQuantityDelivered.ToString();
            }
        }
        #endregion

        #region user defined functions
        //------------------------
        private PreStockReceipt FindInListByBarcode(string barcode)
        {
            PreStockReceipt detail = _preStockReceipts.Where(b => b.Barcode == barcode).FirstOrDefault();
            return detail;
        }

        private PreStockReceipt FindInListByProductId(int productId)
        {
            PreStockReceipt detail = _preStockReceipts.Where(b => b.ProductId == productId).FirstOrDefault();
            return detail;
        }

        private void GetAllFromLocalDb(string supplierInvoiceNumber)
        {
            _preStockReceipts = _repository.GetBySupplierInvoiceNumber(supplierInvoiceNumber);
        }

        private Product GetProduct(string barcode)
        {
            // check if barcode exists. Error if non existent
            Product product = _productRepository.GetByBarcode(barcode);
            if (product == null)
            {
                MessageBox.Show("Barcode not found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else if (product != null && product.PackingUnit != "CASE" && product.ProductParentId != null)
            {
                if (MessageBox.Show("Use per case", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Product productParent = _productRepository.GetById((int)product.ProductParentId);
                    product = productParent != null ? productParent : product;
                }
            }
            return product;
        }

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
            _repository = new PreStockReceiptRepository();
            _soapService = new IPreStockReceiptSoapService();
        }

        private bool IsQuantityValid(decimal quantity, decimal poQuantity)
        {
            bool isError = false;
            if (quantity < 0)
            {
                MessageBox.Show("Negative value not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                isError = true;
            }
            else if (quantity > poQuantity)
            {
                MessageBox.Show("Quantity exceeds PO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                isError = true;
            }
            return !isError;
        }

        private PreStockReceipt ItemUpdateAndUpdateList(PreStockReceipt item)
        {
            _origQuantityDelivered = item.Quantity;

            item.ScanDate = DateTime.Now;

            // update list
            PreStockReceipt row = FindInListByBarcode(item.Barcode);
            row.Quantity = item.Quantity;
            row.ScanDate = item.ScanDate;

            return item;
        }

        private void PopulateControls(PreStockReceipt row)
        {
            if (row == null)
            {
                txtSupplierInvoice.Text = "";
                txtPurchaseOrderNumber.Text = "";
                txtSupplierName.Text = "";

                txtBarcode.Text = "";
                txtProductId.Text = "";
                txtProductName.Text = "";
                txtProductName2.Text = "";
                txtQuantityDelivered.Text = "";
                txtQuantityOnOrder.Text = "";
            }
            else
            {
                txtSupplierInvoice.Text = row.SupplierInvoiceNumber;
                txtPurchaseOrderNumber.Text = row.PurchaseOrderNumber.ToString();
                txtSupplierName.Text = row.SupplierName;

                txtBarcode.Text = row.Barcode == null ? "" : row.Barcode;
                txtProductId.Text = row.ProductId.ToString();
                txtProductName.Text = row.ProductName;
                txtProductName2.Text = row.ProductName;
                txtQuantityDelivered.Text = row.Quantity.ToString("N0");
                txtQuantityOnOrder.Text = row.QuantityOnOrder.ToString("N0");
            }
        }

        private void PopulateDataGrid()
        {
            DataTable table = new DataTable();
            table.Columns.Add("LineNumber", typeof(int));
            table.Columns.Add("Barcode", typeof(string));
            table.Columns.Add("PackingUnit", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("QuantityOnOrder", typeof(int));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("ProductId", typeof(int));

            foreach (PreStockReceipt item in _preStockReceipts)
            {
                table.Rows.Add(item.LineNumber, item.Barcode, item.PackingUnit, item.Quantity, item.ProductName, item.ProductId);
            }

            grdItems.DataSource = table;
            
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = table.TableName; // If blank, use ""

            // Add columns in the order you want them to appear
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "LineNumber", HeaderText = "#", Width = 20 });
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Barcode", HeaderText = "Barcode", Width = 150 });
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "PackingUnit", HeaderText = "UOM", Width = 46 });
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Quantity", HeaderText = "Qty", Width = 30 });

            // Hide unwanted columns by setting width to 0 or not adding them at all
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "QuantityOnOrder", Width = 0 });
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ProductName", Width = 0 });
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ProductId", Width = 0 });

            grdItems.TableStyles.Clear();
            grdItems.TableStyles.Add(ts);

            grdItems.Select(grdItems.CurrentRowIndex);
        }

        private void SaveItem(PreStockReceipt item)
        {
            if (item == null)
            {
                MessageBox.Show("No data to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            item = _repository.InsertUpdate(item);
            if (item != null)
            {
                MessageBox.Show("Save unsuccessful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void SetupForm(bool isEnabled)
        {
            barcode1.EnableScanner = isEnabled;

            txtBarcode.Enabled = false;
            txtProductName.Enabled = false;
            txtProductName2.Enabled = false;
            txtQuantityOnOrder.Enabled = false;
            txtQuantityDelivered.Enabled = txtBarcode.Text != "" && isEnabled;
        }
        #endregion                                
    }
}