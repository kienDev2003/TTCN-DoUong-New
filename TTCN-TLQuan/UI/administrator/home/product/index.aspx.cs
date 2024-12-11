using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.product
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Product> GetAll()
        {
            ProductBLL productBLL = new ProductBLL();
            return productBLL.GetAll();
        }

        [WebMethod]
        public static List<Product> GetByName(string Name)
        {
            ProductBLL productBLL = new ProductBLL();
            return productBLL.GetByName(Name);
        }

        [WebMethod]
        public static bool Delete(int ProductID)
        {
            ProductBLL productBLL = new ProductBLL();
            Product product = new Product();
            product = productBLL.GetByID(ProductID);

            if (product.ImageUrl != "")
            {
                string physicalPath = HttpContext.Current.Server.MapPath(product.ImageUrl);
                if (File.Exists(physicalPath))
                {
                    File.Delete(physicalPath);
                }
            }
            return productBLL.Delete(ProductID);
        }
    }
}