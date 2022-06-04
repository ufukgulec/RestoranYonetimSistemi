﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Rys.Models;
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
        public IActionResult Add() // Sipariş tablosu için telefon, Sokak id alınması lazım sipariş detay için ürün id ve adeti alınması lazım
        {
            //PhoneOrder tablosuna ekleme yapılacak sonra PhoneOrderDetails tablosuna PhoneOrder id ile ürün eklemesi yapılacak.
            ViewData["Phones"] = VMPhones.GetAll();

            return View(orderManager.GetAll());
        }
    }
}
