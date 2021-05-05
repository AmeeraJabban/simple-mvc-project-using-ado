using StudentMvcTask.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentMvcTask.Models.VMS;
using System.Data.SqlClient;

namespace StudentMvcTask.Controllers
{
    public class StudentController : Controller
    {
        public StudentsBLL bll = new StudentsBLL();    //bll
        public DAL.StudentDAL Student = new DAL.StudentDAL();   //dal
        // GET: Student
        public ActionResult Index(string searchName, int? page)
        {
            //if (page == null)
            //{
            //    page = 1;
            //}
            IList<DAL.StudentDAL> AllStudent = bll.getAll();
            //ViewBag.pages = bll.getAll().Count() / 2;
            //if (page != null)
            //{
            //    int firsrStdList = (int)page - 1 + ((int)page) - 1;
            //    AllStudent.Add(bll.getAll().ElementAt(firsrStdList));
            //    AllStudent.Add(bll.getAll().ElementAt(firsrStdList + 1));
            //};
            if (searchName != null)
            {
               AllStudent = bll.Search(searchName);
            }
            return View(AllStudent);
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            Student = bll.getByID(ID);
            return View(Student);
        }
        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            if (ID != null)
            {
                int _id = (Int32)ID;
                Student = bll.getByID(_id);
            }
            return View(Student);
        }
        [HttpPost]
        public ActionResult Edit(DAL.StudentDAL std)
        {
            if (ModelState.IsValid)
            {
                Student = bll.getByID(std.ID);
                DAL.StudentDAL nameAlreadyExists = new DAL.StudentDAL();
                nameAlreadyExists = bll.getAll().Where(s => s.fname == std.fname).FirstOrDefault();
                if (std != null)
                {
                    if ((nameAlreadyExists != null) && (Student.ID != nameAlreadyExists.ID))
                    {
                        ModelState.AddModelError("fname", "Student Name Already Exists.");
                    }
                    else
                    {
                        bll.Edit(std);
                    }

                }
                else
                {
                    if (nameAlreadyExists != null)
                    {
                        ModelState.AddModelError("fname", "Student Name Already Exists.");
                    }
                    else
                    {
                        bll.Add(Student);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(std);
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Student = bll.getByID(ID);
            return View(Student);
        }
        [HttpPost]
        public ActionResult Delete(DAL.StudentDAL std)
        {
            bll.Delete(std.ID);
            return RedirectToAction("Index");
        }
    }
}