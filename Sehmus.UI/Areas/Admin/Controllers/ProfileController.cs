using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sehmus.DataAccess.Entities;
using Sehmus.UI.Areas.Admin.Models;

namespace Sehmus.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var listele = _userManager.Users.ToList();
            return View(listele);
        }

        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditModel appUserEditDto = new AppUserEditModel();
            appUserEditDto.Name = values.Name;
            appUserEditDto.LastName = values.LastName;
            appUserEditDto.Phone = values.Phone;
            appUserEditDto.Email = values.Email;
            appUserEditDto.About = values.About;
            appUserEditDto.ImageUrl = appUserEditDto.ImageUrl;
            appUserEditDto.Adress = values.Adress;
            appUserEditDto.ImageUrl = values.ImageUrl;
            return View(appUserEditDto);

        }

        [HttpPost]
        public async Task<IActionResult> MyAccount(AppUserEditModel appUserEditDto, IFormFile? ImageUrl)
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
            {
                if (!ModelState.IsValid)
                {
                    if (ImageUrl is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        ImageUrl.CopyTo(stream1);
                        appUserEditDto.ImageUrl = ImageUrl.FileName;
                    }
                }
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                user.Phone = appUserEditDto.Phone;
                user.LastName = appUserEditDto.LastName;
                user.About = appUserEditDto.About;
                user.Adress = appUserEditDto.Adress;
                user.Name = appUserEditDto.Name;
                user.ImageUrl = appUserEditDto.ImageUrl;
                user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var resut = await _userManager.UpdateAsync(user);
                if (resut.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }

            }
            return View();
        }

    }
}
