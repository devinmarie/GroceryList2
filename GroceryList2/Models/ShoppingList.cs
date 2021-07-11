using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryList2.Models
{
    public class ShoppingList
    {
        public int ShoppingListId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductQty { get; set; }
        public bool Recipe { get; set; }
        public string Buyer { get; set; }
        public DateTime? DatePurchased { get; set; }
    }

    public class PurchaseModel
    {
        public string Name { get; set; }
    }
}
