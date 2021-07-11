using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryList2.Data;
using GroceryList2.Models;

namespace GroceryList2.Pages.ShoppingLists
{
    public class CreateModel : PageModel
    {
        private readonly GroceryList2.Data.GroceryList2Context _context;

        public CreateModel(GroceryList2.Data.GroceryList2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShoppingList ShoppingList { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShoppingList.Add(ShoppingList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
