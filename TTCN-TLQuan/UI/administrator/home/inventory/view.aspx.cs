using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.inventory
{
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<InventoryDetail> GetAllByInventoryID(string InventoryID)
        {
            InventoryDetailBLL inventoryDetailBLL = new InventoryDetailBLL();
            return inventoryDetailBLL.GetAllByInventoryID(InventoryID);
        }
    }
}