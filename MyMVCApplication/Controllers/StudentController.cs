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

        public ActionResult Index(string SearchString ,int page =1)
        {
            StudentViewModel Model = new StudentViewModel();
            int PageSize = 3;
            int Skip = (page * PageSize) - PageSize;
            ViewBag.CurrentFilter = SearchString;
            ViewBag.Count = StudentSVC.GetAll().Count();
            ViewBag.TotalPage = (ViewBag.Count / PageSize) + ((ViewBag.Count % PageSize) > 0 ? 1 : 0);
            Model.Students = StudentSVC.Get(Skip, PageSize, SearchString);
            Model.Classes = ClassesSVC.Get();
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
                bool nameAlreadyExists = StudentSVC.NameAlreadyExist(std);
                if (nameAlreadyExists  ) {
                    ModelState.AddModelError(String.Empty, "Student Name already exist");
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
        public ActionResult AssignStudentToClass(int Id) {
            AssignClassViewModel model = new AssignClassViewModel();
            var Result = StudentSVC.GetById(Id);
            model.StudentId = Result.StudentId;
            model.fname = Result.fname;
            model.mname = Result.mname;
            model.lname = Result.lname;
            model.gender = Result.gender;
            model.Age = Result.Age;
            model.Active = Result.Active;
            model.CreationDate = Result.CreationDate;
            model.Classes = ClassesSVC.Get();
            model.StudentClasses = StudentSVC.getclass(Id);
            return PartialView(model);
        }
        public ActionResult AddStudentClass(int Id , int ClassID) {
            StudentSVC.AddClass(Id, ClassID);
            return RedirectToAction("AssignStudentToClass", new { Id = Id });
        }
        public ActionResult DeleteStudentClass(int Id, int ClassID) {
            StudentSVC.DeleteClass(Id, ClassID);
            
            return RedirectToAction("AssignStudentToClass", new { Id = Id });
        }
       
    }
}