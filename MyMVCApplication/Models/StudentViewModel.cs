using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCApplication.Models
{
    public class StudentViewModel
    {
        public List<Classes> Classes { get; set; }
        public List<Student> Students { get; set; }
        
    }
}