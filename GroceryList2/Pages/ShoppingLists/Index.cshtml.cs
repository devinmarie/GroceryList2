using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryList2.Data;
using GroceryList2.Models;

namespace GroceryList2.Pages.ShoppingLists
{
    public class IndexModel : PageModel
    {
        private readonly GroceryList2.Data.GroceryList2Context _context;

        public IndexModel(GroceryList2.Data.GroceryList2Context context)
        {
            _context = context;
        }

        public IList<ShoppingList> ShoppingList { get;set; }

        public async Task OnGetAsync()
        {
            ShoppingList = await _context.ShoppingList.ToListAsync();
        }
    }
}
