
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
        public IActionResult Index (LoginModel lg_data)
        {
            Login loginInstance = new Login(_configuration);
            loginInstance.username = lg_data.username;
            loginInstance.password = lg_data.password;
            if(loginInstance.CheckPassword(0)){

                Response.Redirect("/home/portal/"+loginInstance.Id);
            }
            return View();
        }


        public IActionResult Portal(int Id=0)
        {
            if (Id !=0){
            AdminModels jd = new AdminModels(_configuration);
            jd.fetch();
            jd.fetchJobApplied(Id);

            ViewBag.Message = new List<object> {jd.JobList,jd.JobIdsApplied,Id};
            return View();
            }
            ViewBag.Message = new List<AdminModels>{new AdminModels(_configuration),new AdminModels(_configuration)};
            return View();
        }

        [HttpPut]
        public IActionResult Portal([FromBody] UserMap um)
        {
            // This function Applies the job for the user.
            um.apply();
            AdminModels jd = new AdminModels(_configuration);
            jd.fetch();
            jd.fetchJobApplied(um.Id);
            ViewBag.Message = new List<object> {jd.JobList,jd.JobIdsApplied,um.Id};
            ViewBag.Uid = um.Id;
            return View();
        }

        [HttpPost]
        public IActionResult Portal(JobSearch Data){
            AdminModels jd = new AdminModels(_configuration);
            jd.fetchJobByString(Data.SearchQuery);
            jd.fetchJobApplied(Data.Id);
            Console.WriteLine(Data.Id);
            ViewBag.Message = new List<object> {jd.JobList,jd.JobIdsApplied,Data.Id};
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
