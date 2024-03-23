using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;
using Sehmus.Business.Concrete;

namespace Sehmus.UI.ViewComponents
{
    public class AboutViewComponent:ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _aboutService.TGetList();
            return View(listele);
        }
    }
}
