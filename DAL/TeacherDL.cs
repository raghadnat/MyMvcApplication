using DAL.Entity;
using DAL.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class TeacherDL
    {
        Context DbContext = new Context();
        public List<Teacher> Get()
        {

            return DbContext.Teachers.ToList();
        }
        public Teacher GetById(int Id)
        {
            return DbContext.Teachers.Where(c => c.ID == Id).FirstOrDefault();
        }
        public Teacher Add(Teacher teacher)
        {
            DbContext.Teachers.Add(teacher);
            DbContext.SaveChanges();
            return teacher;
        }
        public Teacher Edit(Teacher teacher)
        {
            Teacher Teacher = DbContext.Teachers.Where(c => c.ID == teacher.ID).FirstOrDefault();
            Teacher.Name = teacher.Name;
            Teacher.Specialty = teacher.Specialty;
            DbContext.SaveChanges();
            return Teacher;
        }
        public Teacher Delete(int Id)
        {
            var teacher = DbContext.Teachers.Where(c => c.ID == Id).FirstOrDefault();
            DbContext.Teachers.Remove(teacher);
            DbContext.SaveChanges();
            return teacher;
        }
    }
}
