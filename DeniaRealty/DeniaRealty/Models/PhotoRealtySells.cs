using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeniaRealty.Models
{
    public class PhotoRealtySells
    {
        public int PhotoRealtySellsId { get; set; }
        public string PhotoType { get; set; }
        public byte[] PhotoData { get; set; }
        public int RealtySellsModelId { get; set; }

    }
}