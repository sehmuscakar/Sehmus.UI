using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Sehmus.DataAccess.Entities;
using Sehmus.UI.Areas.Admin.Models;

namespace Sehmus.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);


            if (user == null)
            {
                // Kullanıcı bulunamadı, hata mesajını ViewBag'e ekleyin ve View'e dönün
                ViewBag.ErrorMessage2 = "Girilen e-posta adresi ile kayıtlı bir kullanıcı bulunamadı.";
                return View();
            }
            if (string.IsNullOrWhiteSpace(forgetPasswordViewModel.Mail))
            {
                ViewBag.ErrorMessage = "Lütfen bir mail adresi girin.";
                return View(forgetPasswordViewModel);
            }
            ViewBag.MessageSent = true;
            //ViewBag.ErrorMessage2 = "Şifre sıfırlama linki gönderilirken bir hata oluştu.";
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);
            //gönderilecek olan kişin bilgileri
            MimeMessage mimeMessage = new MimeMessage();// minekit kütüphanesi eklemen lazım bunun için maile doğrulama yapmak için 

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "aliasafgunsar@gmail.com");//kimden geleceği isim ve mail

            mimeMessage.From.Add(mailboxAddressFrom);//kimden gelecek ekle
                                                     //alacak olan kişin bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);//kime gideceği isim ve adres

            mimeMessage.To.Add(mailboxAddressTo);//kime gidecek ekle
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Şifre Değişiklik Talebi";// bu direk mail başlığında yazar

            SmtpClient client = new SmtpClient();// mail trnsfer nesne örneği protokol
            client.Connect("smtp.gmail.com", 587, false);//prokol gereklikleri bağlantı kurma ,burda bağlatı güvenliğine false dedik çünkü ConfirmMailController da true işlemi yapacaz emailconfirmed
            client.Authenticate("aliasafgunsar@gmail.com", "sudrylymanzehohq");//mail ve mailde oluşturduğun güvenlik kodu,bunu her bir ayrı projede ayrı al bu güvenlik kodunu mail üzerinden bazı işlmlerle alırsın
            client.Send(mimeMessage);//gönder
            client.Disconnect(true);//gövenli çıkış yap 
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if (userid == null || token == null)
            {
                //hata mesajı
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
