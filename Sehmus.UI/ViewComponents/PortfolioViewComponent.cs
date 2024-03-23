using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;

namespace Sehmus.UI.ViewComponents
{
    public class PortfolioViewComponent:ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioViewComponent(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _portfolioService.TGetList();
            return View(listele);
        }
    }
}
