using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public List<TableOrder> tableOrders { get; set; }
    }
}
