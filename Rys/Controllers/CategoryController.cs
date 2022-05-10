﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        public IActionResult Details(int id)
        {
            var values = categoryManager.Get(id);
            return View(values);
        }
    }
}
