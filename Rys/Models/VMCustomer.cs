using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace Rys.Models
{
    static class VMCustomer
    {
        static private CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        static private RegionManager<District> districtRegionManager = new RegionManager<District>(new EfGenericRepository<District>());
        static private RegionManager<Street> streetRegionManager = new RegionManager<Street>(new EfGenericRepository<Street>());

        static public Customer Get(int id)
        {
            var customer = customerManager.Get(id);
            customer.Street = streetRegionManager.Get(customer.StreetId);
            customer.Street.District = districtRegionManager.Get(customer.Street.DistrictId);

            return customer;
        }
    }
}
