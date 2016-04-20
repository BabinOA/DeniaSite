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
    public class AdminSellController : Controller
    {
        DeniaRealtyContext db = new DeniaRealtyContext();
        // GET: AdminSell
        //весь список недвижимости
        public ActionResult IndexSell()
        {
            var Sells = db.RealtySells.ToList();
            return View(Sells);
        }

        //создаем новый объект недвижимости с добавлением фото и удалением фото(реализовано в методах AddPhoto и DeletePhoto)
        //в представлении при реализации формы отправки нужно создать скрытое поле для передачи параметра в метод AddPhoto
        public ActionResult CreateSell()
        {
            return View("CreateSell", new RealtySellsModel());
        }

        [HttpPost]
        public ActionResult CreateSell(RealtySellsModel realtySell)
        {
           
            db.RealtySells.Add(realtySell);         
            db.SaveChanges();
            return View("AddPhoto",realtySell);
        }
        //вспомогательный метод для добавления фото
       [HttpPost]
        public ActionResult AddPhoto(int id, HttpPostedFileBase image, RealtySellsModel realtySells)
        {
           realtySells = db.RealtySells.Find(id);
            PhotoRealtySells photo = new PhotoRealtySells();
            photo.RealtySellsModelId = realtySells.RealtySellsModelId;
            if (image != null)
            {
                photo.PhotoType = image.ContentType;
                photo.PhotoData = new byte[image.ContentLength];
                image.InputStream.Read(photo.PhotoData, 0, image.ContentLength);
                db.PhotoSells.Add(photo);
                db.SaveChanges();
                return View("AddPhoto",realtySells);
            }
            else
            {
                ModelState.AddModelError("", "Нет такой фотографии");
                return View("AddPhoto",realtySells);
            }
        }

        //редактирование объекта
        public ActionResult EditSell(int id)
        {
            RealtySellsModel realtySells = db.RealtySells.Find(id);
            return View("AddPhoto", realtySells);
        }

        [HttpPost]
        public ActionResult EditSell(RealtySellsModel realtySells)
        {
            db.Entry(realtySells).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexSell");
        }
            
        //удаление объекта недвижимости с прикрепленными фото
        public ActionResult DeleteSell(int id)
        {
            RealtySellsModel realtySell = db.RealtySells.Include(o=>o.Photo).FirstOrDefault(p=>p.RealtySellsModelId==id);
            return View("DeleteSell", realtySell);
        }

        [HttpPost, ActionName("DeleteSell")]
        public ActionResult DeleteConfirmed(int id)
        {
            RealtySellsModel realtySell = db.RealtySells.Include(o => o.Photo).FirstOrDefault(p => p.RealtySellsModelId == id);
            db.RealtySells.Remove(realtySell);
            db.SaveChanges();
            return RedirectToAction("IndexSell");
        }

       

        //вспомогательный метод для отображения фото в представлениях
        public FileContentResult GetPhoto(int id)
        {
            PhotoRealtySells photo = db.PhotoSells.Find(id);
            if(photo!=null)
            {
                return File(photo.PhotoData, photo.PhotoType);
            }
            else
            {
                return null;
            }
        }

       

        //вспомогательный метод для удаления фото
        //параметр для метода AddPhoto передаем через скрытое поле
        [HttpPost]
        public ActionResult DeletePhoto(int id)
        {
            PhotoRealtySells photo = db.PhotoSells.Find(id);
           
            if(photo!=null)
            {
                RealtySellsModel realtySells = db.RealtySells.FirstOrDefault(p => p.RealtySellsModelId == photo.RealtySellsModelId);
                db.PhotoSells.Remove(photo);
                db.SaveChanges();
                return View("AddPhoto", realtySells);
            }
            else
            {
                ModelState.AddModelError("", "Вы не выбрали фото для удаления");
                return View();
            }
        }
    }
}