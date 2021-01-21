using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Threading.Tasks;

namespace ecommerceApplication.Model.CategoryModel
{
    public class addCategorymodel
    {
        [Required]
        public string categoryName { get; set; }
        [Required]
        public int registercompanyId { get; set; }
    }
}
