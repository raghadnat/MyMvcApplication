using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCApplication.Models
{
    public class AssignClassViewModel
    {
        public String fname { set; get; }
        public String mname { set; get; }
        public String lname { set; get; }
        public int Age { get; set; }
        public gender gender { set; get; }
        public bool Active { set; get; }
        public DateTime CreationDate { get; set; }

        public List<Classes> Classes { set; get; }
    }

    public enum gender
    {
        male,
        female
    }
}