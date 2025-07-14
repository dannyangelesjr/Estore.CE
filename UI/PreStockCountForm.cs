using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Estore.Ce.Contracts;
using Estore.Ce.Helpers;
using Estore.Ce.Infrastructure.Repositories;
using Estore.Ce.Models;
using Estore.Ce.PreStockCountService;

namespace Estore.Ce.UI
{
    public partial class PreStockCountForm : Form
    {
        #region Private Fields
        ILocationRepository _locationRepository;
        IProductRepository _productRepository;
        IPreStockCountRepository _repository;
        IPreStockCountSoapService _soapService;

        List<PreStockCount> _preStockCounts = new List<PreStockCount>();
        List<Location> _locations = new List<Location>();
        #endregion

        #region Constructor
        public PreStockCountForm()
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            InitializeServices();
            GetAllFromLocalDb();
            PopulateLocationCombo();

            bool isEnable = _preStockCounts.Count() > 0;
            SetupForm(isEnable);
            barcode1.EnableScanner = isEnable;

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Form Events
        private void PreStockCountForm_Closing(object sender, CancelEventArgs e)
        {
            barcode1.EnableScanner = false;
        }
        #endregion

        #region Control Events
        private void barcode1_OnRead(object sender, Symbol.Barcode.ReaderData readerData)
        {
            Cursor.Current = Cursors.WaitCursor;
            Focus();

            string barcodeScanned = BarcodeHelper.PadWithZerosAndDropCheckDigit(readerData);

            try
            {
                // check if barcode already scanned
                PreStockCount item = FindInListByBarcode(barcodeScanned);
                if (item == null)
                {
                    // if item not yet scanned then add to list (if valid)
                    item = ItemCreateAndAddToList(barcodeScanned);
                }
                else
                {
                    item.Quantity++;
                    item.ScanDate = DateTime.Now;
                }

                if (item != null)
                {
                    item = SaveItem(item);
                    item = ItemUpdateAndUpdateList(item);
                    PopulateControls(item);
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
            if (_preStockCounts.Count() == 0)
            {
                MessageBox.Show("Nothing to submit", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            if (MessageBox.Show("Proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Submission aborted", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!@NetworkHelper.IsConnectedToServer())
            {
                MessageBox.Show("No connection. Submission aborted", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            SetupForm(false);
            Cursor.Current = Cursors.WaitCursor;

            List<PreStockCountDto> dtos = new List<PreStockCountDto>();

            try
            {
                foreach (PreStockCount row in _preStockCounts)
                {
                    dtos.Add(ObjectMapper.MapTo<PreStockCount, PreStockCountDto>(row));
                }
                ApiResponse response = _soapService.Post(dtos.ToArray());
                if (response.IsSuccess == true)
                {
                    _repository.DeleteAll();
                    MessageBox.Show("Submission successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Submission failed. Check wifi.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                Cursor.Current = Cursors.Default;
                Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void cmbLocation_Validated(object sender, EventArgs e)
        {
            cmbLocation.Enabled = cmbLocation.SelectedValue.ToString() != "";
            SetupForm(cmbLocation.SelectedValue.ToString() != "");
            barcode1.EnableScanner = Convert.ToInt32(cmbLocation.SelectedValue.ToString()) > 0 && tabControl1.SelectedIndex == 0;
        }

        private void grdItems_Click(object sender, EventArgs e)
        {
            if (grdItems.CurrentRowIndex >= 0)
            {
                ((DataGrid)sender).Select(((DataGrid)sender).CurrentRowIndex);
                PreStockCount item = _preStockCounts[((DataGrid)sender).CurrentRowIndex];
                PopulateControls(item);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.Focus();
            if (tabControl1.SelectedIndex == 1)
            {
                barcode1.EnableScanner = false;
                if (_preStockCounts.Count() > 0)
                {
                    PopulateDataGrid();
                    if (grdItems.CurrentRowIndex >= 0)
                    {
                        txtProductName2.Text = grdItems[grdItems.CurrentRowIndex, 4].ToString();
                    }
                }
            }
            else
            {
                if (grdItems.CurrentRowIndex >= 0)
                {
                    int lineNumber = Convert.ToInt32(grdItems[grdItems.CurrentRowIndex, 0]);
                    PreStockCount item = _preStockCounts.Where(t => t.LineNumber == lineNumber).FirstOrDefault();
                    PopulateControls(item);
                    SetupForm(true);
                }
                barcode1.EnableScanner = Convert.ToInt32(cmbLocation.SelectedValue.ToString()) > 0;
            }
        }

        private void txtQuantity_GotFocus(object sender, EventArgs e)
        {
            txtQuantity.SelectAll();
        }

        private void txtBarcode_Validated(object sender, EventArgs e)
        {
            PreStockCount item = FindInListByBarcode(grdItems[grdItems.CurrentRowIndex, 1].ToString());
            if (item != null)
            {
                item.Quantity = Convert.ToInt32(((TextBox)sender).Text);
                _repository.InsertUpdate(item);
            }
        }

        private void txtQuantity_Validated(object sender, EventArgs e)
        {
            if (txtBarcode.Text != null)
            {
                PreStockCount item = FindInListByBarcode(txtBarcode.Text);
                if (item != null)
                {
                    item.Quantity = Convert.ToInt32(txtQuantity.Text);

                    item = SaveItem(item);
                    item = ItemUpdateAndUpdateList(item);
                }
            }
        }
        #endregion

        #region Private Methods
        private PreStockCount FindInListByBarcode(string barcode)
        {
            PreStockCount detail = _preStockCounts.Where(b => b.Barcode == barcode).FirstOrDefault();
            return detail;
        }

        private void GetAllFromLocalDb()
        {
            try
            {
                _preStockCounts = _repository.GetAll().ToList();
                _locations = _locationRepository.GetAll().ToList();
                if (_locations.Count == 0)
                {
                    string message = "Location table is empty";
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Cannot proceed", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private Product GetProduct(string barcode)
        {
            Product product = _productRepository.GetByBarcode(barcode);
            if (product == null)
            {
                MessageBox.Show("Barcode not found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else if (product.PackingUnit != "CASE" && product.ProductParentId != null)
            {
                if (MessageBox.Show("Use per case", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Product productParent = _productRepository.GetByProductId((int)product.ProductParentId);
                    product = productParent != null ? productParent : product;
                }
            }
            return product;
        }

        private List<PreStockCount> GetPreStockCounts()
        {
            return _repository.GetAll().ToList();
        }

        private void InitializeServices()
        {
            _locationRepository = new LocationRepository();
            _productRepository = new ProductRepository();
            _repository = new PreStockCountRepository();
            _soapService = new IPreStockCountSoapService();
        }

        private PreStockCount ItemCreateAndAddToList(string barcode)
        {
            if (barcode == null)
            {
                return null;
            }

            Product product = GetProduct(barcode);
            if (product==null || product.Barcode == null)
            {
                return null;
            }

            PreStockCount item = new PreStockCount
            {
                Barcode = product.Barcode,
                DeviceId = DeviceHelper.GetDeviceId(),
                LineNumber = _preStockCounts.Count() + 1,
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue.ToString()),
                PackingUnit = product.PackingUnit,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Quantity = 1,
                ScanDate = DateTime.Now
            };

            _preStockCounts.Add(item);

            return item;
        }

        private PreStockCount ItemUpdateAndUpdateList(PreStockCount item)
        {
            // update list
            foreach (PreStockCount row in _preStockCounts)
            {
                if (row.Barcode == item.Barcode)
                {
                    row.Id = item.Id;
                    row.Quantity = item.Quantity;
                    row.ScanDate = item.ScanDate;

                    break;
                }
            }
            return item;
        }

        private void PopulateControls(PreStockCount row)
        {
            if (row == null)
            {
                txtBarcode.Text = "";
                txtPackingUnit.Text = "";
                txtProductName.Text = "";
                txtProductName2.Text = "";
                txtQuantity.Text = "";
            }
            else
            {
                txtBarcode.Text = row.Barcode;
                txtPackingUnit.Text = row.PackingUnit;
                txtProductName.Text = row.ProductName;
                txtProductName2.Text = row.ProductName;
                txtQuantity.Text = row.Quantity.ToString("N0");
            }
        }

        private void PopulateDataGrid()
        {
            DataTable table = new DataTable();
            table.Columns.Add("LineNumber", typeof(int));
            table.Columns.Add("Barcode", typeof(string));
            table.Columns.Add("PackingUnit", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("ProductId", typeof(int));

            foreach (PreStockCount item in _preStockCounts)
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
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ProductName", Width = 0 });
            ts.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ProductId", Width = 0 });

            grdItems.TableStyles.Clear();
            grdItems.TableStyles.Add(ts);

            grdItems.Select(grdItems.CurrentRowIndex);
        }

        private void PopulateLocationCombo()
        {
            int locationId;
            if (_preStockCounts.Count() > 0)
            {
                locationId = _preStockCounts.FirstOrDefault().LocationId;
            }
            else
            {
                locationId = 0;
            }

            Location location = new Location()
            {
                LocationId = 0,
                LocationName = ""
            };
            _locations.Add(location);

            cmbLocation.DataSource = _locations;
            cmbLocation.DisplayMember = "LocationName";
            cmbLocation.ValueMember = "LocationId";
            if (_locations.Count() > 0)
            {
                if (locationId > 0)
                {
                    cmbLocation.SelectedItem = _locations.Where(x => x.Id == locationId).FirstOrDefault();
                }
                else
                {
                    cmbLocation.SelectedItem = _locations.LastOrDefault();
                }
            }
        }

        private PreStockCount SaveItem(PreStockCount item)
        {
            if (item == null)
            {
                MessageBox.Show("No data to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return null;
            }

            item = _repository.InsertUpdate(item);
            if (item.Id == 0)
            {
                MessageBox.Show("Save unsuccessful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return null;
            }

            return item;
        }

        private void SetupForm(bool isEnabled)
        {
            cmbLocation.Enabled = _preStockCounts.Count() == 0;

            txtBarcode.Enabled = false;
            txtPackingUnit.Enabled = false;
            txtProductName.Enabled = false;
            txtProductName2.Enabled = false;
            txtQuantity.Enabled = txtBarcode.Text != "" && isEnabled;
        }
        #endregion
    }
}
