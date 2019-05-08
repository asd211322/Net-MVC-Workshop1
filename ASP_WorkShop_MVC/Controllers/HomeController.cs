using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_WorkShop_MVC.Models;

namespace ASP_WorkShop_MVC.Controllers
{
    public class HomeController : Controller
    {
        dbBookEntities db = new dbBookEntities();
        // GET: Home
        public ActionResult Index()
        {
            var bookdata = db.BOOK_DATA.OrderBy(m => m.BOOK_BOUGHT_DATE).ToList();
            return View(bookdata);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(BOOK_DATA vBOOKDATA)
        {
            db.BOOK_DATA.Add(vBOOKDATA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int bookid)
        {
            var bookdataD = db.BOOK_DATA.Where(m => m.BOOK_ID == bookid).FirstOrDefault();
            db.BOOK_DATA.Remove(bookdataD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int bookid)
        {
            var bookdataE = db.BOOK_DATA.Where(m => m.BOOK_ID == bookid).FirstOrDefault();
            return View(bookdataE);
        }
        [HttpPost]

        public ActionResult Edit(BOOK_DATA vBOOKDATA)
        {
            int bookid = vBOOKDATA.BOOK_ID;
            var bookdataE = db.BOOK_DATA.Where(m => m.BOOK_ID == bookid).FirstOrDefault();
            bookdataE.BOOK_AUTHOR = vBOOKDATA.BOOK_AUTHOR;
            bookdataE.BOOK_BOUGHT_DATE = vBOOKDATA.BOOK_BOUGHT_DATE;
            bookdataE.BOOK_CLASS = vBOOKDATA.BOOK_CLASS;
            bookdataE.BOOK_KEEPER = vBOOKDATA.BOOK_KEEPER;
            bookdataE.BOOK_NAME = vBOOKDATA.BOOK_NAME;
            bookdataE.BOOK_NOTE = vBOOKDATA.BOOK_NOTE;
            bookdataE.BOOK_PUBLISHER = vBOOKDATA.BOOK_PUBLISHER;
            bookdataE.BOOK_STATUS = vBOOKDATA.BOOK_STATUS;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}