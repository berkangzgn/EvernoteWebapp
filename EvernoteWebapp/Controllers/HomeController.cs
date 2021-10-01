﻿using Evernote.BusinessLayer;
using Evernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EvernoteWebapp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
                // ByCategory altındaki retun içerisinde Index view'ın içinde category.Note nesnesini döndüreceği için alttaki TempData nesnesine de ihtiyacımız yok.
                // CategoryController üzerinden gelen view talebi

                // TempData["mm"] null değilse yönlenerek gelen bir istektir.
            //if (TempData["mm"] != null)
            //{
                    // TempData içerisindeki notları model olarak al
            //    return View(TempData["mm"] as List<EvernoteNote>);
            //}

            NoteManager nm = new NoteManager();
            return View(nm.GetAllNote());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                    // 404 gibi kodları döndürmemizi sağlıyor.
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryManager cm = new CategoryManager();
                // Id nullable tip'tir. Tip uyuşmazlığından kaynaklı hata veriyordu. Biz de bu yüzden .Value ekledik.
            EvernoteCategory category = cm.GetCategoryById(id.Value);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View("Index", category.Notes);

                // Eğer ByCategory metodu selectController atlında olsaydı alttaki TempData kodları da olmak zorunda olcaktı.

                // Farklı bir controller'dan bir başka controller'a erişim sağlamak ve model göndermemiz gerekiyor. Link'te selecek controller'ı istedik.
                // TempData bir action'dan bir başka action'a geçerken verileri öldürmüyor.
            //TempData["mm"] = category.Notes;
            //return RedirectToAction("Index", "Home");
        }
    }
}