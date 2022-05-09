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
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public string PhoneNumber { get; set; }
        public int StreetId { get; set; }
        public Street Street { get; set; }
        public List<PhoneOrderDetail> PhoneOrderDetails { get; set; }
    }
}
