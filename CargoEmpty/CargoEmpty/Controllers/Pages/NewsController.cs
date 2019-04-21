using CargoEmpty.Context;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.News;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Pages
{
    public class NewsController : Controller
    {
        private CargoDbContext db = new CargoDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.News.OrderByDescending(o => o.NewsCreateDate).ToListAsync());
        }




        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var DetailsNews = await db.News.FirstOrDefaultAsync(f => f.Id == id);
                if (DetailsNews == null)
                {
                    return HttpNotFound();

                }
                else
                {
                    return View(DetailsNews);
                }
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]


        public async Task<ActionResult> Create(NewsDbModel createNews)
        {

            if (ModelState.IsValid)
            {
                if (createNews.NewsImg != null && createNews.NewsImg.ContentLength > 0)
                {
                    var ImgNewName = ProsesImageFile.FileName(createNews.NewsImg);
                    var ImgsavedPath = ProsesImageFile.ImagePath(ImgNewName, "/Image/News");
                    createNews.NewsImg.SaveAs(ImgsavedPath);

                    if (createNews.NewsCreateDate == null)
                    {
                        createNews.NewsCreateDate = DateTime.Now;
                    }
 
                    createNews.IsActive = Convert.ToBoolean(createNews.Activ);//????
                    createNews.ImagePath = "/Image/News/" + ImgNewName;
                    db.News.Add(createNews);
                    await  db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return HttpNotFound();

            }
            else
            {
                return View(createNews);
            }

        }

        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var EditNews = db.News.FirstOrDefault(f => f.Id == id);
                if (EditNews == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(EditNews);
                }

            }


        }


        [HttpPost]
        [ValidateInput(false)]

        public async Task<ActionResult> Edit(NewsDbModel EditNews)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var EditNewsDb = await db.News.FirstOrDefaultAsync(f => f.Id == EditNews.Id);
                    if (EditNewsDb == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        EditNews.IsActive = Convert.ToBoolean(EditNews.Activ);//????
                        if (EditNews.NewsRefreshDate == null)
                        {
                            EditNews.NewsRefreshDate = DateTime.Now;
                        }
                        if (EditNews.NewsImg != null && EditNews.NewsImg.ContentLength > 0)
                        {

                            EditNews.SaveImageFile(EditNews.NewsImg, "/Image/News");
                            ViewModelChangeDbModel<NewsDbModel, NewsDbModel> nw = new ViewModelChangeDbModel<NewsDbModel, NewsDbModel>();
                            nw.ViewFromDb(EditNews, EditNewsDb, "NewsCreateDate");
                            await db.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewModelChangeDbModel<NewsDbModel, NewsDbModel> nw = new ViewModelChangeDbModel<NewsDbModel, NewsDbModel>();
                            nw.ViewFromDb(EditNews, EditNewsDb, "NewsCreateDate");
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
                return HttpNotFound();
            }
            catch
            {
                return HttpNotFound();
            }
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////
        /// </summary>
       
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            var delete = db.News.FirstOrDefault(f => f.Id == Id);
            return PartialView(delete);
        }

        public ActionResult DeletePost(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var DeleteNews = db.News.FirstOrDefault(f => f.Id == Id);

                if (DeleteNews == null)
                {
                    return HttpNotFound();

                }
                else
                {

                    var imgName = Path.GetFileName(DeleteNews.ImagePath);
                    var imgPath = ProsesImageFile.ImagePath(imgName, "/Image/Carusel");
                    ProsesImageFile.DeleteImageFile(imgPath);

                    db.News.Remove(DeleteNews);
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
                    var ChangeStatusNews = db.News.FirstOrDefault(f => f.Id == i.id);
                    if (ChangeStatusNews != null)
                    {
                        if (i.status == "Activ")
                        {
                            ChangeStatusNews.IsActive = true;

                        }
                        else
                        {
                            ChangeStatusNews.IsActive = false;

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