using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Rys.Models;

namespace Rys.Controllers
{
    public class PhoneOrderController : Controller
    {
        PhoneOrderManager orderManager = new PhoneOrderManager(new EfOrderRepository<PhoneOrder>());
        public IActionResult Index()
        {
            var values = orderManager.GetAll();//Günlük sipariş yap
            return View(values);
        }
        public IActionResult Complete(int id)
        {
            var order = orderManager.Get(id);
            order.Status = false;
            orderManager.Update(order);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            VMPhoneOrder vm = new VMPhoneOrder(orderManager.Get(id));

            return View(vm);
        }
    }
}
