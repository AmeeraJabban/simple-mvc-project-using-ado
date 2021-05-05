using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using sqlConnectionDAL;

namespace DAL
{
    public class StudentDAL : DbContext
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Student First Name")]
        public string fname { get; set; }

        [Required]
        [Display(Name = "Student Middle Name")]
        public string mname { get; set; }

        [Required]
        [Display(Name = "Student Last Name")]
        public string lname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Student Gender")]
        public int gender { get; set; }

        public bool Active { get; set; }


    }
 
    public class StudentsService
    {
        static ConnectionClassServer constsvc = new ConnectionClassServer();
        string CS = constsvc.getConnectionStrings("Students");
        public IList<StudentDAL> getAll()
        {
            string sql = $"select ID,fname,mname,lname,gender,Email " +
                        $"from tblStudents;";
            return constsvc.getAll<StudentDAL>(sql);
        }
        public StudentDAL getByID(int ID)
        {
            string sql = $"SELECT ID,fname,mname,lname,gender,Email " +
                         $" from tblStudents " +
                         $"where ID={ID}";

            return constsvc.getByID<StudentDAL>(ID, sql);
        }
        public void Add(StudentDAL std)
        {
            string sql = $"INSERT INTO tblStudents (fname,mname,lname,gender,Email) " +
                         $"VALUES({std.fname}, {std.mname},{std.lname}, {std.gender}, {std.Email})" +
                         $" Select @ID = SCOPE_IDENTITY()";
            constsvc.Add(sql);
        }
        public void Edit(StudentDAL std)
        {
            string sql = $"UPDATE tblStudents " +
                $"SET fname = {std.fname}," +
                $"mname ={std.mname}" +
                $",lname = { std.lname}," +
                $"gender ={ std.gender}," +
                $"Email = {std.Email}" +
                $" WHERE ID = {std.ID}; ";
            constsvc.Edit(sql);
        }
        public void Delete(int ID)
        {
            string sql = $"Delete from tblStudents " +
                $"where ID={ID};";
            constsvc.Delete(sql);
        }
        public IList<StudentDAL> Search(string searchName)
        {
            string sql = $"SELECT ID,fname,mname,lname,gender,Email" +
                $" from tblStudents " +
                $"WHERE fname LIKE '{searchName}%';";
            return constsvc.Search<StudentDAL>(sql);
        }
    }
}
