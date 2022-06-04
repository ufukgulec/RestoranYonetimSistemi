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
        public IActionResult Index(int? districtId)
        {
            VMRegion regionModel = new VMRegion();

            if (districtId != null)
            {
                regionModel.streets = regionModel.streets.Where(x => x.DistrictId == districtId).ToList();

            }

            return View(regionModel);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(districtRegionManager.GetAll());
        }
        [HttpPost]
        public IActionResult AddDistrict(District district)
        {
            districtRegionManager.Add(district);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddStreet(Street street)
        {
            streetRegionManager.Add(street);
            return RedirectToAction("Index");
        }
    }
}
