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
    public class TableOrderManager : IOrderService<TableOrder>
    {
        IOrderDal<TableOrder> _tableOrderDal;
        public TableOrderManager(IOrderDal<TableOrder> tableOrderDal)
        {
            _tableOrderDal = tableOrderDal;
        }

        public void Add(TableOrder entity)
        {
            _tableOrderDal.Add(entity);
        }

        public void Delete(TableOrder entity)
        {
            _tableOrderDal.Delete(entity);
        }

        public TableOrder Get(int id)
        {
            return _tableOrderDal.Get(id);
        }

        public TableOrder Get(Expression<Func<TableOrder, bool>> Expression)
        {
            return _tableOrderDal.Get(Expression);
        }

        public List<TableOrder> GetAll()
        {
            return _tableOrderDal.GetAll();
        }

        public List<TableOrder> GetAll(string TableName)
        {
            return _tableOrderDal.GetAll(TableName);
        }

        public List<TableOrder> GetAll(Expression<Func<TableOrder, bool>> Expression)
        {
            return _tableOrderDal.GetAll(Expression);
        }

        public void Update(TableOrder entity)
        {
            _tableOrderDal.Update(entity);
        }
    }
}
