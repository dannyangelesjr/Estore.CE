using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;
using Estore.Ce.ProductService;
using System.Data.SqlServerCe;

namespace Estore.Ce.Profiles
{
    public class ProductProfile
    {
        //No AutoMapper so manual mapping for now
        public Product Map(SqlCeDataReader reader)
        {
            try
            {
                Product product = new Product();
                product.Barcode = reader["Barcode"].ToString();
                product.Brand = reader["Brand"].ToString();
                product.Category = reader["Category"].ToString();
                product.PackingSize = (int)reader["PackingSize"];
                product.PackingUnit = reader["PackingUnit"].ToString();
                product.ProductId = (int)(reader["ProductId"]);
                if (reader["ProductParentId"] != null)
                {
                    product.ProductParentId = (int)(reader["ProductParentId"]);
                }                
                product.ProductName = reader["Name"].ToString();
                product.SellingPrice = (decimal)reader["SellingPrice"];

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product Map(ProductGetAllDto productDto)
        {
            try
            {
                Product product = new Product()
                {
                    Id = productDto.ProductId,
                    Barcode = productDto.Barcode,
                    Brand = productDto.Brand,
                    Category = productDto.Category,
                    PackingSize = (int)productDto.PackingSize,
                    PackingUnit = productDto.PackingUnit,
                    ProductId = productDto.ProductId,
                    ProductParentId = productDto.ProductParentId != null ? productDto.ProductParentId : null,                    
                    ProductName = productDto.ProductName,
                    SellingPrice = (decimal)productDto.SellingPrice
                };

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
