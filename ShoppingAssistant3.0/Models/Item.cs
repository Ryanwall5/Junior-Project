using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    public class Item
    {
        public Item()
        {
            ItemAndLists = new List<ItemAndShoppingList>();
        }

        [Key]
        public int Id { get; set; }

        public int StoreId { get; set; }

        //i think this needs to be a collection of stores. but i probably need to make a linking table for
        //items and the stores that they are in.
        public virtual Store Store { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Allergens { get; set; }

        [Display(Name = "In Stock")]
        [Required]
        public bool InStock { get; set; }

        [Display(Name = "Stock Amount")]
        [Required]
        public int StockAmount { get; set; }


        [Required]
        public string Aisle { get; set; }

        [Required]
        public string Section { get; set; }

        //public int BrandId { get; set; }

        // public virtual Brand Brand { get; set; }

        public virtual IList<ItemAndTag> ItemAndTags { get; set; }
        
        public virtual IList<ItemAndShoppingList> ItemAndLists { get; set; }

    }
}