using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace Rys.Models
{
    public class VMPhoneOrder : EntityLayer.Concrete.PhoneOrder
    {
        PhoneOrderManager orderManager = new PhoneOrderManager(new EfOrderRepository<PhoneOrder>());

        RegionManager<District> districtRegionManager = new RegionManager<District>(new EfGenericRepository<District>());
        RegionManager<Street> streetRegionManager = new RegionManager<Street>(new EfGenericRepository<Street>());

        GenericManager<PhoneOrderDetail> detailsManager = new GenericManager<PhoneOrderDetail>(new EfGenericRepository<PhoneOrderDetail>());

        PhoneOrder phoneOrder;

        public VMPhoneOrder(PhoneOrder phoneOrder)
        {
            this.phoneOrder = phoneOrder;
            phoneOrder.Street = streetRegionManager.Get(phoneOrder.StreetId);
            phoneOrder.Street.District = districtRegionManager.Get(phoneOrder.Street.DistrictId);

        }
    }
}
