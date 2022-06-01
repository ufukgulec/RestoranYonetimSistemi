using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Rys.Models
{
    public class VMPhoneOrder : EntityLayer.Concrete.PhoneOrder
    {
        private PhoneOrderManager orderManager = new PhoneOrderManager(new EfOrderRepository<PhoneOrder>());
        private RegionManager<District> districtRegionManager = new RegionManager<District>(new EfGenericRepository<District>());
        private RegionManager<Street> streetRegionManager = new RegionManager<Street>(new EfGenericRepository<Street>());
        private GenericManager<PhoneOrderDetail> detailsManager = new GenericManager<PhoneOrderDetail>(new EfGenericRepository<PhoneOrderDetail>());
        private GenericManager<Customer> customerManager = new GenericManager<Customer>(new EfGenericRepository<Customer>());
        private ProductManager productManager = new ProductManager(new EfProductRepository());


        public VMPhoneOrder(PhoneOrder phoneOrder)
        {
            Id = phoneOrder.Id;
            Status = phoneOrder.Status;
            OrderTime = phoneOrder.OrderTime;
            CustomerId = phoneOrder.CustomerId;

            Customer = customerManager.Get(CustomerId);
            Customer.Street = streetRegionManager.Get(Customer.StreetId);
            Customer.Street.District = districtRegionManager.Get(Customer.Street.DistrictId);
            PhoneOrderDetails = detailsManager.GetAll(x => x.PhoneOrderId == Id);

            foreach (var item in PhoneOrderDetails)
            {
                item.Product = productManager.Get(item.ProductId);
            }
        }
    }
}
