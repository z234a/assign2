﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace assign2.Data
{
    public class assign2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public assign2Context() : base("name=assign2Context")
        {
        }

        public System.Data.Entity.DbSet<assign2.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<assign2.Models.Topic> Topics { get; set; }
    }
}
