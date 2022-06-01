using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int StreetId { get; set; }
        public Street Street { get; set; }
        public string PhoneNumber { get; set; }
        public List<PhoneOrder> phoneOrders { get; set; }
    }
}
