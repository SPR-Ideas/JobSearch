using Microsoft.AspNetCore.Mvc;
using Job.Models;

namespace Job.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index(int Id)
        {
            Console.WriteLine(Id);
            return View();
        }

        [HttpPost]
        public IActionResult Index( Login fd)
        {
            if(fd.CheckPassword()){
                return View("Admin");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Admin(int delete,int Id){
            if(delete==1 &&  Id != null){
                DeleteJobRole jr = new DeleteJobRole();
                jr.DeleteJob(Id);
            }
            AdminModels jd = new AdminModels();
            jd.fetch();
            ViewBag.Message = jd.JobList;
            return View();
        }
        [HttpPost]
        
        public IActionResult Admin(CreateJobRole jr ){
            jr.addJob();
            
            AdminModels jd = new AdminModels();
            jd.fetch();
            ViewBag.Message = jd.JobList;

            return View();
        }

    }
}
