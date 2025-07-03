using System;
using System.Linq;
using System.Collections.Generic;
using Estore.Ce.LocationService;
using Estore.Ce.Models;
using Estore.Ce.Helpers;
using Estore.Ce.Contracts;
using Estore.Ce.Contracts.Services;

namespace Estore.Ce.Services
{
    public class LocationSyncService : BaseSyncService,ILocationSyncService
    {
        private readonly ILocationRepository _repository;

        // constructor
        public LocationSyncService(ILocationRepository repository)
        {
            _repository = repository;
        }
        // end: constructor

        public override void Sync()
        {
            try
            {
                ILocationSoapService service = new ILocationSoapService();
                service.Timeout = 100000;

                _repository.DeleteAll();
                DatabaseHelper.ResetIdentity("Location", "Id");

                IEnumerable<LocationDto> dtoList;
                List<Location> entities = new List<Location>();

                service.Timeout = 100000;
                dtoList = service.Locations(true).ToList();
                if (dtoList.Count() > 0)
                {
                    foreach (var dto in dtoList)
                    {
                        Location entity = ObjectMapper.MapTo<LocationDto,Location>(dto);
                        entities.Add(entity);
                    }
                    _repository.InsertAll(entities);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}