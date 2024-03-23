using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;

namespace Sehmus.UI.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly IHeaderService headerService;

        public HeaderViewComponent(IHeaderService headerService)
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
