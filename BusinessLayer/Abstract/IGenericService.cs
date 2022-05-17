using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll();
        List<T> GetAll(string TableName);
        List<T> GetAll(Expression<Func<T, bool>> Expression);
        T Get(int id);
        T Get(Expression<Func<T, bool>> Expression);
    }
}
