using Microsoft.AspNetCore.Identity;

namespace Sehmus.DataAccess.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }


        public List<Header> Headers { get; set; }
        public List<Hero> Heroes { get; set; }
        public List<About> Abouts { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Resume> Resumes { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<Contact> Contacts { get; set; }
    }
  }
