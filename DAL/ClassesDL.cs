using DAL.Entity;
using DAL.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClassesDL
    {
        Context DbContext = new Context();
        public List<Classes> Get()
        {

            return DbContext.Classes.ToList();
        }
        public Classes GetById(int Id)
        {
            return DbContext.Classes.Where(c => c.ID == Id).FirstOrDefault();
        }
        public Classes Add(Classes Class)
        {
            DbContext.Classes.Add(Class);
            DbContext.SaveChanges();
            return Class;
        }
        public Classes Edit(Classes Class)
        {
            Classes classes = DbContext.Classes.Where(c => c.ID == Class.ID).FirstOrDefault();
            classes.Name = Class.Name;
            classes.StartTime= Class.StartTime;
            classes.EndTime = Class.EndTime;
            DbContext.SaveChanges();
            return classes;
        }
        public Classes Delete(int Id)
        {
            var Class = DbContext.Classes.Where(c => c.ID == Id).FirstOrDefault();
            DbContext.Classes.Remove(Class);
            DbContext.SaveChanges();
            return Class;
        }

    }
}
