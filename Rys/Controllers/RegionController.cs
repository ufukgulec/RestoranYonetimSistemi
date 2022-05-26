using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Rys.Models;
using System.Linq;
using System.Globalization;

namespace Rys.Controllers
{
    public class RegionController : Controller
    {
        RegionManager<District> districtRegionManager = new RegionManager<District>(new EfGenericRepository<District>());
        RegionManager<Street> streetRegionManager = new RegionManager<Street>(new EfGenericRepository<Street>());
        public IActionResult Index(string searchDistrict, string searchStreet)
        {
            RegionModel regionModel = new RegionModel();
            if (!string.IsNullOrEmpty(searchDistrict))
            {
                if (regionModel.districts.Where(d => d.Name.ToLower(new CultureInfo("en-US", false)).Contains(searchDistrict.ToLower(new CultureInfo("en-US", false)))).ToList().Count > 0)
                {
                    District district = regionModel.districts.Where(d => d.Name.ToLower(new CultureInfo("en-US", false)).Contains(searchDistrict.ToLower())).First();
                    regionModel.streets = streetRegionManager.GetAll(d => d.DistrictId == district.Id).ToList();
                }

            }
            else if (!string.IsNullOrEmpty(searchStreet))
            {
                if (regionModel.streets.Where(d => d.Name.ToLower(new CultureInfo("en-US", false)).Contains(searchStreet.ToLower(new CultureInfo("en-US", false)))).ToList().Count > 0)
                {
                    regionModel.streets = regionModel.streets.Where(d => d.Name.ToLower(new CultureInfo("en-US", false)).Contains(searchStreet.ToLower())).ToList();
                }
            }

            return View(regionModel);
        }
    }
}
