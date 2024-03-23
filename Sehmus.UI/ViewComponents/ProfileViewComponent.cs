using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sehmus.DataAccess.Entities;
using Sehmus.UI.Areas.Admin.Models;

namespace Sehmus.UI.ViewComponents
{
    public class ProfileViewComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditModel appUserEditDto = new AppUserEditModel();
            appUserEditDto.Name = values.Name;
            appUserEditDto.LastName = values.LastName;
            appUserEditDto.About = values.About;
            appUserEditDto.ImageUrl = appUserEditDto.ImageUrl;
            appUserEditDto.ImageUrl = values.ImageUrl;
            return View(appUserEditDto);
        }
    }
}
