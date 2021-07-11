using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceryList2.Models;

namespace GroceryList2.Data
{
    public class GroceryList2Context : DbContext
    {
        public GroceryList2Context (DbContextOptions<GroceryList2Context> options)
            : base(options)
        {
        }

        public DbSet<GroceryList2.Models.ShoppingList> ShoppingList { get; set; }
    }
}
