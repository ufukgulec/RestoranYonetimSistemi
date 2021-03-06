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
        GenericManager<PhoneOrderDetail> DetailManager = new GenericManager<PhoneOrderDetail>(new EfGenericRepository<PhoneOrderDetail>());
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
        public IActionResult Add(IEnumerable<VMBucket> BucketList, int currentCustomer)
        {
            PhoneOrder newPhoneOrder = new PhoneOrder()
            {
                CustomerId = currentCustomer,
                OrderTime = DateTime.Now,
                Status = true,

            };
            orderManager.Add(newPhoneOrder);

            int currentOrderId = orderManager.GetAll().Last().Id;
            OrderDetailAdd(currentOrderId, BucketList);
            return RedirectToAction("Index", "PhoneOrder");
        }

        private void OrderDetailAdd(int currentOrderId, IEnumerable<VMBucket> BucketList)
        {
            foreach (var item in BucketList)
            {
                PhoneOrderDetail detail = new PhoneOrderDetail()
                {
                    PhoneOrderId = currentOrderId,
                    ProductId = item.ProductId,
                    ProductCount = item.ProductCount
                };
                DetailManager.Add(detail);
            }
        }
    }
}
