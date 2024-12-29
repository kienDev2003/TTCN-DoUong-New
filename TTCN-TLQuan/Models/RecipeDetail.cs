using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class RecipeDetail
    {
        public int RecipeDetailID { get; set; }
        public int IngredientID {  get; set; }
        public string Name { get; set; }
        public int QuantityNeed { get; set; }
        public int ProductID { get; set; }
        public string UnitName {  get; set; }
    }
}