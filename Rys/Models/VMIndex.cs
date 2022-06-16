using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace Rys.Models
{
    public class VMIndex
    {
        #region Managers
        static PhoneOrderManager porderManager = new PhoneOrderManager(new EfOrderRepository<PhoneOrder>());
        static TableOrderManager torderManager = new TableOrderManager(new EfOrderRepository<TableOrder>());
        static CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        static ProductManager productManager = new ProductManager(new EfProductRepository());
        static CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        static GenericManager<Staff> staffManager = new GenericManager<Staff>(new EfGenericRepository<Staff>());
        static GenericManager<Table> tableManager = new GenericManager<Table>(new EfGenericRepository<Table>());
        #endregion
        public int PhoneOrder { get; set; }
        public int TableOrder { get; set; }
        public int TotalOrder { get; set; }
        public int CategoryCount { get; set; }
        public int ProductCount { get; set; }
        public int CustomerCount { get; set; }
        public int WaiterCount { get; set; }
        public int TableCount { get; set; }

        public VMIndex()
        {
            PhoneOrder = porderManager.GetAll().Count;
            TableOrder = torderManager.GetAll().Count;
            TotalOrder = PhoneOrder + TableOrder;
            CategoryCount = categoryManager.GetAll().Count;
            ProductCount = productManager.GetAll().Count;
            CustomerCount = customerManager.GetAll().Count; ;
            WaiterCount = staffManager.GetAll(x => x.RoleId == 2).Count;
            TableCount = tableManager.GetAll().Count;
        }
    }
}
