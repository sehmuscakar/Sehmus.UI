﻿namespace Sehmus.UI.Areas.Admin.Models
{
    public class AppUserRegisterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
