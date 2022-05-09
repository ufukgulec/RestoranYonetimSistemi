using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGenericRepository<T> : GenericRepository<T>, IGenericDal<T> where T : class
    {
    }
}
