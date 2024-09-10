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
            TempData.Keep("date");
            return View(studentModels);
        }

        //Student/Details/4 
        //Details/4

        [Route("Student/Details/{id:int:min(1)}")]
        public ViewResult Details(int id) //2, 4
        {
            //what do we need tio return -- just 1 object

            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            keyValuePairs.Add(1, "Ram");
            keyValuePairs.Add(2, "Ravi");

            bool status = keyValuePairs.ContainsKey(2);
            if (status)
            {
                string val = "";
                keyValuePairs.TryGetValue(2, out val);
            }

            StudentModel obj = studentModels.Where(p => p.Id == id).FirstOrDefault() ?? new StudentModel();

            ViewData["input"] = obj;
            ViewBag.input = obj;
            TempData["date"] = DateTime.Now;
            TempData.Keep("date");

            return View(obj);

            //ViewData

        }

        public JsonResult ListAllJson()
        {
            return Json(studentModels);
        }

        public PartialViewResult GetDateTime()
        {
            return PartialView("~/View/Student/_DateTime.cshtml");
        }

        public ContentResult GetContent()
        {
            //return new ContentResult
            //{
            //    // Set the ContentType property to "text/plain" to indicate the MIME type of the content
            //    ContentType = "html",
            //    // Set the Content property to the plainText string, which contains the content to be returned
            //    Content = "<span>plainText</span>"
            //};

            return Content("<html><span>plainText</span></html>");
        }

        public FileResult DownloadFile()
        {
            //C:\Users\Laptops Garage\Hari

            string filePath = "C:\\Users\\Laptops Garage\\Hari\\sample.docx";
            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            var fileResult = File(fileBytes, "application/docx");
            fileResult.FileDownloadName = "example.docx";

            return fileResult;
        }

        //ViewResult - View    
        //ViewResult - Partial view
        //JsonResult - Json
        //ContentResult - Content (html,json, xml)
        //FileResult - File
        //RedirectResult - Redirect

    }
}
