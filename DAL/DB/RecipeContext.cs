using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    class RecipeContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Watch> Watches { get; set; }

    }

   
}
