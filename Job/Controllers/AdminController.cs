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
            Console.WriteLine(fd.username);
            Console.WriteLine(fd.password);

            return View();
        }


    }
}
