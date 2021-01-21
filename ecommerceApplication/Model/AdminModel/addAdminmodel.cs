using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ecommerceApplication.Model.admin
{
    public class addAdminmodel
    {[Required]
        public int superAdminId { get; set; }
        [Required]
        public string superAdminemail { get; set; }
        [Required]
        public string superAdminname { get; set; }
        [Required]
        public string superAdminusername { get; set; }
        [Required]
        public string superAdminPassword { get; set; }
    }
}
