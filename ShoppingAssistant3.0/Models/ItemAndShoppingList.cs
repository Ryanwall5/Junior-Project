using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    public class ItemAndShoppingList
    {
        public int Id { get; set; }

        public int ShoppingListId { get; set; }

        public virtual ShoppingList ShoppingList { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }


        public int? QuantityBought { get; set; }
    }
}