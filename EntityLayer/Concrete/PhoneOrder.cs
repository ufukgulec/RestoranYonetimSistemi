using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PhoneOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public bool Status { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<PhoneOrderDetail> PhoneOrderDetails { get; set; }
    }
}
