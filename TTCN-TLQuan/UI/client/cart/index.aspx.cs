using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.client.cart
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class OrderRequest
        {
            public string TotalMoney { get; set; }
            public List<OrderDetail> listOrderDetail { get; set; }
        }

        [WebMethod]
        public static object checkOrder(OrderRequest orderRequest)
        {
            Order order = new Order();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();

            order.OrderID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            order.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            order.TableID = Convert.ToInt32(HttpContext.Current.Session["tableID"].ToString());
            order.TotalMoney = Convert.ToSingle(orderRequest.TotalMoney.ToString());
            order.PaymentMethodID = 1;
            order.StatusServe = false;
            order.StatusPay = false;

            listOrderDetail = orderRequest.listOrderDetail;
            
            ProductBLL productBLL = new ProductBLL();

            foreach (OrderDetail orderDetail in listOrderDetail)
            {
                Product product = productBLL.GetByID(orderDetail.ProductID);

                orderDetail.OrderID = order.OrderID;
                orderDetail.TotalMoney = product.Price * orderDetail.Quantity;
                orderDetail.StatusServe = false;
            }

            string errorMessage = "";

            for (int i = 0; i < listOrderDetail.Count; i++)
            {
                bool checkRawMaterial = productBLL.RawMaterial(listOrderDetail[i].ProductID, listOrderDetail[i].Quantity);
                Product product = productBLL.GetByID(listOrderDetail[i].ProductID);

                if (!checkRawMaterial)
                {
                    errorMessage = $"Sản phẩm {product.Name} không đủ nguyên liệu làm {listOrderDetail[i].Quantity} cốc. Vui lòng giảm số lượng sản phẩm hoặc chọn sản phẩm khác!";
                    break;
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return new
                {
                    key = -1,
                    content = errorMessage
                };
            }

            OrderBLL orderBLL = new OrderBLL();
            Order order_already_exists = new Order();
            order_already_exists = orderBLL.GetByTableIDAndNotPay(order.TableID);

            if(order_already_exists.OrderID != null)
            {
                order.OrderID = order_already_exists.OrderID;
                order.TotalMoney += order_already_exists.TotalMoney;

                foreach (OrderDetail orderDetail in listOrderDetail)
                {
                    orderDetail.OrderID = order.OrderID;
                }

                if (UpdateIngredientQuantity(listOrderDetail) && UpdateOrder(order, listOrderDetail))
                {
                    return new
                    {
                        key = 1,
                        content = "../thanks/"
                    };
                }
            }
            else
            {
                if (UpdateIngredientQuantity(listOrderDetail) && AddOrder(order, listOrderDetail))
                {
                    return new
                    {
                        key = 1,
                        content = "../thanks/"
                    };
                }
            }

            
            return new
            {
                key = -1,
                content = "Lỗi"
            };

        }

        public static bool UpdateOrder(Order order, List<OrderDetail> orderDetails)
        {
            OrderBLL orderBLL = new OrderBLL();
            OrderDetailBLL orderDetailBLL = new OrderDetailBLL();

            if (orderBLL.Update(order) && orderDetailBLL.AddList(orderDetails)) return true;
            return false;
        }

        public static bool AddOrder(Order order, List<OrderDetail> orderDetails)
        {
            OrderBLL orderBLL = new OrderBLL();
            OrderDetailBLL orderDetailBLL = new OrderDetailBLL();

            if (orderBLL.Add(order) && orderDetailBLL.AddList(orderDetails)) return true;
            return false;
        }
        private static bool UpdateIngredientQuantity(List<OrderDetail> orderDetails)
        {
            foreach (OrderDetail orderDetail in orderDetails)
            {
                RecipeBLL recipeBLL = new RecipeBLL();
                RecipeDetailBLL recipeDetailBLL = new RecipeDetailBLL();
                IngredientBLL ingredientBLL = new IngredientBLL();

                Recipe recipe = new Recipe();
                List<RecipeDetail> recipeDetails = new List<RecipeDetail>();

                recipe = recipeBLL.getByProductId(orderDetail.ProductID);

                recipeDetails = recipeDetailBLL.GetAllByRecipeID(recipe.RecipeID);

                foreach (RecipeDetail recipeDetail in recipeDetails)
                {
                    Ingredient ingredient = ingredientBLL.GetByID(recipeDetail.IngredientID);

                    int lastQuantity = ingredient.Quantity - recipeDetail.QuantityNeed * orderDetail.Quantity;

                    ingredient.Quantity = lastQuantity;

                    if (!ingredientBLL.Update(ingredient)) return false;
                }
            }
            return true;
        }
    }
}