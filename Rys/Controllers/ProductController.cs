using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Rys.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            ViewData["Categories"] = categoryManager.GetAll("Products");
            var values = productManager.GetAll("Category");
            return View(values);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewData["Categories"] = categoryManager.GetAll();
            var values = productManager.GetWithCategory(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Details(Product product)
        {
            productManager.Update(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Categories"] = categoryManager.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult validationResult = validationRules.Validate(product);
            ViewData["Categories"] = categoryManager.GetAll();

            if (validationResult.IsValid)
            {
                productManager.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            productManager.Delete(productManager.Get(id));
            return RedirectToAction("Index");
        }
    }
}
