using Microsoft.AspNetCore.Mvc;
using Job.Models;

namespace Job.Controllers
{
    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration){
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index(int Id)
        {
            Console.WriteLine(Id);
            return View();
        }

        [HttpPost]
        public IActionResult Index( LoginModel lg_data)
        {
            Login loginInstance = new Login(_configuration);
            loginInstance.username = lg_data.username;
            loginInstance.password = lg_data.password;
            if(loginInstance.CheckPassword(1)){
                Response.Redirect("/admin/admin");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Admin(int delete,int Id){
            if(delete==1 &&  Id != null){
                DeleteJobRole jr = new DeleteJobRole(_configuration);
                jr.DeleteJob(Id);
            }
            AdminModels jd = new AdminModels(_configuration);
            jd.fetch();
            ViewBag.Message = jd.JobList;
            return View();
        }
        [HttpPost]

        public IActionResult Admin(JobModel jr ){

            CreateJobRole job = new CreateJobRole(_configuration);
            job.job = jr;
            job.addJob();
            AdminModels jd = new AdminModels(_configuration);

            jd.fetch();
            ViewBag.Message = jd.JobList;

            return View();
        }

        public ActionResult Edit(int Id) {
            ViewBag.id = Id;
            CreateJobRole jr = new CreateJobRole(_configuration);
            jr.getJob(Id);
            ViewBag.job = jr.job;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(JobModel job)
        {
            Console.WriteLine(job.jobRole);
            CreateJobRole jr = new CreateJobRole(_configuration);
            jr.job = job;
            
            jr.updateJob(job.Id);
            return RedirectToAction("admin");
        }

    }
}
