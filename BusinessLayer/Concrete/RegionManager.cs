using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RegionManager<T> : IRegionService<T> where T : class
    {
        IGenericDal<T> _genericDal;
        public RegionManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }
        public void Add(T entity)
        {
            _genericDal.Add(entity);
        }

        public void Delete(T entity)
        {
            _genericDal.Delete(entity);
        }

        public T Get(int id)
        {
            return _genericDal.Get(id);
        }

        public List<T> GetAll()
        {
            return _genericDal.GetAll();
        }

        public List<T> GetAll(string TableName)
        {
            return _genericDal.GetAll(TableName);
        }

        public void Update(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
