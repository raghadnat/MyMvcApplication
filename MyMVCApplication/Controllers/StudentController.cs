using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVCApplication.Models;
using System.Web.Mvc;

namespace MyMVCApplication.Controllers
{

    public class StudentController : Controller
    {
        
        // GET: Student
        public ActionResult Index()
        {
            return View(Student.students);
        }

        public ActionResult Edit(int? Id)
        {
            Student student;
            if (Id == null)
            {
                student = new Student();
                
            }
            else
            {
                student = Student.students.Where(s => s.StudentId == Id).FirstOrDefault();
                
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student std ,int? Id)
        {
            Student student ;

            if (Id == null)
            {
                student = new Student();
                student.StudentName = std.StudentName;
                student.Age = std.Age;
                
                Student.students.Add(student);
            }
            else {

                student = Student.students.Where(s => s.StudentId == Id).FirstOrDefault();
                student.StudentName = std.StudentName;
                student.Age = std.Age;
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int Id) {
            Student student = Student.students.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(student); 
        }

        [HttpPost]
        public ActionResult Delete(Student std) {

            var student = Student.students.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            Student.students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}