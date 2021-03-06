﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity.Context;
using DAL.Entity;

namespace DAL
{
    public class StudentDL
    {
        Context DbContext = new Context();
        public List<Student> Get(int Skip , int PageSize , string SearchString)
        {
            List<Student > Result;
            if (!String.IsNullOrEmpty(SearchString))
            {
                var StudentOrder = DbContext.students.OrderBy(std => std.StudentId).Skip(Skip).Take(PageSize);
                Result = StudentOrder.Where(s => s.fname.Contains(SearchString) || s.mname.Contains(SearchString)).ToList();
            }
            else {
                Result = DbContext.students.OrderBy(std => std.StudentId).Skip(Skip).Take(PageSize).ToList();
            }
            return Result;
        }
        public Student GetById(int Id)
        {
            return DbContext.students.Where(s => s.StudentId == Id).FirstOrDefault();
        }
        public List<Student> GetAll() {
            return DbContext.students.ToList();
        }
      
        public Student Add(Student std)
        {
            DbContext.students.Add(std);
            DbContext.SaveChanges();
            return std;
        }
        public Student Edit(Student std)
        {
            Student student = DbContext.students.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            student.fname = std.fname;
            student.mname = std.mname;
            student.lname = std.lname;
            student.Age = std.Age;
            student.gender = std.gender;
            student.Active = std.Active;
            student.CreationDate = std.CreationDate;
            DbContext.SaveChanges();
            return student;
        }
        public Student Delete(int Id)
        {
            var student = DbContext.students.Where(s => s.StudentId == Id).FirstOrDefault();
            DbContext.students.Remove(student);
            DbContext.SaveChanges();
            return student;
        }
        public Student AddClass(int StudentID , int ID ) {
            var Class = DbContext.Classes.Where(x => x.ID == ID).FirstOrDefault();
            var Result = DbContext.students.Include("Classes").FirstOrDefault(s => s.StudentId == StudentID); 
            Result.Classes.Add(Class);
            DbContext.SaveChanges();
            return Result;
        }
        public List<Classes> getclass(int id) {
            var result = DbContext.students.Include("Classes").FirstOrDefault(s => s.StudentId == id);
            List<Classes> list = result.Classes.ToList();
            return list;
        }
        public Classes DeleteClass(int id,int ClassID) {
            var student = DbContext.students.Include("Classes").FirstOrDefault(s => s.StudentId == id);
            var studentclass = student.Classes.Where(x => x.ID == ClassID).FirstOrDefault();
            student.Classes.Remove(studentclass);
            DbContext.SaveChanges();
            return studentclass;
        }



    }
}
