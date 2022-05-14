using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductRepository : GenericRepository<Product>, IProductDal
    {
        public void DeleteWithCategoryId(int id)
        {
            using (var c = new Context())
            {
                c.Products.RemoveRange(c.Products.Where(p => p.CategoryId == id));
            }
        }

        public List<Product> GetAllWithCategory()
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Category).ToList();
            }
        }

        public Product GetWithCategory(int id)
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Category).ToList().Find(x => x.Id == id);
            }
        }
    }
}
