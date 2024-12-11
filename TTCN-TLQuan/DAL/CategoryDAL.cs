using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class CategoryDAL
    {
        private DatabaseConnection _dB;

        public CategoryDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(Category category)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", category.CategoryName }
            };
            return _dB.ExecuteNonQuery("Category_Insert", parameter);
        }

        public int Update(Category category)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", category.CategoryName },
                {"@CategoryID", category.CategoryID }
            };
            return _dB.ExecuteNonQuery("Category_Update", parameter);
        }

        public List<Category> GetAll()
        {
            List<Category> listCategory = new List<Category>();
            using (SqlDataReader reader = _dB.ExecuteReader("Category_Select", null))
            {
                while (reader.Read())
                {
                    Category category = new Category();

                    category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    category.CategoryName = Convert.ToString(reader["CategoryName"]);

                    listCategory.Add(category);
                }
            }
            return listCategory;
        }

        public int Delete(int CategoryID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@CategoryID", CategoryID }
            };
            return _dB.ExecuteNonQuery("Category_Delete", parameter);
        }
    }
}