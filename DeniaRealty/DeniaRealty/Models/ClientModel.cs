using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeniaRealty.Models
{
    public class ClientModel
    {
        public int  ClientModelId { get; set; }
        public string FIO { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
    }
}