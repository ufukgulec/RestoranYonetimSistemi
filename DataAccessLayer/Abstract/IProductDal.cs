using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        Product GetWithCategory(int id);
        List<Product> GetAllWithCategory();
        void DeleteWithCategoryId(int id);
    }
}
