using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryList2.Data;
using GroceryList2.Models;

namespace GroceryList2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly GroceryList2Context _context;

        public ShoppingListsController(GroceryList2Context context)
        {
            _context = context;
        }

        // GET: api/ShoppingLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingList>>> GetShoppingList()
        {
            return await _context.ShoppingList.ToListAsync();
        }

        // GET: api/ShoppingLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingList>> GetShoppingList(int id)
        {
            var shoppingList = await _context.ShoppingList.FindAsync(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return shoppingList;
        }

        // PUT: api/ShoppingLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingList(int id, ShoppingList shoppingList)
        {
            if (id != shoppingList.ShoppingListId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingList>> PostShoppingList(ShoppingList shoppingList)
        {
            _context.ShoppingList.Add(shoppingList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingList", new { id = shoppingList.ShoppingListId }, shoppingList);
        }

        // DELETE: api/ShoppingLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingList>> DeleteShoppingList(int id)
        {
            var shoppingList = await _context.ShoppingList.FindAsync(id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            _context.ShoppingList.Remove(shoppingList);
            await _context.SaveChangesAsync();

            return shoppingList;
        }

        private bool ShoppingListExists(int id)
        {
            return _context.ShoppingList.Any(e => e.ShoppingListId == id);
        }

        [HttpPut("purchase/{id}")]
        public ActionResult<ShoppingList> PurchaseItem([FromRoute] int id, [FromBody] PurchaseModel purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.ShoppingList.Find(id);
            if (item == null)
            {
                return BadRequest();
            }
            item.DatePurchased = DateTime.Now;
            item.Buyer = purchase.Name;
            _context.SaveChanges();
            return Ok(item);
        }


        [HttpDelete("purchase/{id}")]
        public ActionResult<ShoppingList> PurchaseItem([FromRoute] int id)
        {

            var book = _context.ShoppingList.Find(id);
            if (book == null)
            {
                return BadRequest();
            }
            book.DatePurchased = null;
            book.Buyer = null;
            _context.SaveChanges();
            return Ok(book);
        }

    }
}
