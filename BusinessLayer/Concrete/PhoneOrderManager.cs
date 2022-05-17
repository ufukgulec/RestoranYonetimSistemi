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
    public class PhoneOrderManager : IOrderService<PhoneOrder>
    {
        IOrderDal<PhoneOrder> _phoneOrderDal;
        public PhoneOrderManager(IOrderDal<PhoneOrder> phoneOrderDal)
        {
            _phoneOrderDal = phoneOrderDal;
        }

        public void Add(PhoneOrder entity)
        {
            _phoneOrderDal.Add(entity);
        }

        public void Delete(PhoneOrder entity)
        {
            _phoneOrderDal.Delete(entity);
        }

        public PhoneOrder Get(int id)
        {
            return _phoneOrderDal.Get(id);
        }

        public PhoneOrder Get(Expression<Func<PhoneOrder, bool>> Expression)
        {
            return _phoneOrderDal.Get(Expression);
        }

        public List<PhoneOrder> GetAll()
        {
            return _phoneOrderDal.GetAll();
        }

        public List<PhoneOrder> GetAll(string TableName)
        {
            return _phoneOrderDal.GetAll(TableName);
        }

        public List<PhoneOrder> GetAll(Expression<Func<PhoneOrder, bool>> Expression)
        {
            return _phoneOrderDal.GetAll(Expression);
        }

        public void Update(PhoneOrder entity)
        {
            _phoneOrderDal.Update(entity);
        }
    }
}
