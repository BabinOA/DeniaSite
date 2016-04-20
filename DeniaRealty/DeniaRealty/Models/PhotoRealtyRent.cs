using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeniaRealty.Models
{
    public class PhotoRealtyRent
    {
        public int PhotoRealtyRentId { get; set; }
        public string PhotoType { get; set; }
        public byte[] PhotoData { get; set; }
        public int RealtyRentModelId { get; set; }
    }
}