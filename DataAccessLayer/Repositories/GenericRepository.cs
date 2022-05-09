using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T entity)
        {
            using var context = new Context();
            context.Add(entity);
            Save(context);
        }

        public void Delete(T entity)
        {
            using var context = new Context();
            context.Remove(entity);
            Save(context);
        }

        public T Get(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            using var context = new Context();
            context.Update(entity);
            Save(context);
        }
        private void Save(Context context)
        {
            context.SaveChanges();
        }
    }
}
