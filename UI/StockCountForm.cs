using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Estore.Ce.Repositories;
using Estore.Ce.Models;
using Estore.Ce.Helpers;

namespace Estore.Ce.UI
{
    public partial class StockCountForm : Form
    {
        private ILocationRepository _locationRepository;
        private IProductRepository _productRepository;
        private IStockCountRepository _stockCountRepository;

        private PreStockCount item = new PreStockCount();

        private bool isSimulator = false;
        private bool isInitializing = true;

        #region Constructor
        public StockCountForm()
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            InitializeService();
            InitializeForm();
            InitializeScanner();

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Form Events
        private void StockCountForm_Closing(object sender, CancelEventArgs e)
        {
            barcode1.EnableScanner = false;
        }
        #endregion

        #region Control Events
        private void barcode1_OnRead(object sender, Symbol.Barcode.ReaderData readerData)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Focus();

            string scannedBarcode = BarcodeHelper.PadWithZerosAndDropCheckDigit(readerData);

            try
            {
                ProcessAndDisplayProductInfo(scannedBarcode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            Cursor.Current = Cursors.Default;
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                item = (PreStockCount)this.bindingSource1.Current;
                PopulateStockCountDetails(item);
                this.productName2TextBox.Text = item.ProductName;
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SetupControls(false);
            Cursor.Current = Cursors.WaitCursor;

            PreStockCountService.IPreStockCountService service = new Estore.Ce.PreStockCountService.IPreStockCountService();
            PreStockCountService.CreatePreStockCountCommandResponse response = service.Post(MapToDtos());
            if (response.Success)
            {
                _stockCountRepository.DeleteAll();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Submission successful","Sucess", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Submission failed", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                SetupControls(true);
            }
        }

        private void cmbLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                int selectedId = ((Location)this.cmbLocation.SelectedItem).LocationId;
                SetupControls(selectedId != 0);
            }
        }

        private void grdItems_LostFocus(object sender, EventArgs e)
        {
            txtBarcode.Text = grdItem[grdItem.CurrentRowIndex, 1].ToString();
            txtProductName.Text = grdItem[grdItem.CurrentRowIndex, 5].ToString();
            txtQuantity.Text = grdItem[grdItem.CurrentRowIndex, 6].ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((TabControl)sender).SelectedIndex;
            SetupControls(index == 0);
            if (index > 0)
            {
                PopulateStockCountGrid(GetStockCounts());
            }
        }

        private void txtBarcode_Validated(object sender, EventArgs e)
        {
            ProcessAndDisplayProductInfo(this.txtBarcode.Text.PadLeft(18, '0'));
        }
        #endregion

        #region Private Methods
        private Product GetProduct(string barcode)
        {
            Product product = _productRepository.GetProductByBarcode(barcode);
            if (product!= null && product.PackingUnit != "CASE" && product.ProductParentId != null)
            {
                if (MessageBox.Show("Use per case", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Product productParent = _productRepository.GetProductByProductId((int)product.ProductParentId);
                    product = productParent != null ? productParent : product;
                }
            }
            return product;
        }

        private List<PreStockCount> GetStockCounts()
        {
            return _stockCountRepository.GetAll().ToList();
        }

        private void InitializeForm()
        {
            PopulateLocationCombo();
            PopulateInitialStockCounts();

            isInitializing = false;

            SetupControls(((Location)this.cmbLocation.SelectedItem).LocationName != "");
            SetupDataGrid();
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

        private void InitializeService()
        {
            _locationRepository = new LocationRepository();
            _productRepository = new ProductRepository();
            _stockCountRepository = new StockCountRepository();
        }

        private void PopulateLocationCombo()
        {
            List<Location> locations = _locationRepository.GetAll().ToList();
            if (locations == null || locations.Count == 0)
            {
                MessageBox.Show("Location table is empty. Cannot proceed", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            locations.Add(new Location() { LocationId = 0, LocationName = "" });
            this.cmbLocation.DataSource = locations;
            this.cmbLocation.DisplayMember = "LocationName";
            this.cmbLocation.ValueMember = "LocationId";
            this.cmbLocation.SelectedIndex = 3;
        }

        private void PopulateInitialStockCounts()
        {
            List<PreStockCount> entities = GetStockCounts();
            PopulateStockCountGrid(entities);

            if (entities.Count > 0)
            {
                this.cmbLocation.SelectedValue = entities[0].LocationId;
            }
        }

        private void ProcessAndDisplayProductInfo(string barcode)
        {
            if (barcode == null)
            {
                return;
            }

            Product product = GetProduct(barcode);
            if (product == null)
            {
                MessageBox.Show("Barcode not found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            item = _stockCountRepository.GetStockCountByBarcode(product.Barcode);
            if (item == null)
            {
                item = new PreStockCount
                {
                    Barcode = product.Barcode,
                    DeviceId = DeviceHelper.GetDeviceId(),
                    LocationId = Convert.ToInt32(this.cmbLocation.SelectedValue.ToString()),
                    PackingUnit = product.PackingUnit,
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Quantity = 1,
                    ScanDate = DateTime.Now
                };
                _stockCountRepository.Insert(item);
            }
            else
            {
                item.Quantity++;
                _stockCountRepository.Update(item);
            }

            PopulateStockCountDetails(item);
        }

        private PreStockCountService.CreatePreStockCountCommandDto[] MapToDtos()
        {
            List<PreStockCount> rows = GetStockCounts();
            List<PreStockCountService.CreatePreStockCountCommandDto> dtos = new List<PreStockCountService.CreatePreStockCountCommandDto>();

            foreach (PreStockCount row in rows)
            {
                dtos.Add(new PreStockCountService.CreatePreStockCountCommandDto
                {
                    Barcode = row.Barcode,
                    DeviceId = row.DeviceId,
                    LocationId = row.LocationId,
                    ProductId = row.ProductId,
                    Quantity = row.Quantity,
                    ScanDate = row.ScanDate
                });
            }
            return dtos.ToArray();
        }

        private void PopulateStockCountDetails(PreStockCount row)
        {
            if (row == null)
            {
                txtBarcode.Text = "";
                txtPackingUnit.Text = "";
                txtProductName.Text = "";
                txtQuantity.Text = "";
            }
            else
            {
                txtBarcode.Text = row.Barcode;
                txtPackingUnit.Text = row.PackingUnit;
                txtProductName.Text = row.ProductName;                
                txtQuantity.Text = row.Quantity.ToString("N0");
            }
        }

        private void PopulateStockCountGrid(IEnumerable<PreStockCount> stockCounts)
        {
            this.bindingSource1.DataSource = stockCounts;
        }

        private void SetupControls(bool isEnabled)
        {
            barcode1.EnableScanner = isEnabled;
            this.txtBarcode.Enabled = isEnabled && isSimulator;
            this.cmbLocation.Enabled = !isEnabled && this.cmbLocation.Text == "";            
            this.txtQuantity.Enabled = this.txtBarcode.Text != "" && isEnabled;
        }

        private void SetupDataGrid()
        {
            IEnumerable<PreStockCount> rows = GetStockCounts();
            bindingSource1.DataSource = rows;

            this.grdItem.TableStyles.Clear();
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = "PreStockCount";
            this.grdItem.TableStyles.Add(ts);

            this.grdItem.TableStyles[0].GridColumnStyles[0].Width = -1;  //id
            this.grdItem.TableStyles[0].GridColumnStyles[1].Width = 120; //barcode
            this.grdItem.TableStyles[0].GridColumnStyles[2].Width = -1;  //deviceid            
            this.grdItem.TableStyles[0].GridColumnStyles[3].Width = -1;  //locationid            
            this.grdItem.TableStyles[0].GridColumnStyles[4].Width = -1;  //productid
            this.grdItem.TableStyles[0].GridColumnStyles[5].Width = -1; //productname                                    
            this.grdItem.TableStyles[0].GridColumnStyles[6].HeaderText = "Qty";
            this.grdItem.TableStyles[0].GridColumnStyles[6].Width = 30;  //quantity
            this.grdItem.TableStyles[0].GridColumnStyles[7].HeaderText = "Unit";
            this.grdItem.TableStyles[0].GridColumnStyles[7].Width = 100;  //packingUnit
            this.grdItem.TableStyles[0].GridColumnStyles[8].Width = -1;  //scandate
        }
        #endregion                      
    }
}
