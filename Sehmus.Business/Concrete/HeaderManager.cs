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
    public class HeaderManager : IHeaderService
    {
        private readonly IHeaderDal _headerDal;

        public HeaderManager(IHeaderDal headerDal)
        {
            _headerDal = headerDal;
        }

        public void TDelete(Header t)
        {
           _headerDal.Delete(t);
        }

        public Header TGetByID(int id)
        {
           return _headerDal.GetByID(id);
        }

        public List<Header> TGetList()
        {
            return _headerDal.GetList();
        }

        public void TInsert(Header t)
        {
           _headerDal.Insert(t);
        }

        public void TUpdate(Header t)
        {
           _headerDal.Update(t);
        }
    }
}
