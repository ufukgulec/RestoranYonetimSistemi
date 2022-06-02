using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer entity)
        {
            _customerDal.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public Customer Get(int id)
        {
            return _customerDal.Get(id);
        }

        public Customer Get(Expression<Func<Customer, bool>> Expression)
        {
            return _customerDal.Get(Expression);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public List<Customer> GetAll(string TableName)
        {
            return _customerDal.GetAll(TableName);
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> Expression)
        {
            return _customerDal.GetAll(Expression);
        }

        public void Update(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
