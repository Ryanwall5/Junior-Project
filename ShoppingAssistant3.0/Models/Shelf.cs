using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    public class Shelf
    {
        public Shelf() { }
        public Shelf(string name, int seccount)
        {
            SectionCount = seccount;
            Name = name;
            Sections = new List<Section>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int SectionCount { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IList<Section> Sections { get; set; }
    }
}