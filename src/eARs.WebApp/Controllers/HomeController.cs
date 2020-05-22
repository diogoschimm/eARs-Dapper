using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eARs.WebApp.Models;
using eARs.Domain.Interfaces;

namespace eARs.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvedorRepository _provedorRepository;

        public HomeController(IProvedorRepository provedorRepository)
        {
            this._provedorRepository = provedorRepository;
        }

        public IActionResult Index()
        {
            var dados = _provedorRepository.List().Result;
            return View(dados);
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
