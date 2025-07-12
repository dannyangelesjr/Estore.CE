using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Estore.Ce.Contracts;
using Estore.Ce.Helpers;
using Estore.Ce.Infrastructure.Repositories;
using Estore.Ce.Models;
using Estore.Ce.PreStockReplenishmentService;
using System.Data;

namespace Estore.Ce.UI
{
    public partial class PreStockReplenishmentForm : Form
    {
        #region Fields
        ILocationRepository _locationRepository;
        IProductRepository _productRepository;
        PreStockReplenishmentRepository _repository;
        IPreStockReplenishmentSoapService _soapService;

        List<PreStockReplenishment> _preStockReplenishments;
        List<Location> _locationsFrom = new List<Location>();
        List<Location> _locationsTo = new List<Location>();
        #endregion        

        #region Constructor
        public PreStockReplenishmentForm()
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            InitializeServices();
            GetAllFromLocalDb();

            PopulateLocationCombo();
            SetupForm(false);

            barcode1.EnableScanner = true;

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Form Events
        private void RestockForm_Closing(object sender, CancelEventArgs e)
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
                PreStockReplenishment item = FindInListByBarcode(barcodeScanned);
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
            if (_preStockReplenishments.Count() == 0)
            {
                MessageBox.Show("Nothing to submit", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            if (MessageBox.Show("Proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Submission aborted", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                if (!NetworkHelper.IsConnectedToServer())
                {
                    MessageBox.Show("No connection. Submission aborted", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }

            SetupForm(false);
            Cursor.Current = Cursors.WaitCursor;

            List<PreStockReplenishmentDto> dtos = new List<PreStockReplenishmentDto>();

            try
            {
                foreach (PreStockReplenishment row in _preStockReplenishments)
                {
                    dtos.Add(ObjectMapper.MapTo<PreStockReplenishment, PreStockReplenishmentDto>(row));
                }
                ApiResponse response = _soapService.Post(dtos.ToArray());
                if (response.IsSuccess == true)
                {
                    foreach (PreStockReplenishment item in _preStockReplenishments)
                    {
                        _repository.DeleteById(item.Id);
                    }
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

        private void grdItems_Click(object sender, EventArgs e)
        {
            if (grdItems.CurrentRowIndex >= 0)
            {
                ((DataGrid)sender).Select(((DataGrid)sender).CurrentRowIndex);
                PreStockReplenishment item = _preStockReplenishments[((DataGrid)sender).CurrentRowIndex];
                PopulateControls(item);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.Focus();
            if (tabControl1.SelectedIndex == 1)
            {
                barcode1.EnableScanner = false;
                if (_preStockReplenishments.Count() > 0)
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
                    PreStockReplenishment item = _preStockReplenishments.Where(t => t.LineNumber == lineNumber).FirstOrDefault();
                    PopulateControls(item);
                    SetupForm(true);
                }
                barcode1.EnableScanner = true;
            }
        }

        private void txtQuantity_GotFocus(object sender, EventArgs e)
        {
            txtQuantity.SelectAll();
        }        

        private void txtQuantity_Validated(object sender, EventArgs e)
        {
            if (txtBarcode.Text != null)
            {
                // Update only if quantity was changed
                PreStockReplenishment item = FindInListByBarcode(txtBarcode.Text);
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
        private PreStockReplenishment FindInListByBarcode(string barcode)
        {
            PreStockReplenishment detail = _preStockReplenishments.Where(b => b.Barcode == barcode).FirstOrDefault();
            return detail;
        }

        private void GetAllFromLocalDb()
        {
            try
            {
                _preStockReplenishments = _repository.GetAll().ToList();

                Location locationFrom = _locationRepository.GetByLocationType(LocationType.Warehouse);
                Location locationTo = _locationRepository.GetByLocationType(LocationType.SellingArea);

                if (locationFrom != null && locationTo != null)
                {
                    _locationsFrom.Add(locationFrom);
                    _locationsTo.Add(locationTo);
                }
                else
                {
                    string message = "Missing location";
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
            // check if barcode exists. Error if non existent
            Product product = _productRepository.GetByBarcode(barcode);
            if (product == null)
            {
                MessageBox.Show("Barcode not found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            return product;
        }

        private void InitializeServices()
        {
            _locationRepository = new LocationRepository();
            _productRepository = new ProductRepository();
            _repository = new PreStockReplenishmentRepository();
            _soapService = new IPreStockReplenishmentSoapService();
        }

        private PreStockReplenishment ItemCreateAndAddToList(string barcode)
        {
            if (barcode == null)
            {
                return null;
            }

            Product product = GetProduct(barcode);
            if (product == null)
            {
                return null;
            }

            PreStockReplenishment item = new PreStockReplenishment
            {
                Barcode = product.Barcode,
                DeviceId = DeviceHelper.GetDeviceId(),
                LineNumber = _preStockReplenishments.Count() + 1,
                LocationFromId = Convert.ToInt32(cmbLocationFrom.SelectedValue.ToString()),
                LocationToId = Convert.ToInt32(cmbLocationTo.SelectedValue.ToString()),
                PackingUnit = product.PackingUnit,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Quantity = 1,
                ScanDate = DateTime.Now
            };

            _preStockReplenishments.Add(item);

            return item;
        }

        private PreStockReplenishment ItemUpdateAndUpdateList(PreStockReplenishment item)
        {
            // update list
            foreach (PreStockReplenishment row in _preStockReplenishments)
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

        private void PopulateControls(PreStockReplenishment row)
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

            foreach (PreStockReplenishment item in _preStockReplenishments)
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
            // Note: Exception already thown at GetAllFromLocalDb if location table has no data
            // so location will never be null
            // have to add manually so that combobox only contains specific location
            Location locationFrom = _locationsFrom.FirstOrDefault();
            Location locationTo = _locationsTo.FirstOrDefault();

            List<Location> locationsFrom = new List<Location>();
            locationsFrom.Add(new Location()
            {
                LocationId = locationFrom.LocationId,
                LocationName = locationFrom.LocationName
            });
            cmbLocationFrom.DataSource = locationsFrom;
            cmbLocationFrom.DisplayMember = "LocationName";
            cmbLocationFrom.ValueMember = "LocationId";

            List<Location> locationsTo = new List<Location>();
            locationsTo.Add(new Location()
            {
                LocationId = locationTo.LocationId,
                LocationName = locationTo.LocationName
            });
            cmbLocationTo.DataSource = locationsTo;
            cmbLocationTo.DisplayMember = "LocationName";
            cmbLocationTo.ValueMember = "LocationId";
        }

        private PreStockReplenishment SaveItem(PreStockReplenishment item)
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
            cmbLocationFrom.Enabled = false;
            cmbLocationTo.Enabled = false;

            txtBarcode.Enabled = false;
            txtPackingUnit.Enabled = false;
            txtProductName.Enabled = false;
            txtProductName2.Enabled = false;
            txtQuantity.Enabled = txtBarcode.Text != "" && isEnabled;
        }
        #endregion        
    }
}