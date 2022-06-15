using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Rys.Models
{
    public class VMTableOrder : EntityLayer.Concrete.TableOrder
    {
        private TableOrderManager orderManager = new TableOrderManager(new EfOrderRepository<TableOrder>());
        private GenericManager<TableOrderDetail> detailsManager = new GenericManager<TableOrderDetail>(new EfGenericRepository<TableOrderDetail>());
        private GenericManager<Table> tableManager = new GenericManager<Table>(new EfGenericRepository<Table>());
        private GenericManager<Staff> staffManager = new GenericManager<Staff>(new EfGenericRepository<Staff>());
        private ProductManager productManager = new ProductManager(new EfProductRepository());


        public VMTableOrder(TableOrder tableOrder)
        {
            Id = tableOrder.Id;
            Status = tableOrder.Status;
            OrderTime = tableOrder.OrderTime;
            TableId = tableOrder.TableId;
            StaffId = tableOrder.StaffId;

            Staff = staffManager.Get(StaffId);

            TableOrderDetails = detailsManager.GetAll(x => x.TableOrderId == Id);

            foreach (var item in TableOrderDetails)
            {
                item.Product = productManager.Get(item.ProductId);
            }
        }
    }
}
