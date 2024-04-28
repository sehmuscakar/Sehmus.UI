using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Sehmus.Business.Abstarct;
using Sehmus.Business.Concrete;
using Sehmus.DataAccess.Abstract;
using Sehmus.DataAccess.Concrete;
using Sehmus.DataAccess.Concrete.Context;
using Sehmus.DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjeContextDb>(opt => //contextteki constractýr sýkýntý yaratýðý için diðer yöntemi kullandým.
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Host"));
});

builder.Services.AddScoped<IHeaderDal,HeaderDal>();
builder.Services.AddScoped<IHeaderService,HeaderManager>();

builder.Services.AddScoped<IHeroDal, HeroDal>();
builder.Services.AddScoped<IHeroService, HeroManager>();

builder.Services.AddScoped<IAboutDal, AboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<ISkillDal, SkillDal>();
builder.Services.AddScoped<ISkillService, SkillManager>();

builder.Services.AddScoped<IResumeDal, ResumeDal>();
builder.Services.AddScoped<IResumeService, ResumeManager>();

builder.Services.AddScoped<IContactDal, ContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();



builder.Services.AddScoped<IPortfolioDal, PortfolioDal>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ProjeContextDb>()
    .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);//hangi tablolarý özeleþtirmiþsen onlarý buraya tanýman lazým ýdentitye ile sisteme önemli 
//þifre sýfýrlamada kullandýðýmýz için token buraya da ekiyoruz identityinin içine gerekli olaný 
builder.Services.AddMvc(config =>//bu tüm sistemi kilitliyor kimlik doðrulama oladan açýlmaz eriþilemez
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
config.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => //otonatike olmayan kýsmý buraya yunlendirecek bunu yapmadan da  [AllowAnonymous] bu kodu controllera yazarak ta yapabilirsin 
{
    x.LoginPath = "/Admin/Login/SignIn";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseStatusCodePagesWithReExecute("/Admin/Login/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Anasayfa}/{id?}");

app.Run();
