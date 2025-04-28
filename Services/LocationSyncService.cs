using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.LocationService;
using Estore.Ce.Models;
using Estore.Ce.Repositories;
using Estore.Ce.Profiles;
using System.Windows.Forms;
using Estore.Ce.Helpers;

namespace Estore.Ce.Services
{
    public interface ILocationSyncService
    {        
        event Action<int, int> RecordUpdatedLocationSyncService;

        void SyncLocations();
    }

    public class LocationSyncService : ILocationSyncService
    {
        private readonly ILocationRepository _repository;

        public event Action<int, int> RecordUpdatedLocationSyncService;

        public LocationSyncService(ILocationRepository repository)
        {
            _repository = repository;

            // Subscribe to the RecordUpdated event
            _repository.RecordUpdatedLocationRepository += UpdateProgressBar;
        }

        public void SyncLocations()
        {
            ILocationService locationService = new ILocationService();
            locationService.Timeout = 100000;

            LocationProfile locationProfile = new LocationProfile();

            _repository.DeleteAll();
            DatabaseHelper.ResetIdentity("Location", "Id");            

            List<LocationGetAllDto> locationsDto;
            List<Location> locations = new List<Location>();

            locationService.Timeout = 100000;
            locationsDto = locationService.Locations(true).ToList();
            
            foreach (var locationDto in locationsDto)
            {
                Location location = locationProfile.Map(locationDto);
                locations.Add(location);                
            }

            try
            {
                _repository.InsertAll(locations);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateProgressBar(int recordsFound, int recordsUpdated)
        {
            if (RecordUpdatedLocationSyncService != null)
            {
                RecordUpdatedLocationSyncService(recordsFound, recordsUpdated);
            };
        }
    }
}