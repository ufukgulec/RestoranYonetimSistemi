using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Rys.Models;
using System;
using System.Linq;

namespace Rys.Controllers
{
    public class PhoneOrderController : Controller
    {
        PhoneOrderManager orderManager = new PhoneOrderManager(new EfOrderRepository<PhoneOrder>());
        public IActionResult Index()
        {
            var values = orderManager.GetAll("Customer").Where(x => x.OrderTime.Date == System.DateTime.Now.Date).ToList();//Günlük sipariş yap
            return View(values);
        }
        public IActionResult History()
        {
            var values = orderManager.GetAll("Customer");
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
        [HttpGet]
        public IActionResult Add(int CustomerId) // Sipariş tablosu için telefon, Sokak id alınması lazım sipariş detay için ürün id ve adeti alınması lazım
        {
            //PhoneOrder tablosuna ekleme yapılacak sonra PhoneOrderDetails tablosuna PhoneOrder id ile ürün eklemesi yapılacak.
            ViewData["Phones"] = VMPhones.GetAll();
            ViewData["Streets"] = new VMRegion().streets;

            return View(orderManager.GetAll());
        }
        [HttpPost]
        public IActionResult Add()
        {
            return RedirectToAction("Index");
        }
        public IActionResult CustomerControl(string phoneNo)
        {
            //Ekli müşteri mi ?
            ViewData["Phones"] = VMPhones.GetAll();
            ViewData["Streets"] = null;
            if (!String.IsNullOrEmpty(phoneNo))
            {
                CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
                var values = customerManager.GetAll(x => x.PhoneNumber == phoneNo);
                if (values.Count == 0)
                {
                    ViewData["Streets"] = new VMRegion().streets;
                    return View(new Customer { PhoneNumber = phoneNo });
                }
                else
                {
                    return RedirectToAction("Add", values.First().Id);//<--
                }
            }
            else
            {
                return View();
            }


        }
        public IActionResult CustomerAdd(Customer customer)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
            customerManager.Add(customer);
            int CustomerId = customerManager.GetAll().Last().Id;
            return RedirectToAction("Add", CustomerId);
        }
    }
}
