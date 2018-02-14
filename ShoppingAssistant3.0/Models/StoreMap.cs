using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    public class StoreMap
    {

        public StoreMap()
        {

        }
        public StoreMap(int aisles, int shelvescount, bool back, bool right, bool left)
        {
            Aisles = aisles;
            ShelvesCount = shelvescount;
            BackWall = back;
            RightSection = right;
            LeftSection = left;
            Shelves = new List<Shelf>();

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Aisles { get; set; }
        [Required]
        public int ShelvesCount { get; set; }
        [Required]
        public bool BackWall { get; set; }
        [Required]
        public bool RightSection { get; set; }
        [Required]
        public bool LeftSection { get; set; }

        public virtual IList<Shelf> Shelves { get; set; }
    }
}