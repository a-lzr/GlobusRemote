using GlobusRemote.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GlobusRemote.Controllers
{
    public class StudentController : Controller
    {
        IList<StudentViewModel> students;

        public StudentController()
        {
            students = new List<StudentViewModel>{
                        new StudentViewModel() { StudentId = 1, StudentName = "John", Age = 18 } ,
                        new StudentViewModel() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                        new StudentViewModel() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                        new StudentViewModel() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                        new StudentViewModel() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                        new StudentViewModel() { StudentId = 6, StudentName = "Chris",  Age = 17 } ,
                        new StudentViewModel() { StudentId = 7, StudentName = "Rob",Age = 19  } ,
                    };
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(students);
        }

        public ActionResult StudentList()
        {
            return PartialView(students);
            //return PartialView(students);
        }
    }
}
