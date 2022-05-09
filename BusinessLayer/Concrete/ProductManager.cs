﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product Get(int id)
        {
            return _productDal.Get(id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllWithCategory()
        {
            return _productDal.GetAllWithCategory();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}