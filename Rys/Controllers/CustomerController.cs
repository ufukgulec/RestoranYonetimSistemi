using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Rys.Models;

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
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult validationResult = validationRules.Validate(customer);
            if (validationResult.IsValid)
            {
                customerManager.Add(customer);
                return RedirectToAction("Index");
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
    }
}
