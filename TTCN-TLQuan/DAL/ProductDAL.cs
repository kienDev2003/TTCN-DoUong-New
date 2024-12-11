using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("Product_Select", null);
        }
    }
}