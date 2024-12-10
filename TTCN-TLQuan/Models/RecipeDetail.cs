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
        public string IngredientName { get; set; }
        public int QuantityNeed { get; set; }
        public int RecipeID { get; set; }
    }
}