using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;

namespace Sehmus.UI.ViewComponents
{
    public class Header2ViewComponent:ViewComponent
    {
        private readonly IHeaderService headerService;

        public Header2ViewComponent(IHeaderService headerService)
        {
            this.headerService = headerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = headerService.TGetList();
            return View(listele);
        }
    }
}
