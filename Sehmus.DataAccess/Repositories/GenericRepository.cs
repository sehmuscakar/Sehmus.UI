using Sehmus.DataAccess.Abstract;
using Sehmus.DataAccess.Concrete.Context;

namespace Sehmus.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ProjeContextDb projeContextDb;

        public GenericRepository(ProjeContextDb projeContextDb)
        {
            this.projeContextDb = projeContextDb;
        }

        public void Delete(T t)
        {
            projeContextDb.Remove(t);
            projeContextDb.SaveChanges();
        }

        public T GetByID(int id)
        {
            return projeContextDb.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return projeContextDb.Set<T>().ToList();
        }

        public void Insert(T t)
        {
           projeContextDb.Add(t);
            projeContextDb.SaveChanges();
        }

        public void Update(T t)
        {
           projeContextDb.Update(t);
            projeContextDb.SaveChanges();
        }
    }
}
