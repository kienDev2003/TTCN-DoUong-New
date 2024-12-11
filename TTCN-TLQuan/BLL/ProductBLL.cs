using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
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
            return _productDAL.GetAll();
        }

        public List<Product> GetByName(string Name)
        {
            return _productDAL.GetByName(Name);
        }

        public Product GetByID(int ProductID)
        {
            return _productDAL.GetByID(ProductID);
        }
    }
}