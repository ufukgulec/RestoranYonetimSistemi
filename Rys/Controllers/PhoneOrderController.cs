using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Rys.Controllers
{
    public class PhoneOrderController : Controller
    {
        PhoneOrderManager orderManager = new PhoneOrderManager(new EfPhoneOrderRepository());
        public IActionResult Index()
        {
            return View();
        }
    }
}
