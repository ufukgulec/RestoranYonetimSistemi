using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Rys.Models;

namespace Rys.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        public IActionResult Index()
        {
            var values = customerManager.GetAll("Street", "Street.District");
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            VMRegion regionModel = new VMRegion();
            ViewData["Streets"] = regionModel.streets;

            return View();
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            customerManager.Add(customer);
            return RedirectToAction("Index");
        }
    }
}
