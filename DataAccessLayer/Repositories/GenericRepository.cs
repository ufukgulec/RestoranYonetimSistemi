using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public T Get(Expression<Func<T, bool>> Expression)
        {
            using var context = new Context();
            return context.Set<T>().Where(Expression).First();
        }

        public List<T> GetAll()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public List<T> GetAll(string TableName)
        {
            using var context = new Context();
            return context.Set<T>().Include(TableName).ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> Expression)
        {
            using var context = new Context();
            return context.Set<T>().Where(Expression).ToList();
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
