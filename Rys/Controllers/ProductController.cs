using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            productManager.Add(product);
            return RedirectToAction("Index");
        }
    }
}
