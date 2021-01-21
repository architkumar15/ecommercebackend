using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ecommerceApplication.Model.SubCategoryModel
{
    public class updateSubcategorymodel
    {
        [Required]
        public string subcategoryName { get; set; }
        [Required]
        public int categoryId { get; set; }
    }
}
