using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassesService
    {

        ClassesDL StudentDAL = new ClassesDL();
        public List<Classes> Get()
        {
            var Result = StudentDAL.Get();
            return Result;
        }
        public Classes GetById(int Id)
        {
            return StudentDAL.GetById(Id);
        }
        public Classes Add(Classes Class)
        {
            var Result = StudentDAL.Add(Class);
            return Result;
        }
        public Classes Edit(Classes Class)
        {
            var Result = StudentDAL.Edit(Class);
            return Result;
        }
        public Classes Delete(int Id)
        {
            var Result = StudentDAL.Delete(Id);
            return Result;
        }
    }
}
