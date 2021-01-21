using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ecommerceApplication.Model
{
    public class ReturnModel
    {
        [Required]
        public string message { get; set; }
        [Required]
        public HttpStatusCode statusCode { get; set; }
        [Required]
        public dynamic responce { get; set; }
    }
}
