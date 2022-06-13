using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Rys.Controllers
{
    public class TableController : Controller
    {
        GenericManager<Table> tableManager = new GenericManager<Table>(new EfGenericRepository<Table>());
        public IActionResult Index()
        {
            var values = tableManager.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var values = tableManager.Get(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Details(Table table)
        {
            table.Status = true;
            tableManager.Update(table);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            Table table = new Table()
            {
                Status = true,
            };

            tableManager.Add(table);
            return RedirectToAction("Index");
        }

        public IActionResult Status(int id)
        {
            var table = tableManager.Get(id);
            if (tableManager.Get(id).Status)
            {
                table.Status = false;
            }
            else
            {
                table.Status = true;
            }
            tableManager.Update(table);
            return RedirectToAction("Index");
        }
        public IActionResult FollowUp()
        {
            var values = tableManager.GetAll();
            return View(values);
        }
    }
}
