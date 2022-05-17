using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PhoneOrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int PhoneOrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public PhoneOrder PhoneOrder { get; set; }
        public Product Product { get; set; }
    }
}
