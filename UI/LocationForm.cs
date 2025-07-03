using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Estore.Ce.Contracts;
using Estore.Ce.Models;
using Estore.Ce.Infrastructure.Repositories;

namespace Estore.Ce.UI
{
    public partial class LocationForm : Form
    {
        #region Fields
        //-------------
        ILocationRepository _repository;
        IEnumerable<Location> _locations;
        #endregion

        #region Constructor
        //-----------------
        public LocationForm()
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;

            InitializeServices();
            if (_locations.Count() > 0)
            {
                InitializeDataGrid();
            }

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region User Defined Functions
        private void InitializeServices()
        {
            try
            {
                _repository = new LocationRepository();
                _locations = _repository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void InitializeDataGrid()
        {
            grdItems.DataSource = _locations;

            this.grdItems.TableStyles.Clear();
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = _locations.GetType().Name;
            this.grdItems.TableStyles.Add(ts);

            this.grdItems.TableStyles[0].GridColumnStyles["LocationName"].Width = 190;
            this.grdItems.TableStyles[0].GridColumnStyles["LocationName"].HeaderText = "Location";

            this.grdItems.TableStyles[0].GridColumnStyles["IsBadOrder"].Width = 80;
            this.grdItems.TableStyles[0].GridColumnStyles["IsSellingArea"].Width = 80;
            this.grdItems.TableStyles[0].GridColumnStyles["IsWarehouse"].Width = 80;

            grdItems.Select(grdItems.CurrentRowIndex);
        }
        #endregion
    }
}