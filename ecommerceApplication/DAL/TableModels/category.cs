using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace ecommerceApplication.DAL.TableModels
{
    public class category:shared
    {
        [Required]
        [Key]
        public int categoryId { get; set; }
        [Required]
        public string categoryName { get; set; }
        [Required]
        public int registercompanyId { get; set; }

    }
}
