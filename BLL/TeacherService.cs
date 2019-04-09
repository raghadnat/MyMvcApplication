using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class TeacherService
    {
        TeacherDL TeacherDal = new TeacherDL();
        public List<Teacher> Get()
        {
            var Result = TeacherDal.Get();
            return Result;
        }
        public Teacher GetById(int Id)
        {
            return TeacherDal.GetById(Id);
        }
        public Teacher Add(Teacher teacher)
        {
            var Result = TeacherDal.Add(teacher);
            return Result;
        }
        public Teacher Edit(Teacher teacher)
        {
            var Result = TeacherDal.Edit(teacher);
            return Result;
        }
        public Teacher Delete(int Id)
        {
            var Result = TeacherDal.Delete(Id);
            return Result;
        }

    }
}
