using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;

namespace Sehmus.UI.ViewComponents
{
    public class ResumeViewComponent:ViewComponent
    {
        private readonly IResumeService _resumeService;

        public ResumeViewComponent(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _resumeService.TGetList();
            return View(listele);
        }
    }
}
