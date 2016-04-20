using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeniaRealty.Models
{
    public class ServicesModel
    {
        public int ServicesModelId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}