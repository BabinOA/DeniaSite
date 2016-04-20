using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DeniaRealty.Models;
namespace DeniaRealty.Contexts
{
    public class DeniaRealtyContext:DbContext
    {
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<PhotoRealtyRent> PhotoRents { get; set; }
        public DbSet<PhotoRealtySells> PhotoSells { get; set; }
        public DbSet<RealtyRentModel> RealtyRents { get; set; }
        public DbSet<RealtySellsModel> RealtySells { get; set; }
        public DbSet<ServicesModel> Services { get; set; }
    }
}