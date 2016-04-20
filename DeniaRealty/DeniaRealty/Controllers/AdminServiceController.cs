using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DeniaRealty.Contexts;
using DeniaRealty.Models;
namespace DeniaRealty.Controllers
{
    public class AdminServiceController : Controller
    {
        DeniaRealtyContext db = new DeniaRealtyContext();
        // GET: AdminService
        public ActionResult IndexService()
        {
            var Services = db.Services.ToList();
            return View(Services); 
        }
    }
}