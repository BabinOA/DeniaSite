using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DeniaRealty.Models
{
    public class RealtySellsModel
    {
        public int RealtySellsModelId { get; set; }

        [DisplayName("Город")]
        public string Area { get; set; }

        [DisplayName("Тип недвижимости")]
        public string Type { get; set; }

        [DisplayName("Колличество комнат")]
        public  string RoomsQuantity { get; set; }

        [DisplayName("Общая площадь")]
        public double Square { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Описание объекта")]
        public string Description { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
       public virtual ICollection<PhotoRealtySells> Photo { get; set; }
    }
}