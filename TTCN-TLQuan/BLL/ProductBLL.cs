using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class ProductBLL
    {
        private ProductDAL _productDAL;

        public ProductBLL()
        {
            _productDAL = new ProductDAL();
        }

        public bool Add(Product product)
        {
            if (_productDAL.Add(product) > 0) return true;
            return false;
        }

        public bool Update(Product product)
        {
            if (_productDAL.Update(product) > 0) return true;
            return false;
        }

        public bool Delete(int ProductID)
        {
            if (_productDAL.Delete(ProductID) > 0) return true;
            return false;
        }

        public List<Product> GetAll()
        {
            List<Product> listProduct = new List<Product>();
            using (SqlDataReader reader = _productDAL.GetAll())
            {
                while (reader.Read())
                {
                    Product product = new Product();

                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.Name = Convert.ToString(reader["Name"]);
                    product.Describe = Convert.ToString(reader["Describe"]);
                    product.StatusSell = Convert.ToBoolean(reader["StatusSell"]);
                    product.Price = Convert.ToSingle(reader["Price"]);
                    product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    product.CategoryName = Convert.ToString(reader["CategoryName"]);
                    product.ImageUrl = Convert.ToString(reader["ImageUrl"]);

                    listProduct.Add(product);
                }
            }
            return listProduct;
        }
    }
}