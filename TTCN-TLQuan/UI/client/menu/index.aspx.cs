using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBH_TTCN_DoUong;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.client.menu
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["tableid"] == null)
                    {
                        string scriptNoti = "alert(\"Không có số bàn. Truy cập bị từ chối\")";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", scriptNoti, true);
                        return;
                    }
                    int tableId = int.Parse(Request.QueryString["tableid"]);

                    if (tableId >= 0)
                    {
                        Session["tableID"] = tableId;
                        LoadCategori();
                        LoadProduct();
                    }
                }
                catch (Exception ex)
                {
                    string scriptNoti = ex.Message;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", scriptNoti, true);
                }
            }
        }

        private void LoadProduct()
        {
            content_container.Controls.Clear();
            string html = "";

            ProductBLL productBLL = new ProductBLL();
            CategoryBLL categoryBLL = new CategoryBLL();

            List<Product> listProduct = new List<Product>();
            List<Category> listCategory = new List<Category>();

            listCategory = categoryBLL.GetAll();

            foreach(Category category in listCategory)
            {
                listProduct = productBLL.GetAllByCategoryID(category.CategoryID);
                string htmlProduct = "";

                foreach(Product product in listProduct)
                {
                    string htmlProductItem = $"<div class=\"item\">" +
                                                    $"<img src=\"{product.ImageUrl.Replace("../../","../")}\" alt=\"\" />" +
                                                    $"<div class=\"des\">" +
                                                        $"<p class=\"nameItem\">{product.Name}</p>" +
                                                        $"<p class=\"dseItem\">" +
                                                            $"{product.Describe}" +
                                                        $"</p>" +
                                                        $"<div class=\"dseNav\">" +
                                                            $"<p class=\"priceItem\">{product.Price}</p>" +
                                                            $"<div class=\"btnAddItem\" tag=\"{product.ProductID}\">" +
                                                                $"<img src=\"./assets/img/icon-add-item.svg\" alt=\"\" />" +
                                                            $"</div>" +
                                                        $"</div>" +
                                                    $"</div>" +
                                                 $"</div>";

                    htmlProduct += htmlProductItem;
                }
                string htmlCategoriItem = $"<div class=\"category\" id=\"{category.CategoryID}\" >" +
                                                $"<h2>{category.CategoryName}</h2>" +
                                                $"<div class=\"categoryContent\">" +
                                                    $"{htmlProduct}" +
                                                $"</div>" +
                                              $"</div>";

                html += htmlCategoriItem;

            }

            LiteralControl literalControl = new LiteralControl(html);
            content_container.Controls.Add(literalControl);
        }

        private void LoadCategori()
        {
            nav.Controls.Clear();
            string html = "";

            CategoryBLL categoryBLL = new CategoryBLL();
            List<Category> listCategory = categoryBLL.GetAll();

            foreach(Category category in listCategory)
            {
                string htmlCategori = $"<a href=\"#{category.CategoryID}\">{category.CategoryName}</a>";
                html += htmlCategori;
            }
            LiteralControl literalControl = new LiteralControl(html);
            nav.Controls.Add(literalControl);
        }

        [WebMethod]
        public static bool CheckRawMaterial(int productId, int quantity)
        {
            ProductBLL productBLL= new ProductBLL();

            if (productBLL.RawMaterial(productId, quantity)) return true;
            return false;
        }
    }
}