using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ecommerceApplication.Model.seller
{
    public class addSellermodel
    {
        public char registercompnyName { get; set; }
        [Required]

        public string registercompanyEmail { get; set; }
        [Required]

        public string registercompanyMNo { get; set; }
        [Required]

        public char registerOwnername { get; set; }
        [Required]

        public char registercompanyTitle { get; set; }
        [Required]

        public char registercompanyAddress { get; set; }
    }
}
