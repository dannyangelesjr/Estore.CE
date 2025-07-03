using System;
using System.Windows.Forms;
using Estore.Ce.Infrastructure.Repositories;
using Estore.Ce.Contracts;
using Estore.Ce.Contracts.Services;

namespace Estore.Ce.Services
{
    public interface ISyncManager
    {
        event Action<string> StatusUpdated;
        event Action<int, int> RecordUpdated;

        void SyncAll();
    }

    public class SyncManager : ISyncManager
    {
        private ILocationRepository _locationRepository;
        private IProductRepository _productRepository;
        private ILocationSyncService _locationSyncService;
        private IProductSyncService _productSyncService;

        public event Action<string> StatusUpdated;
        public event Action<int, int> RecordUpdated;

        public SyncManager()
        {
            InitializeService();

            // Subscribe to the RecordUpdated events
            _locationSyncService.RecordUpdated += OnRecordUpdated;
            _productSyncService.RecordUpdated += OnRecordUpdated;
            _productSyncService.StatusUpdated += OnStatusUpdated;
        }

        private void InitializeService()
        {
            _locationRepository = new LocationRepository();
            _productRepository = new ProductRepository();
            _locationSyncService = new LocationSyncService(_locationRepository);
            _productSyncService = new ProductSyncService(_productRepository);
        }

        public void SyncAll()
        {
            OnStatusUpdated("Syncing locations...");
            _locationSyncService.Sync();
            OnStatusUpdated("Location sync completed.");

            OnStatusUpdated("Syncing products...");
            _productSyncService.Sync();
            OnStatusUpdated("Product sync completed.");
        }

        private void OnStatusUpdated(string status)
        {
            if (StatusUpdated != null)
            {
                StatusUpdated(status);
                Application.DoEvents();
            }
        }

        private void OnRecordUpdated(int recordsFound, int recordsUpdated)
        {
            if (RecordUpdated != null)
            {
                RecordUpdated(recordsFound, recordsUpdated);
                Application.DoEvents();
            }
        }
    }
}
