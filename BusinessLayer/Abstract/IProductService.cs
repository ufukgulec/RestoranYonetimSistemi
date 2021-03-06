using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Product GetWithCategory(int id);
        List<Product> GetAllWithCategory();
        void DeleteWithCategoryId(int id);
    }
}
