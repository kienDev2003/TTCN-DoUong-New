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
                {"@Name", category.Name }
            };
            return _dB.ExecuteNonQuery("Category_Insert", parameter);
        }

        public int Update(Category category)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", category.Name },
                {"@CategoryID", category.CategoryID }
            };
            return _dB.ExecuteNonQuery("Category_Update", parameter);
        }

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("Category_Select", null);
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