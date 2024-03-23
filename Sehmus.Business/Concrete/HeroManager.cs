using Sehmus.Business.Abstarct;
using Sehmus.DataAccess.Abstract;
using Sehmus.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehmus.Business.Concrete
{
    public class HeroManager : IHeroService
    {
        private readonly IHeroDal _heroDal;

        public HeroManager(IHeroDal heroDal)
        {
            _heroDal = heroDal;
        }

        public void TDelete(Hero t)
        {
           _heroDal.Delete(t);
        }

        public Hero TGetByID(int id)
        {
            return _heroDal.GetByID(id);    
        }

        public List<Hero> TGetList()
        {
           return _heroDal.GetList();
        }

        public void TInsert(Hero t)
        {
          _heroDal.Insert(t);
        }

        public void TUpdate(Hero t)
        {
            _heroDal.Update(t);
        }
    }
}
