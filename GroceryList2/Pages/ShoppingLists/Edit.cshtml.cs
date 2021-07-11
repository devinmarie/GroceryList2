using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryList2.Data;
using GroceryList2.Models;

namespace GroceryList2.Pages.ShoppingLists
{
    public class EditModel : PageModel
    {
        private readonly GroceryList2.Data.GroceryList2Context _context;

        public EditModel(GroceryList2.Data.GroceryList2Context context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShoppingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListExists(ShoppingList.ShoppingListId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShoppingListExists(int id)
        {
            return _context.ShoppingList.Any(e => e.ShoppingListId == id);
        }
    }
}
