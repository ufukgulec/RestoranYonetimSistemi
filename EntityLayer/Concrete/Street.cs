﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Street
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
    }
}
