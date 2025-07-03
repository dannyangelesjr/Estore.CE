using System;
using System.Linq;
using System.Collections.Generic;
using Estore.Ce.ProductService;
using Estore.Ce.Models;
using Estore.Ce.Helpers;
using Estore.Ce.Contracts;
using Estore.Ce.Contracts.Services;

namespace Estore.Ce.Services
{
    public class ProductSyncService : BaseSyncService, IProductSyncService
    {
        private readonly IProductRepository _repository;
        
        public ProductSyncService(IProductRepository repository)
        {
            _repository = repository;

            // Subscribe to the StatusUpdated event
            _repository.StatusUpdated += UpdateStatus;
            _repository.RecordUpdated += UpdateProgressBar;
        }

        public override void Sync()
        {
            IProductSoapService service = new IProductSoapService();
            service.Timeout = 100000;

            _repository.DeleteAll();
            DatabaseHelper.ResetIdentity("Product", "Id");

            int pageNumber = 1;
            int pageSize = 1000;
            int recordCount = service.GetRecordCount(true); // get only the active products with barcode
            int count = 0;
            try
            {
                while (true)
                {
                    IEnumerable<ProductDto> dtoList = service.GetPaged(true, pageNumber, pageSize);
                    if (dtoList.Count() == 0)
                    {
                        break;
                    }

                    List<Product> entities = new List<Product>();
                    Product entity = new Product();

                    foreach (var dto in dtoList)
                    {
                        count++;
                        UpdateStatus("Syncing products (" + (count + "/" + recordCount + ")"));

                        entity = ObjectMapper.MapTo<ProductDto,Product>(dto);
                        entities.Add(entity);
                    }

                    
                    UpdateStatus("Storing in local db (" + count + "/" + recordCount + ")");                    
                    UpdateProgressBar(recordCount, count);
                    
                    _repository.InsertAll(entities);

                    entities = null;

                    pageNumber++;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}
