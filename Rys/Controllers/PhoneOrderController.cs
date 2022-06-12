using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Rys.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rys.Controllers
{
    public class PhoneOrderController : Controller
    {
        #region Managers
        PhoneOrderManager orderManager = new PhoneOrderManager(new EfOrderRepository<PhoneOrder>());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        #endregion
        public IActionResult Index()
        {
            var values = orderManager.GetAll("Customer").Where(x => x.OrderTime.Date == System.DateTime.Now.Date).ToList();//Günlük siparişler
            return View(values);
        }
        public IActionResult History()
        {
            var values = orderManager.GetAll("Customer");//Tüm Siparişler
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
        public IActionResult Add(int id) // Sipariş tablosu için telefon, Sokak id alınması lazım sipariş detay için ürün id ve adeti alınması lazım
        {
            var currrentCustomer = VMCustomer.Get(id);
            ViewData["Customer"] = currrentCustomer;

            return View(categoryManager.GetAll("Products").Where(x => x.Status).Where(x => x.Products.Count != 0).ToList());
        }
        [HttpPost]
        public JsonResult Add(IEnumerable<VMBucket> BucketList, int currentCustomer)
        {
            var a = BucketList;
            return Json(data: "data success");
        }
        public IActionResult CustomerControl(string phoneNo)
        {
            ViewData["Phones"] = VMPhones.GetAll();
            ViewData["Streets"] = null;
            if (!String.IsNullOrEmpty(phoneNo))
            {
                var values = customerManager.GetAll(x => x.PhoneNumber == phoneNo);
                if (values.Count == 0)
                {
                    ViewData["Streets"] = new VMRegion().streets;
                    return View(new Customer { PhoneNumber = phoneNo });
                }
                else
                {
                    var currentCustomerId = values.First().Id;
                    return RedirectToAction("Add", new { @id = currentCustomerId });//<--
                }
            }
            else
            {
                return View();
            }
        }
    }
}
