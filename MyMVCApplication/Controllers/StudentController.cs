using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using DAL.Entity;
using MyMVCApplication.Models;

namespace MyMVCApplication.Controllers
{
    [Log]
    public class StudentController : Controller
    {
        StudentService StudentSVC = new StudentService();
        ClassesService ClassesSVC = new ClassesService();
        // GET: Student

        public ActionResult Index(int page =1)
        {
            StudentViewModel Model = new StudentViewModel();
            int PageSize = 3;
            int Skip = (page * PageSize) - PageSize;
            Model.Students = StudentSVC.Get(Skip, PageSize);
            Model.Classes = ClassesSVC.Get();
            ViewBag.Count = StudentSVC.GetAll().Count();
            ViewBag.TotalPage = (ViewBag.Count / PageSize) + ((ViewBag.Count % PageSize) > 0 ? 1 : 0);
            return View(Model);
        }

        public ActionResult Edit(int? Id)
        {
            Student student;
            if (Id == null)
            {
                student  = new Student();
            }
            else
            {
                student = StudentSVC.GetById(Id.Value);
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            Student student;
            if (ModelState.IsValid)
            {
                var students = StudentSVC.GetAll();
                bool nameAlreadyExists = students.Exists(x => x.fname == std.fname && x.mname == std.mname && x.lname == std.lname && x.StudentId != std.StudentId);
                if (nameAlreadyExists  ) {
                    ModelState.AddModelError(String.Empty, "Student Name already exist");
                    return View(std);
                }
                if (std.StudentId == 0)
                {
                    //generate Id 
                    StudentSVC.Add(std);
                }
                else
                {
                    StudentSVC.Edit(std);
                }
                return RedirectToAction("Index");
            }
            else {
                return View(std);
            }
        }
        
        public ActionResult Delete(int Id) {
            var result = StudentSVC.GetById(Id);
            return View(result); 
        }

        [HttpPost]
        public ActionResult Delete(Student std) {
            StudentSVC.Delete(std.StudentId);
            return RedirectToAction("Index");
        }

        public ActionResult testLayout() {
            return View();
        }
        public ActionResult Details(int Id)
        {
            var result = StudentSVC.GetById(Id);
            return View(result);
        }
        public ActionResult AssignStudentToClass() {
            return PartialView();
        }
    }
}