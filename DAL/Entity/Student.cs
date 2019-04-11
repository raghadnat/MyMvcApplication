using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
   public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public String fname { set; get; }
        public String mname { set; get; }
        public String lname { set; get; }
        public DateTime DOB { get; set; }
        public String email { set; get; }
        public bool Active { set; get; }
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { set; get; }
        public int Age { get; set; }
        public gender gender { set; get; }
        public ContactInfo contactInfo { set; get; }
        public ICollection<Classes> Classes { get; set; }


    }
    public enum gender
    {
        male,
        female
    }
    public class ContactInfo
    {
        public String City { set; get; }
        public String Country { set; get; }
        public int ZipCode { set; get; }

    }
}
