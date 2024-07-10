using ContosoUniversity.Models;
using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContosoUniversity.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ContosoUniversityContext _logger;

        public HomeController(ContosoUniversityContext logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to Contoso University";
            return View();
        }


        public ActionResult About()
        {
            IQueryable<About> data = from student in _logger.Students
                                     group student by student.EnrollmentDate into dateGroup
                                     select new About
                                     {
                                         EnrollmentDate = dateGroup.Key,
                                         StudentCount = dateGroup.Count()
                                     };
            // SQL version of the above LINQ code.

            return View(data.ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}