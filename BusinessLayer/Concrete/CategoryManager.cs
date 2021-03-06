using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category Get(int id)
        {
            return _categoryDal.Get(id);
        }

        public Category Get(Expression<Func<Category, bool>> Expression)
        {
            return _categoryDal.Get(Expression);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetAll(string TableName)
        {
            return _categoryDal.GetAll(TableName);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> Expression)
        {
            return _categoryDal.GetAll(Expression);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
