using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void Add(T entity)
        {
            _genericDal.Add(entity);
        }

        public void Delete(T entity)
        {
            _genericDal?.Delete(entity);
        }

        public T Get(int id)
        {
            return _genericDal.Get(id);
        }

        public T Get(Expression<Func<T, bool>> Expression)
        {
            return _genericDal.Get(Expression);
        }

        public List<T> GetAll()
        {
            return _genericDal.GetAll();
        }

        public List<T> GetAll(string TableName)
        {
            return _genericDal.GetAll(TableName);
        }

        public List<T> GetAll(Expression<Func<T, bool>> Expression)
        {
            return _genericDal.GetAll(Expression);
        }

        public void Update(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
