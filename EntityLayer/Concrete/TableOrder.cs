using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TableOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public int TableId { get; set; }
        public int StaffId { get; set; }
    }
}
