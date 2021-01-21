using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ecommerceApplication.DAL.TableModels
{
    public class subsubCategory:shared
    {
        [Required]
        [Key]
        public int subsubcategoryId { get;set;}
        [Required]
        public string subsubcategoryName { get;set;}
        [Required]
        public int subcategoryId { get; set; }
        [Required]
        public bool showsubcategory { get; set; }
    }
}
