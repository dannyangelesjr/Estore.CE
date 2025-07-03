using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Estore.Ce.Contracts;
using Estore.Ce.Models;
using Estore.Ce.Infrastructure.Repositories;
using Estore.Ce.Services;
using Estore.Ce.Contracts.Services;
using Estore.Ce.Helpers;

namespace Estore.Ce
{
    public partial class PreStockReceiptListForm : Form
    {
        #region Fields
        //-------------
        IPreStockReceiptRepository _repository;
        IPreStockReceiptSyncService _preStockReceiptSyncService;
        List<PreStockReceiptAggregate> _preStockReceiptAggregate;
        #endregion

        #region Constructor
        //-----------------
        public PreStockReceiptListForm()
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            InitializeServices();
            InitializeData();
            if (_preStockReceiptAggregate.Count() > 0)
            {
                InitializeDataGrid();
            }

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Form events
        //------------
        private void btnContinue_Click(object sender, EventArgs e)
        {
            Form form = new SupplierDeliveryForm(_preStockReceiptAggregate[grdItems.CurrentRowIndex].SupplierInvoiceNumber);
            form.Show();
        }
        #endregion

        #region Control events
        //--------------------
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!NetworkHelper.IsConnectedToServer())
            {
                MessageBox.Show("No connection. Submission aborted", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _preStockReceiptSyncService.Sync();
                _preStockReceiptAggregate = _repository.GetPendingDeliveries();
                grdItems.DataSource = _preStockReceiptAggregate;

                InitializeDataGrid();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void grdItems_Click(object sender, EventArgs e)
        {
            ((DataGrid)sender).Select(((DataGrid)sender).CurrentRowIndex);
        }
        #endregion

        #region User Defined Functions
        //----------------------------
        private void InitializeServices()
        {
            try
            {
                _repository = new PreStockReceiptRepository();
                _preStockReceiptSyncService = new PreStockReceiptSyncService(_repository);                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void InitializeData()
        {
            _preStockReceiptAggregate = _repository.GetPendingDeliveries();
        }

        private void InitializeDataGrid()
        {
            grdItems.DataSource = _preStockReceiptAggregate;

            this.grdItems.TableStyles.Clear();
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = _preStockReceiptAggregate.GetType().Name;
            this.grdItems.TableStyles.Add(ts);

            this.grdItems.TableStyles[0].GridColumnStyles["SupplierInvoiceNumber"].Width = 80;
            this.grdItems.TableStyles[0].GridColumnStyles["SupplierInvoiceNumber"].HeaderText = "Inv/DR#";

            this.grdItems.TableStyles[0].GridColumnStyles["SupplierName"].Width = 190;
            this.grdItems.TableStyles[0].GridColumnStyles["SupplierName"].HeaderText = "Supplier";

            this.grdItems.TableStyles[0].GridColumnStyles["PurchaseOrderNumber"].Width = -1;
            this.grdItems.TableStyles[0].GridColumnStyles["PurchaseOrderNumber"].HeaderText = "PO#";

            grdItems.Select(grdItems.CurrentRowIndex);
        }
        #endregion     
    }
}