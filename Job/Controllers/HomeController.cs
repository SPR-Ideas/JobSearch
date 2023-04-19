using System.Reflection.Metadata;
using Job.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Job.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Index (Login lg)
        {

            if(lg.CheckPassword(0)){

                Response.Redirect("/home/portal");
            }
            return View();
        }


        public IActionResult Portal(int Id=0)
        {
            if (Id !=0){
            AdminModels jd = new AdminModels(_configuration);
            jd.fetch();
            jd.fetchJobApplied(Id);
            ViewBag.Message = new List<object> {jd.JobList,jd.JobIdsApplied};
            return View();
            }
            ViewBag.Message = new List<AdminModels>();
            return View();
        }

        [HttpPost]
        public IActionResult Portal(UserMap um)
        {
            // This function Applies the job for the user.
            um.apply();
            AdminModels jd = new AdminModels(_configuration);
            jd.fetch();
            jd.fetchJobApplied(um.Id);
            ViewBag.Message = new List<object> {jd.JobList,jd.JobIdsApplied,};
            ViewBag.Uid = um.Id;

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
