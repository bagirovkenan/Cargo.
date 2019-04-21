using CargoEmpty.Context;
using CargoEmpty.Controllers.Pages;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages;
using CargoEmpty.Models.Pages.Carusel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.PageController
{
    public class CaruselController : Controller
    {
        private CargoDbContext db = new CargoDbContext();

        // GET: Carusel
        public async Task<ActionResult> Index()
        {
            return View(await db.Carusels.ToListAsync());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var Carusel = db.Carusels.Find(id);
                if (Carusel == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return Json(Carusel, JsonRequestBehavior.AllowGet);
                }
            }
        }

        //public ActionResult Create()
        //{
        //    return PartialView("Create");
        //}
        [HttpPost]
        public ActionResult Create(CaruselView NewCarusel)
        {
            if (ModelState.IsValid)
            {
                CaruselDb newDbCarusel = new CaruselDb();

                var imgName = ProsesImageFile.FileName(NewCarusel.File);
                var imgPath = ProsesImageFile.ImagePath(imgName, "/Image/Carusel");
                NewCarusel.File.SaveAs(imgPath);

                newDbCarusel.Text = NewCarusel.Text;
                newDbCarusel.Title = NewCarusel.Title;
                newDbCarusel.IsActive = false;
                newDbCarusel.ImagePath = "/Image/Carusel/" + imgName;
                db.Carusels.Add(newDbCarusel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(CaruselView EditCarusel)
        {
            if (ModelState.IsValid)
            {
                var EditCaruselDb = db.Carusels.FirstOrDefault(f => f.Id == EditCarusel.Id);
                if (EditCaruselDb == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var imgName = ProsesImageFile.FileName(EditCarusel.File);
                    var imgPath = ProsesImageFile.ImagePath(imgName, "/Image/Carusel");
                    var imgasName = Path.GetFileName(imgPath);
                    EditCarusel.File.SaveAs(imgPath);

                    EditCaruselDb.Text = EditCarusel.Text;
                    EditCaruselDb.Title = EditCarusel.Title;
                    EditCaruselDb.IsActive = EditCarusel.IsActive;
                    EditCaruselDb.ImagePath = "/Image/Carusel/" + imgName;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var DeleteCarusel = db.Carusels.FirstOrDefault(f => f.Id == Id);

                if (DeleteCarusel == null)
                {
                    return HttpNotFound();

                }
                else
                {

                    var imgName = Path.GetFileName(DeleteCarusel.ImagePath);
                    var imgPath = ProsesImageFile.ImagePath(imgName, "/Image/Carusel");
                    ProsesImageFile.DeleteImageFile(imgPath);

                    db.Carusels.Remove(DeleteCarusel);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }

        }


        [HttpPost]
        public ActionResult IsActive(ChangeActivStatus[] id)
        {
            if (id == null || id.Length == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {

         
            foreach (var i in id)
            {
                var ChangeStatusCarusel = db.Carusels.FirstOrDefault(f => f.Id == i.id);
                if (ChangeStatusCarusel!=null)
                {
                    if (i.status=="Activ")
                    {
                        ChangeStatusCarusel.IsActive = true;
                    }
                    else
                    {
                        ChangeStatusCarusel.IsActive = false;
                    }
                }
                    else
                    {
                        return HttpNotFound();
                    }
               
            }
            }
            db.SaveChanges();
            return Json(new { success = true, responseText = "Emeliyyat Ugurlu Oldu !" }, JsonRequestBehavior.AllowGet);

        }

    }
}
