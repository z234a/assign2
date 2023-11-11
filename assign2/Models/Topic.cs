﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assign2.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}