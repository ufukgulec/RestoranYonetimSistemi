using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        public IActionResult Delete(int id)
        {
            ProductManager productManager = new ProductManager(new EfProductRepository());
            productManager.DeleteWithCategoryId(id);
            //Kategori silerken ürünlerde silinmeli....
            categoryManager.Delete(categoryManager.Get(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(category);
            if (validationResult.IsValid)
            {
                category.Status = true;
                categoryManager.Add(category);
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
    }
}
