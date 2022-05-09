using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Rys.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        public IActionResult Index()
        {
            var values = productManager.GetAllWithCategory();
            return View(values);
        }
    }
}
