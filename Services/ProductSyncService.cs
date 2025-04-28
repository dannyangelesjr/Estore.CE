using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.ProductService;
using Estore.Ce.Repositories;
using Estore.Ce.Profiles;
using Estore.Ce.Models;
using System.Windows.Forms;
using Estore.Ce.Helpers;

namespace Estore.Ce.Services
{
    public interface IProductSyncService
    {
        event Action<string> StatusUpdatedProductSyncService;
        event Action<int, int> RecordUpdatedProductSyncService;
        
        void SyncProducts();
    }

    public class ProductSyncService : IProductSyncService
    {
        private readonly IProductRepository _repository;

        public event Action<string> StatusUpdatedProductSyncService;
        public event Action<int, int> RecordUpdatedProductSyncService;

        public ProductSyncService(IProductRepository repository)
        {
            _repository = repository;

            // Subscribe to the StatusUpdated event
            _repository.StatusUpdatedProductRepository += OnStatusUpdated;
            _repository.RecordUpdatedProductRepository += OnRecordUpdated;
        }

        public void SyncProducts()
        {
            IProductService productService = new IProductService();
            productService.Timeout = 100000;

            ProductProfile productProfile = new ProductProfile();

            _repository.DeleteAll();
            DatabaseHelper.ResetIdentity("Product", "Id");

            List<ProductGetAllDto> productsDto = new List<ProductGetAllDto>();
            List<Product> products = new List<Product>();

            int pageNumber = 1;
            int pageSize = 1000;
            int recordCount = productService.RecordCount(true); // get only the active products with barcode
            int count = 0;
            try
            {
                while (true)
                {
                    var result = productService.ProductsPaged(true,pageNumber, pageSize);
                    //var result = productService.Products(); 
                    if (result != null)
                    {
                        productsDto = result.ToList();
                    }
                    else
                    {
                        break; 
                    }

                    products.Clear();
                    Product product = new Product();

                    try
                    {
                        foreach (var productDto in productsDto)
                        {
                            count++;
                            product = productProfile.Map(productDto);
                            products.Add(product);
                        }

                        _repository.InsertAll(products);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    products = new List<Product>();

                    pageNumber++;

                    OnStatusUpdated("Syncing products (" + count + "/" + recordCount + ")");
                    OnRecordUpdated(recordCount, count);
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnStatusUpdated(string message)
        {
            if (StatusUpdatedProductSyncService != null)
            {
                StatusUpdatedProductSyncService(message);
                Application.DoEvents();
            }
        }

        private void OnRecordUpdated(int recordsFound, int recordsUpdated)
        {
            if (RecordUpdatedProductSyncService != null)
            {
                RecordUpdatedProductSyncService(recordsFound, recordsUpdated);
                Application.DoEvents();
            }            
        }
    }
}
