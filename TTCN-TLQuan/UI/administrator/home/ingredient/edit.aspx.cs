using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.ingredient
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCboUnit();
                if (Request.QueryString["IngredientID"] != null)
                {
                    LoadDataToUpdate(Convert.ToInt32(Request.QueryString["IngredientID"]));
                }
            }
        }

        private void LoadCboUnit()
        {
            List<Models.Unit> units = new List<Models.Unit>();
            UnitBLL unitBLL = new UnitBLL();

            units = unitBLL.GetAll();

            foreach (var unit in units)
            {
                ingredientCboUnit.Items.Add(new ListItem { Text =unit.UnitName, Value = unit.UnitID.ToString() });
            }
        }

        private void LoadDataToUpdate(int IngredientID)
        {
            Ingredient ingredient = new Ingredient();
            IngredientBLL ingredientBLL = new IngredientBLL();

            ingredient = ingredientBLL.GetByID(IngredientID);

            txtIngredients_Name.Value = ingredient.Name;
            txtIngredients_Price.Value = ingredient.Price.ToString();
            txtIngredients_Quantity.Value = ingredient.Quantity.ToString();
            ingredientCboUnit.SelectedValue = ingredient.UnitID.ToString();

        }

        protected void btnCRUD_ServerClick(object sender, EventArgs e)
        {
            Ingredient ingredient = new Ingredient();
            IngredientBLL ingredientBLL = new IngredientBLL();

            ingredient.Name = txtIngredients_Name.Value;
            ingredient.Price = Convert.ToSingle(txtIngredients_Price.Value);
            ingredient.Quantity = Convert.ToInt32(txtIngredients_Quantity.Value);
            ingredient.UnitID = Convert.ToInt32(ingredientCboUnit.SelectedValue);

            if (Request.QueryString["IngredientID"] == null)
            {
                if (ingredientBLL.Add(ingredient))
                {
                    string script = "Swal.fire({title: 'Thông báo!', text: 'Thêm nguyên liệu mới thành công', icon: 'success', confirmButtonText: 'OK'}).then((result) => {if (result.isConfirmed) { window.location.href = './'; } });";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    string script = "Swal.fire({title: 'Thông báo!', text: 'Lỗi thêm nguyên liệu mới', icon: 'error', confirmButtonText: 'OK'}).then((result) => {if (result.isConfirmed) { window.location.href = './'; } });";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
            else
            {
                ingredient.IngredientID = Convert.ToInt32(Request.QueryString["IngredientID"]);
                if (ingredientBLL.Update(ingredient))
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
    }
}