using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }
        public Category Category { get; set; }
        public List<TableOrderDetail> TableOrderDetails { get; set; }
        public List<PhoneOrderDetail> PhoneOrderDetails { get; set; }
    }
}
