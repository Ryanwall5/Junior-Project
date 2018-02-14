using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public IList<ItemAndTag> ItemsAndTags { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}