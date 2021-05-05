using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentsBLL
    {
        public StudentsService StudentsSVC =new StudentsService();
        public IList<StudentDAL> getAll()
        {
            return StudentsSVC.getAll();
        }
        public StudentDAL getByID(int ID)
        {
            return StudentsSVC.getByID(ID);
        }
        public void Add(StudentDAL std)
        {
            StudentsSVC.Add(std);
        }
        public void Edit(StudentDAL std)
        {
            StudentsSVC.Edit(std);
        }
        public void Delete(int ID)
        {
            StudentsSVC.Delete(ID);
        }
        public IList<StudentDAL> Search(string searchName)
        {
            return StudentsSVC.Search(searchName);
        }
    }
}
