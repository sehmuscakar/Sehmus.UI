using Sehmus.DataAccess.Abstract;
using Sehmus.DataAccess.Concrete.Context;
using Sehmus.DataAccess.Entities;
using Sehmus.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehmus.DataAccess.Concrete
{
    public class SkillDal : GenericRepository<Skill>, ISkillDal
    {
        public SkillDal(ProjeContextDb projeContextDb) : base(projeContextDb)
        {
        }
    }
}
