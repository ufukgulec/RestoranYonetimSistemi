using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Rys.Models;

namespace Rys.Controllers
{
    public class RegionController : Controller
    {
        RegionManager<District> districtRegionManager = new RegionManager<District>(new EfGenericRepository<District>());
        RegionManager<Street> streetRegionManager = new RegionManager<Street>(new EfGenericRepository<Street>());
        public IActionResult Index()
        {
            RegionModel regionModel = new RegionModel();
            return View(regionModel);
        }
    }
}
