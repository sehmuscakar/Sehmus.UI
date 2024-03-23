using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;
using Sehmus.Business.Concrete;

namespace Sehmus.UI.ViewComponents
{
    public class HeroViewComponent:ViewComponent
    {
        private readonly IHeroService heroService;

        public HeroViewComponent(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = heroService.TGetList();
            return View(listele);
        }
    }
}
