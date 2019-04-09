using BLL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApplication.Controllers
{
    public class TeacherController : Controller
    {
        TeacherService TeacherSVC = new TeacherService();
        // GET: Teacher
        public ActionResult Index()
        {
            var Result = TeacherSVC.Get();
            return View(Result);
        }
        public ActionResult Edit(int Id )
        {
            var Result = TeacherSVC.GetById(Id);
            return View(Result);
        }
        [HttpPost]
        public ActionResult Edit(Teacher teacher )
        {
            var Result = TeacherSVC.Edit(teacher);
            return RedirectToAction("Index");
        }
    }
}