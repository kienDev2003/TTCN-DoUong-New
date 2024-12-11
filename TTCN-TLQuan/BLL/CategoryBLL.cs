using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class CategoryBLL
    {
        private CategoryDAL _categoryDAL;

        public CategoryBLL()
        {
            _categoryDAL = new CategoryDAL();
        }

        public bool Add(Category category)
        {
            if (_categoryDAL.Add(category) > 0) return true;
            return false;
        }

        public bool Update(Category category)
        {
            if (_categoryDAL.Update(category) > 0) return true;
            return false;
        }

        public bool Delete(int CategoryID)
        {
            if (_categoryDAL.Delete(CategoryID) > 0) return true;
            return false;
        }

        public List<Category> GetAll()
        {
            List<Category> listCategory = new List<Category>();
            using(SqlDataReader reader = _categoryDAL.GetAll())
            {
                while(reader.Read())
                {
                    Category category = new Category();

                    category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    category.CategoryName = Convert.ToString(reader["CategoryName"]);

                    listCategory.Add(category);
                }
            }
            return listCategory;
        }
    }
}