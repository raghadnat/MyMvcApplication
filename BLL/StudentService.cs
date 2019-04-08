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
        public List<Student> Get()
        {
            var Result = StudentDAL.Get();
            return Result;
        }
        public Student GetById(int Id)
        {
            return StudentDAL.GetById(Id);
        }
        public Student Add(Student std)
        {
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

    }
}
