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
using Estore.Ce.PreStockDamageService;

namespace Estore.Ce.UI
{
    public partial class PreStockDamageForm : Form
    {
        #region Private Fields
        ILocationRepository _locationRepository;
        IProductRepository _productRepository;
        IPreStockDamageRepository _repository;
        IPreStockDamageSoapService _soapService;

        List<PreStockDamage> _preStockDamages = new List<PreStockDamage>();
        List<Location> _locations = new List<Location>();
        #endregion

        #region Constructor
        public PreStockDamageForm()
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            InitializeServices();
            GetAllFromLocalDb();

            PopulateLocationCombo();
            SetupForm(false);

            barcode1.EnableScanner = _preStockDamages.Count() > 0;

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Form Events
        private void PreStockDamageForm_Closing(object sender, CancelEventArgs e)
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
                PreStockDamage item = FindInListByBarcode(barcodeScanned);
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
            if (_preStockDamages.Count() == 0)
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

            List<PreStockDamageDto> dtos = new List<PreStockDamageDto>();

            try
            {
                foreach (PreStockDamage row in _preStockDamages)
                {
                    dtos.Add(ObjectMapper.MapTo<PreStockDamage, PreStockDamageDto>(row));
                }
                ApiResponse response = _soapService.Post(dtos.ToArray());
                if (response.IsSuccess == true)
                {
                    foreach (PreStockDamage item in _preStockDamages)
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
                PreStockDamage item = _preStockDamages[((DataGrid)sender).CurrentRowIndex];
                PopulateControls(item);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.Focus();
            if (tabControl1.SelectedIndex == 1)
            {
                barcode1.EnableScanner = false;
                if (_preStockDamages.Count() > 0)
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
                    PreStockDamage item = _preStockDamages.Where(t => t.LineNumber == lineNumber).FirstOrDefault();
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
            PreStockDamage item = FindInListByBarcode(txtBarcode.Text);
            if (item != null) // && Convert.ToInt32(txtQuantity.Text) != detail.Quantity)
            {
                item.Quantity = Convert.ToInt32(txtQuantity.Text);

                item = SaveItem(item);
                item = ItemUpdateAndUpdateList(item);
            }
        }
        #endregion

        #region Private Methods
        private PreStockDamage FindInListByBarcode(string barcode)
        {
            PreStockDamage detail = _preStockDamages.Where(b => b.Barcode == barcode).FirstOrDefault();
            return detail;
        }

        private void GetAllFromLocalDb()
        {
            try
            {
                _preStockDamages = _repository.GetAll().ToList(); ;

                Location location = _locationRepository.GetByLocationType(LocationType.BadOrder);
                if (location != null)
                {
                    _locations.Add(location);
                }
                else
                {
                    string message = "Missing Bad Order location";                    
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
            _repository = new PreStockDamageRepository();
            _soapService = new IPreStockDamageSoapService();
        }

        private PreStockDamage ItemCreateAndAddToList(string barcode)
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

            PreStockDamage item = new PreStockDamage
            {
                Barcode = product.Barcode,
                DeviceId = DeviceHelper.GetDeviceId(),
                LineNumber = _preStockDamages.Count() + 1,
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue.ToString()),
                PackingUnit = product.PackingUnit,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Quantity = 1,
                ScanDate = DateTime.Now
            };

            _preStockDamages.Add(item);

            return item;
        }

        private PreStockDamage ItemUpdateAndUpdateList(PreStockDamage item)
        {
            // update list
            foreach (PreStockDamage row in _preStockDamages)
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

        private void PopulateControls(PreStockDamage row)
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

            foreach (PreStockDamage item in _preStockDamages)
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
            List<Location> locations = new List<Location>();
            // Note: Exception already thown at GetAllFromLocalDb if BO not in location table
            // so location will never be null
            // have to add manually so that combobox only contains BO location
            Location location = _locations.FirstOrDefault(); 
            locations.Add(new Location()
            {
                LocationId = location.LocationId,
                LocationName = location.LocationName
            });
            cmbLocation.DataSource = locations;
            cmbLocation.DisplayMember = "LocationName";
            cmbLocation.ValueMember = "LocationId";
        }

        private PreStockDamage SaveItem(PreStockDamage item)
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
            cmbLocation.Enabled = !isEnabled && cmbLocation.Text == "";

            txtBarcode.Enabled = false;
            txtPackingUnit.Enabled = false;
            txtProductName.Enabled = false;
            txtProductName2.Enabled = false;
            txtQuantity.Enabled = txtBarcode.Text != "" && isEnabled;
        }
        #endregion
    }
}
