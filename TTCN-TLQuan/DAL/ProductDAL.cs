using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class ProductDAL
    {
        private DatabaseConnection _dB;

        public ProductDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(Product product)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", product.Name },
                {"@Describe", product.Describe },
                {"@StatusSell", product.StatusSell },
                {"@Price", product.Price},
                {"@CategoryID", product.CategoryID },
                {"@ImageUrl", product.ImageUrl }
            };
            return _dB.ExecuteNonQuery("Product_Insert", parameter);
        }

        public int Update(Product product)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID", product.ProductID },
                {"@Name", product.Name },
                {"@Describe", product.Describe },
                {"@StatusSell", product.StatusSell },
                {"@Price", product.Price},
                {"@CategoryID", product.CategoryID },
                {"@ImageUrl", product.ImageUrl }
            };
            return _dB.ExecuteNonQuery("Product_Update", parameter);
        }

        public int Delete(int ProductID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID",ProductID }
            };
            return _dB.ExecuteNonQuery("product_Delete", parameter);
        }

        public List<Product> GetAll()
        {
            List<Product> listProduct = new List<Product>();
            using (SqlDataReader reader = _dB.ExecuteReader("Product_Select", null))
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

        public List<Product> GetByName(string Name)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", Name }
            };
            List<Product> listProduct = new List<Product>();
            using (SqlDataReader reader = _dB.ExecuteReader("Product_Select_By_Name", parameter))
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

        public Product GetByID(int ProductID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID", ProductID }
            };
            Product product = new Product();
            using (SqlDataReader reader = _dB.ExecuteReader("Product_Select_By_ID", parameter))
            {
                while (reader.Read())
                {
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.Name = Convert.ToString(reader["Name"]);
                    product.Describe = Convert.ToString(reader["Describe"]);
                    product.StatusSell = Convert.ToBoolean(reader["StatusSell"]);
                    product.Price = Convert.ToSingle(reader["Price"]);
                    product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    product.CategoryName = Convert.ToString(reader["CategoryName"]);
                    product.ImageUrl = Convert.ToString(reader["ImageUrl"]);
                }
            }
            return product;
        }

        public List<Product> GetAllByCategoryID(int CategoryID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@CategoryID", CategoryID }
            };
            List<Product> listProduct = new List<Product>();
            using (SqlDataReader reader = _dB.ExecuteReader("Product_Select_By_Category", parameter))
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