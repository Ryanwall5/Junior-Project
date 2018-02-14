using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    public class ShoppingList
    {
        public ShoppingList()
        {
            ItemsAndLists = new List<ItemAndShoppingList>();
        }


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        //[NotMapped]
        //public string totalPrice
        //{
        //    get
        //    {
        //        var items = ItemsAndLists.Where(x => x.ShoppingListId == Id).ToList();
        //        var totalprice = items.Sum(x => x.Item.Price * x.QuantityBought);

        //        return "$" + totalPrice.ToString();
        //    }
        //}


        public virtual IList<ItemAndShoppingList> ItemsAndLists { get; set; }
    }
}