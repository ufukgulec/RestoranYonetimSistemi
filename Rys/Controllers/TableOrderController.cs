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
    public class TableOrderController : Controller
    {
        #region Managers
        TableOrderManager orderManager = new TableOrderManager(new EfOrderRepository<TableOrder>());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        GenericManager<TableOrderDetail> DetailManager = new GenericManager<TableOrderDetail>(new EfGenericRepository<TableOrderDetail>());
        GenericManager<Table> tableManager = new GenericManager<Table>(new EfGenericRepository<Table>());
        #endregion
        public IActionResult Index()
        {
            var values = orderManager.GetAll("Table").Where(x => x.OrderTime.Date == System.DateTime.Now.Date).ToList();//Günlük siparişler
            return View(values);
        }
        public IActionResult History()
        {
            var values = orderManager.GetAll("Table");//Tüm Siparişler
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
            VMTableOrder vm = new VMTableOrder(orderManager.Get(id));
            return View(vm);
        }
        [HttpGet]
        public IActionResult Add(int id) // Sipariş tablosu için telefon, Sokak id alınması lazım sipariş detay için ürün id ve adeti alınması lazım
        {
            var currrentTable = tableManager.Get(id);
            ViewData["Table"] = currrentTable;

            return View(categoryManager.GetAll("Products").Where(x => x.Status).Where(x => x.Products.Count != 0).ToList());
        }
        [HttpPost]
        public IActionResult Add(IEnumerable<VMBucket> BucketList, int currentTable)
        {
            TableOrder newTableOrder = new TableOrder()
            {
                TableId = currentTable,
                OrderTime = DateTime.Now,
                Status = true,
                StaffId = 1,//<---

            };
            orderManager.Add(newTableOrder);

            int currentOrderId = orderManager.GetAll().Last().Id;
            OrderDetailAdd(currentOrderId, BucketList);
            return RedirectToAction("Index", "TableOrder");
        }

        private void OrderDetailAdd(int currentOrderId, IEnumerable<VMBucket> BucketList)
        {
            foreach (var item in BucketList)
            {
                TableOrderDetail detail = new TableOrderDetail()
                {
                    TableOrderId = currentOrderId,
                    ProductId = item.ProductId,
                    ProductCount = item.ProductCount
                };
                DetailManager.Add(detail);
            }
        }
    }
}
