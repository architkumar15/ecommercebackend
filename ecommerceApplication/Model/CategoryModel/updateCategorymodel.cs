using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ecommerceApplication.Model.CategoryModel
{
    public class updateCategorymodel
    {
        [Required]
        public string categoryName { get; set; }
        [Required]
        public int registercompanyId { get; set; }
    }
}
