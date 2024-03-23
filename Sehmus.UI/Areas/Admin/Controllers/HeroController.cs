using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;
using Sehmus.Business.Concrete;
using Sehmus.DataAccess.Entities;

namespace Sehmus.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
   [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class HeroController : Controller
    {
        private readonly IHeroService _heroService;

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public IActionResult Index()
        {
            var values = _heroService.TGetList();
            return View(values);
        }
        public ActionResult Create()
        {

            return View();
        }

        // POST: HeaderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hero hero)
        {
            try
            {
                _heroService.TInsert(hero);
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
         
            var resultDataId = _heroService.TGetByID(id);
            return View(resultDataId);
        }

        // POST: HeaderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hero hero)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                   

                   _heroService.TUpdate(hero);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            try
            {
                var heroToDelete = _heroService.TGetByID(id);
                _heroService.TDelete(heroToDelete);
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
