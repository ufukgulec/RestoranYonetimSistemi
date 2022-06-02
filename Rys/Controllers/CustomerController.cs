using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Rys.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        public IActionResult Index()
        {
            var values = customerManager.GetAll("Street");
            return View(values);
        }
    }
}
