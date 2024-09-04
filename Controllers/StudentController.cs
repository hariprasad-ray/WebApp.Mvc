using Microsoft.AspNetCore.Mvc;
using WebApp.Mvc.Models;


namespace WebApp.Mvc.Controllers
{
    public class StudentController : Controller
    {
        public static List<StudentModel> studentModels = new List<StudentModel>();

        public StudentController()
        {
            studentModels.Add(new StudentModel() { Id = 1, Name = "Ram", Section = "A", Address = "Bangalore" });
            studentModels.Add(new StudentModel() { Id = 2, Name = "Ravi", Section = "C", Address = "Chennai" });
            studentModels.Add(new StudentModel() { Id = 3, Name = "Raj", Section = "B", Address = "Bangalore" });
            studentModels.Add(new StudentModel() { Id = 4, Name = "Kumar", Section = "A", Address = "AP" });
            studentModels.Add(new StudentModel() { Id = 5, Name = "RK", Section = "B", Address = "Bangalore" });
            studentModels.Add(new StudentModel() { Id = 6, Name = "MK", Section = "C", Address = "Hyderabad" });
        }
        

        public IActionResult ListAll()
        {
            //have to retrun all student list - studentModels

            //what do we need tio return -- list of ibjects

            return View(studentModels);
        }

        //Student/Details/4 
        //Details/4

        [Route("Student/Details/{id:int:min(1)}")]
        public IActionResult Details(int id) //2, 4
        {
            //what do we need tio return -- just 1 object

            StudentModel obj = studentModels.Where(p => p.Id == id).FirstOrDefault() ?? new StudentModel();

            return View(obj);
        }
    }
}
