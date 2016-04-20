using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DeniaRealty.Models;
using DeniaRealty.Contexts;
namespace DeniaRealty.Controllers
{
    public class AdminRentController : Controller
    {
        DeniaRealtyContext db = new DeniaRealtyContext();
        // GET: AdminRent
        public ActionResult IndexRent()
        {
            var Rents = db.RealtyRents.ToList();
            return View(Rents);
        }
    }
}