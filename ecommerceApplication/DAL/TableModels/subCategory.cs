using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceApplication.DAL.TableModels
{
    public class subCategory : shared
    {
     [Required]
     [Key]
        public int subcategoryId { get; set; }
        [Required]
        public string subcategoryName { get; set; }
        [Required]
        public int categoryId { get; set; }

    }
    
}
