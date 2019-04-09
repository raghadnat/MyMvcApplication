using BLL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApplication.Controllers
{
    public class ClassesController : Controller
    {
        ClassesService ClassSVC = new ClassesService();
        // GET: Classes
        public ActionResult Index()
        {
            var Result = ClassSVC.Get();
            return View(Result);
        }
        public ActionResult Edit(int Id)
        {
            var Result = ClassSVC.GetById(Id);
            return View(Result);
        }
        [HttpPost]
        public ActionResult Edit(Classes Class)
        {
            var Result = ClassSVC.Edit(Class);
            return RedirectToAction("Index");
        }
    }
}