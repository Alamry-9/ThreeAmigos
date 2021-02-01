using Microsoft.AspNetCore.Mvc;
using ThreeAmigos.Domain.Entities;
using ThreeAmigos.Domain.Interfaces.Services;
using ThreeAmigos.UI.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreeAmigos.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _service;

        public HomeController(IStudentService service)
        {

            _service = service;

            //TODO simple seed
            _service.AddStudentAsync(new Student
            {
                IdStudent = 1,
                FirstName = "John",
                LastName = "Smith"
            });

            _service.AddStudentAsync(new Student
            {
                IdStudent = 2,
                FirstName = "Ada",
                LastName = "Jackie"
            });

        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetStudentsAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
