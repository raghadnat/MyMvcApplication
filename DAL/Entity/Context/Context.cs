using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL.Entity.Context
{
    class Context : DbContext
    {
        public Context() : base()
        {

        }

        public DbSet<Student> students { get; set; }

    }

}

