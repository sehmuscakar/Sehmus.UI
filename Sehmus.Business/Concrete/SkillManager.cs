﻿using Sehmus.Business.Abstarct;
using Sehmus.DataAccess.Abstract;
using Sehmus.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehmus.Business.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void TDelete(Skill t)
        {
          _skillDal.Delete(t);
        }

        public Skill TGetByID(int id)
        {
return _skillDal.GetByID(id);
                }

        public List<Skill> TGetList()
        {
           return _skillDal.GetList();
        }

        public void TInsert(Skill t)
        {
         _skillDal.Insert(t);
        }

        public void TUpdate(Skill t)
        {
            _skillDal.Update(t);
        
        }
    }
}
