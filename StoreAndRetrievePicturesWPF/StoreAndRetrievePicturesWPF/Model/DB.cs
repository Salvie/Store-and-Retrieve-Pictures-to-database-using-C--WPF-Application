using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace StoreAndRetrievePicturesWPF.Model
{
    public class DB:DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
