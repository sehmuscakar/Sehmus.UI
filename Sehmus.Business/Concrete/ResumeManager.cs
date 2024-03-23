using Sehmus.Business.Abstarct;
using Sehmus.DataAccess.Abstract;
using Sehmus.DataAccess.Entities;

namespace Sehmus.Business.Concrete
{
    public class ResumeManager : IResumeService
    {
        private readonly IResumeDal _resumeDal;

        public ResumeManager(IResumeDal resumeDal)
        {
            _resumeDal = resumeDal;
        }

        public void TDelete(Resume t)
        {
            _resumeDal.Delete(t);
        }

        public Resume TGetByID(int id)
        {
            return _resumeDal.GetByID(id);
        }

        public List<Resume> TGetList()
        {
            return _resumeDal.GetList();
        }

        public void TInsert(Resume t)
        {
            _resumeDal.Insert(t);
        }

        public void TUpdate(Resume t)
        {
            _resumeDal.Update(t);
        }
    }
}
