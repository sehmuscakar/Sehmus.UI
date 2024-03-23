using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sehmus.DataAccess.Entities;

namespace Sehmus.DataAccess.Concrete.Context
{
    public class ProjeContextDb : IdentityDbContext<AppUser, AppRole, int>
    {
        public ProjeContextDb(DbContextOptions<ProjeContextDb> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Server=DESKTOP-PBFD0LU;Database=AsafDb;Integrated Security=True;TrustServerCertificate=True;");
        //}
        public DbSet<Header> Headers { get; set; }  
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
