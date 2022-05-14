using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Rys.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = categoryManager.GetAll("Products");
            return View(values);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var values = categoryManager.Get(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Details(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            category.Status = true;
            categoryManager.Add(category);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            ProductManager productManager = new ProductManager(new EfProductRepository());
            productManager.DeleteWithCategoryId(id);
            //Kategori silerken ürünlerde silinmeli....
            categoryManager.Delete(categoryManager.Get(id));
            return RedirectToAction("Index");
        }
    }
}
