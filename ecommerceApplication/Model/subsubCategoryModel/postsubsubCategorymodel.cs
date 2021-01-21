using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ecommerceApplication.Model.subsubCategoryModel
{
    public class postsubsubCategorymodel
    {
        [Required]
        public string subsubcategoryName { get; set; }
        [Required]
        public int subcategoryId { get; set; }
        [Required]
        public bool showsubcategory { get; set; }
    }
}
