using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMvcTask.Models
{
    public class StudentIndexVm
    {
        public IList<DAL.StudentDAL> Students { get; set; }
        public string totalOfStudents { get; set; }
    }
}