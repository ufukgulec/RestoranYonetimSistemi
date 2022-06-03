using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Rys.Models
{
    public static class VMPhones
    {
        private static CustomerManager manager = new CustomerManager(new EfCustomerRepository());

        public static List<Customer> GetAll()
        {
            var values = manager.GetAll();
            return values;
        }
    }
}
