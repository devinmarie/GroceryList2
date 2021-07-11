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
    public class DeleteModel : PageModel
    {
        private readonly GroceryList2.Data.GroceryList2Context _context;

        public DeleteModel(GroceryList2.Data.GroceryList2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ShoppingList ShoppingList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShoppingList = await _context.ShoppingList.FirstOrDefaultAsync(m => m.ShoppingListId == id);

            if (ShoppingList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShoppingList = await _context.ShoppingList.FindAsync(id);

            if (ShoppingList != null)
            {
                _context.ShoppingList.Remove(ShoppingList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
