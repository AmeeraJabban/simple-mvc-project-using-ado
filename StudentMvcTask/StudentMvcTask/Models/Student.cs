using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMvcTask.Models
{
    public class Student
    {
        public int ID { get; set;}
        [Required]
        [Display(Name="Student First Name")]
        public string fname { get; set; }

        [Required]
        [Display(Name = "Student Middle Name")]
        public string mname { get; set; }

        [Required]
        [Display(Name = "Student Last Name")]
        public string lname { get; set; }

        [Required]
        [Display(Name = "Student Gender")]
        public int gender { get; set; }

        public bool Active { get; set; }


    }
}