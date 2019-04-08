using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using DAL.Entity;

namespace MyMVCApplication.Controllers
{
    [Log]
    public class StudentController : Controller
    {
        StudentService StudentSVC = new StudentService();
        // GET: Student

        public ActionResult Index()
        {
            var Students = StudentSVC.Get();
            ViewBag.Count = Students.Count();
            return View(Students);
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
                var students = StudentSVC.Get();
                /*bool nameAlreadyExists = students.Exists(x => x.StudentName == std.fname && x.StudentId != std.StudentId);
                if (nameAlreadyExists  ) {
                    ModelState.AddModelError(String.Empty, "Student Name already exist");
                    return View(std);
                }*/
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

    }
}