using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeniaRealty.Models
{
    public class RealtyRentModel
    {
        public int RealtyRentModelId { get; set; }
        public string Area { get; set; }
        public string Type { get; set; }
        public string RoomsQuantity { get; set; }
        public double Square { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<PhotoRealtyRent> Photo { get; set; }
    }
}