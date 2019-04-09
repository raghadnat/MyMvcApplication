using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Teacher
    {
        public int ID { set; get; }
        public String Name { set; get; }
        public Specialty Specialty { set; get; }
        public ICollection<Classes> Classes { get; set; }

    }
    public enum Specialty {
        General ,
        Science,
        Music,
        Literal

    }
}
