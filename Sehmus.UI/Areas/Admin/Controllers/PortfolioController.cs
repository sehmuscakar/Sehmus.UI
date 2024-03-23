using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;
using Sehmus.DataAccess.Entities;

namespace Sehmus.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            var values = _portfolioService.TGetList();
            return View(values);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Portfolio portfolio, IFormFile? ImageUrl1, IFormFile? ImageUrl2, IFormFile? ImageUrl3, IFormFile? ImageUrl4)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (ImageUrl1 is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl1.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        ImageUrl1.CopyTo(stream1);
                        portfolio.ImageUrl1 = ImageUrl1.FileName;
                    }
                    if (ImageUrl2 is not null)
                    {
                        string klasor2 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl2.FileName;
                        using var stream2 = new FileStream(klasor2, FileMode.Create);
                        ImageUrl2.CopyTo(stream2);
                        portfolio.ImageUrl2 = ImageUrl2.FileName;
                    }
                    if (ImageUrl3 is not null)
                    {
                        string klasor3 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl3.FileName;
                        using var stream3 = new FileStream(klasor3, FileMode.Create);
                        ImageUrl3.CopyTo(stream3);
                        portfolio.ImageUrl3 = ImageUrl3.FileName;
                    }
                    if (ImageUrl4 is not null)
                    {
                        string klasor4 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl4.FileName;
                        using var stream4 = new FileStream(klasor4, FileMode.Create);
                        ImageUrl4.CopyTo(stream4);
                        portfolio.ImageUrl4 = ImageUrl4.FileName;
                    }
                    _portfolioService.TInsert(portfolio);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: HeaderController/Edit/5
        public ActionResult Edit(int id)
        {
            // ViewBag.dgr = _headerService.UserListManager();
            var resultDataId = _portfolioService.TGetByID(id);
            return View(resultDataId);
        }

        // POST: HeaderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Portfolio portfolio, IFormFile? ImageUrl1, IFormFile? ImageUrl2, IFormFile? ImageUrl3, IFormFile? ImageUrl4)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (ImageUrl1 is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl1.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        ImageUrl1.CopyTo(stream1);
                        portfolio.ImageUrl1 = ImageUrl1.FileName;
                    }
                    if (ImageUrl2 is not null)
                    {
                        string klasor2 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl2.FileName;
                        using var stream2 = new FileStream(klasor2, FileMode.Create);
                        ImageUrl2.CopyTo(stream2);
                        portfolio.ImageUrl2 = ImageUrl2.FileName;
                    }
                    if (ImageUrl3 is not null)
                    {
                        string klasor3 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl3.FileName;
                        using var stream3 = new FileStream(klasor3, FileMode.Create);
                        ImageUrl3.CopyTo(stream3);
                        portfolio.ImageUrl3 = ImageUrl3.FileName;
                    }
                    if (ImageUrl4 is not null)
                    {
                        string klasor4 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl4.FileName;
                        using var stream4 = new FileStream(klasor4, FileMode.Create);
                        ImageUrl4.CopyTo(stream4);
                        portfolio.ImageUrl4 = ImageUrl4.FileName;
                    }
                    _portfolioService.TUpdate(portfolio);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var heroToDelete = _portfolioService.TGetByID(id);
                _portfolioService.TDelete(heroToDelete);
                return RedirectToAction("Index"); // Silme işlemi başarılıysa Index sayfasına yönlendir
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return StatusCode(500); // İsteği işlerken bir hata oluşursa 500 Internal Server Error dön
            }
        }
    }
}
