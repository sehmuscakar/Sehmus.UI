using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;


namespace Sehmus.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioService _portfolioService;
      
        public HomeController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Anasayfa()
        {
            return View();
        }

        public IActionResult Portfolio(int id)
        {

            var resultDataId = _portfolioService.TGetByID(id);
            return View(resultDataId);
        }

        public IActionResult About()
        {
            return View();
        }

    }
}