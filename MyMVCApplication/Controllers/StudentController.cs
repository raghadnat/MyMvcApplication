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
            return View(studentlist.students);
        }

        public ActionResult Edit(int? Id)
        {
            var st = studentlist.students.Where(s => s.StudentId == Id).FirstOrDefault();

            return View(st);
        }

        [HttpPost]
        public ActionResult Edit(Student std ,int? Id)
        {
            Student st = new Student();

            if (Id == null)
            {
                st.StudentName = std.StudentName;
                st.Age = std.Age;
                st.StudentId = 3;
                studentlist.students.Add(st);
            }
            else {

                var stt = studentlist.students.Where(s => s.StudentId == Id).FirstOrDefault();
                stt.StudentName = std.StudentName;
                stt.Age = std.Age;
            }
            return RedirectToAction("Index", st);
        }
    }
}