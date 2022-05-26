using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Rys.Models
{
    public class RegionModel
    {
        public List<District> districts { get; set; }
        public List<Street> streets { get; set; }

        RegionManager<District> districtRegionManager = new RegionManager<District>(new EfGenericRepository<District>());
        RegionManager<Street> streetRegionManager = new RegionManager<Street>(new EfGenericRepository<Street>());
        public RegionModel()
        {
            districts = districtRegionManager.GetAll();
            //streets = streetRegionManager.GetAll("District");
        }
    }
}
