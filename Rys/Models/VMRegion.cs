using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Rys.Models
{
    public class VMRegion
    {
        public List<District> districts { get; set; }
        public List<Street> streets { get; set; }

        RegionManager<District> districtRegionManager = new RegionManager<District>(new EfGenericRepository<District>());
        RegionManager<Street> streetRegionManager = new RegionManager<Street>(new EfGenericRepository<Street>());
        public VMRegion()
        {
            districts = districtRegionManager.GetAll();
            streets = streetRegionManager.GetAll();
        }
    }
}
