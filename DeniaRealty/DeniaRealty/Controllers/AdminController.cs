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
    public class AdminController : Controller
    {
        DeniaRealtyContext db = new DeniaRealtyContext();
        // первая страница со ссылками на подразделы базы данных
        public ActionResult Index()
        {
            return View("Index");
        }

       
    }
}