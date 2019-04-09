using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Classes
    {
        [Key]
        public int ID { set; get; }
        public String Name { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public int TeacherID { set; get; }
        public Teacher  Teacher { set; get; }

    }
}
