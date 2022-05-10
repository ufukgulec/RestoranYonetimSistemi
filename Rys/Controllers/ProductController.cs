using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Rys.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            ViewData["Categories"] = categoryManager.GetAll();
            var values = productManager.GetAll("Category");
            return View(values);
        }
        public IActionResult Details(int id)
        {
            var values = productManager.Get(id);
            return View(values);
        }
    }
}
