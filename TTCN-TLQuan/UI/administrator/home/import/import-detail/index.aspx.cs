using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.import.import_detail
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ImportID"] != null)
            {
                ImportBLL importBLL = new ImportBLL();
                Import import = new Import();

                import = importBLL.GetByID(Request.QueryString["ImportID"].ToString());

                User_FullName.InnerText = import.UserName;
                Date_Import.InnerText = import.Date;
            }
        }

        [WebMethod]
        public static List<ImportDetail> GetAll(string ImportID)
        {
            ImportDetailBLL importDetailBLL = new ImportDetailBLL();

            return importDetailBLL.GetAllByImportID(ImportID);
        }
    }
}