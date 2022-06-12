using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Rys.Models;
using System;
using System.Linq;

namespace Rys.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        VMRegion regionModel = new VMRegion();
        public IActionResult Index()
        {
            var values = customerManager.GetAll("Street", "Street.District");
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {

            ViewData["Streets"] = regionModel.streets;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            var previousPage = Request.Headers["Referer"].ToString();

            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult validationResult = validationRules.Validate(customer);
            if (validationResult.IsValid)
            {
                customerManager.Add(customer);

                if (previousPage.Contains("CustomerControl"))
                {
                    int currentCustomerId = customerManager.GetAll().Last().Id;
                    return RedirectToAction("Add", "PhoneOrder", new { @id = currentCustomerId });
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewData["Streets"] = regionModel.streets;
                return View();
            }

        }
        public IActionResult Delete(int id)
        {
            customerManager.Delete(customerManager.Get(id));
            return RedirectToAction("Index");
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
                    return RedirectToAction("Add", "PhoneOrder", new { @id = currentCustomerId });//<--
                }
            }
            else
            {
                return View();
            }


        }
    }
}
