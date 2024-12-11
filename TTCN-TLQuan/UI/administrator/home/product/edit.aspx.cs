using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.product
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
                LoadStatusSell();
                if (Request.QueryString["ProductID"] != null)
                {
                    LoadDataToUpdate(Convert.ToInt32(Request.QueryString["ProductID"]));
                }
            }

        }

        private void LoadStatusSell()
        {
            for (int i = 0; i < 2; i++)
            {
                string cboText = "";
                if (i == 0) cboText = "Không bán";
                else cboText = "Bán";

                cboStatusSell.Items.Add(new ListItem { Value = Convert.ToString(i), Text = cboText });
            }
        }

        private void LoadDataToUpdate(int ProductID)
        {
            Product product = new Product();
            ProductBLL productBLL = new ProductBLL();

            product = productBLL.GetByID(ProductID);

            cboProductCategory.SelectedValue = Convert.ToInt32(product.CategoryID).ToString();
            txtName.Value = product.Name;
            txtDescribe.Value = product.Describe;
            txtPrice.Value = Convert.ToString(product.Price);
            cboStatusSell.SelectedValue = Convert.ToInt32(product.StatusSell).ToString();
        }

        private void LoadCategory()
        {
            CategoryBLL categoryBLL = new CategoryBLL();
            List<Category> listCategory = new List<Category>();

            listCategory = categoryBLL.GetAll();

            foreach (var category in listCategory)
            {
                cboProductCategory.Items.Add(new ListItem { Value = Convert.ToString(category.CategoryID), Text = category.CategoryName });
            }
        }

        protected void btnCRUD_ServerClick(object sender, EventArgs e)
        {
            Product product = new Product();
            ProductBLL productBLL = new ProductBLL();

            product.Name = txtName.Value.Trim();
            product.Describe = txtDescribe.Value.Trim();
            product.Price = Convert.ToSingle(txtPrice.Value.Trim());
            product.StatusSell = Convert.ToBoolean(Convert.ToInt32(cboStatusSell.SelectedValue));
            product.CategoryID = Convert.ToInt32(cboProductCategory.SelectedValue);
            product.CategoryName = Convert.ToString(cboProductCategory.SelectedItem.Text);
            product.ImageUrl = SaveImageFile();

            if (Request.QueryString["ProductID"] == null)
            {
                if (productBLL.Add(product))
                {
                    string script = "Swal.fire({title: 'Thông báo!', text: 'Thêm sản phẩm mới thành công', icon: 'success', confirmButtonText: 'OK'}).then((result) => {if (result.isConfirmed) { window.location.href = './'; } });";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    string script = "Swal.fire({title: 'Thông báo!', text: 'Lỗi thêm sản phẩm mới', icon: 'error', confirmButtonText: 'OK'}).then((result) => {if (result.isConfirmed) { window.location.href = './'; } });";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
            else
            {
                product.ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
                string tempFileImage = productBLL.GetByID(product.ProductID).ImageUrl;

                if (product.ImageUrl == "") product.ImageUrl = tempFileImage;
                else DeleteImage(tempFileImage);

                if (productBLL.Update(product))
                {
                    string script = "Swal.fire({title: 'Thông báo!', text: 'Thay đổi thông tin sản phẩm thành công', icon: 'success', confirmButtonText: 'OK'}).then((result) => {if (result.isConfirmed) { window.location.href = './'; } });";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    string script = "Swal.fire({title: 'Thông báo!', text: 'Lỗi thay đổi thông tin sản phẩm', icon: 'error', confirmButtonText: 'OK'}).then((result) => {if (result.isConfirmed) { window.location.href = './'; } });";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
        }

        private string SaveImageFile()
        {
            if (fImageUrl.HasFile)
            {
                string fileName = Path.GetFileName(fImageUrl.PostedFile.FileName);
                string folderPath = Server.MapPath("../../../ImageProduct/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = folderPath + fileName;

                fImageUrl.SaveAs(filePath);

                return "../../../ImageProduct/" + fileName;
            }
            return string.Empty;

        }

        private void DeleteImage(string ImageUrl)
        {
            if (ImageUrl != "")
            {
                string physicalPath = Server.MapPath(ImageUrl);
                if (File.Exists(physicalPath))
                {
                    File.Delete(physicalPath);
                }
            }
        }
    }
}