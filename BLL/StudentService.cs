using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;

namespace BLL
{
    public class StudentService
    {


        StudentDL StudentDAL = new StudentDL();
        public List<Student> Get(int Skip, int PageSize,String SearchString)
        {
           var  Result = StudentDAL.Get(Skip, PageSize, SearchString);
           return Result;
        }
        public List<Student> GetAll() {

            return StudentDAL.GetAll();
        }
        public Student GetById(int Id)
        {
            return StudentDAL.GetById(Id);
        }
        public Student Add(Student std)
        {
            bool nameAlreadyExists = StudentDAL.GetAll().Exists(x => x.fname == std.fname && x.mname == std.mname && x.lname == std.lname && x.StudentId != std.StudentId);

            var Result = StudentDAL.Add(std);
            return Result;
        }
        public Student Edit(Student std)
        {
            var Result = StudentDAL.Edit(std);
            return Result;
        }
        public Student Delete(int Id)
        {
            var Result = StudentDAL.Delete(Id);
            return Result;
        }
        public bool NameAlreadyExist(Student std) {
            bool nameAlreadyExists = StudentDAL.GetAll().Exists(x => x.fname == std.fname && x.mname == std.mname && x.lname == std.lname && x.StudentId != std.StudentId);
            return nameAlreadyExists;
        }
        public Student AddClass(int StudentID, int ID) {
            return StudentDAL.AddClass(StudentID, ID);
        }
        public List<Classes> getclass(int id) {
            return StudentDAL.getclass(id);
        }
        public Classes DeleteClass(int id , int ClassId){
            return StudentDAL.DeleteClass(id, ClassId);
        }
    }
}
