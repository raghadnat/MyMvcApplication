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
        public List<Student> Get(int Skip, int PageSize)
        {
            var Result = StudentDAL.Get(Skip,PageSize);
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
