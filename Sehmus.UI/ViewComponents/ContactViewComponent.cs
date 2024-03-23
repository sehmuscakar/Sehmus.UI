using Microsoft.AspNetCore.Mvc;
using Sehmus.Business.Abstarct;

namespace Sehmus.UI.ViewComponents
{
    public class ContactViewComponent:ViewComponent
    {
        private readonly IContactService _contactService;

        public ContactViewComponent(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _contactService.TGetList();
            return View(listele);
        }
    }
}
