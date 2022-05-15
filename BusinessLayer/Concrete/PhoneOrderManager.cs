using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PhoneOrderManager : IPhoneOrderService
    {
        IPhoneOrderDal _phoneOrderDal;
        public PhoneOrderManager(IPhoneOrderDal phoneOrderDal)
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

        public List<PhoneOrder> GetAll()
        {
            return _phoneOrderDal.GetAll();
        }

        public List<PhoneOrder> GetAll(string TableName)
        {
            return _phoneOrderDal.GetAll(TableName);
        }

        public void Update(PhoneOrder entity)
        {
            _phoneOrderDal.Update(entity);
        }
    }
}
