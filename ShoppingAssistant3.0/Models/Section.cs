using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    public class Section
    {
        public Section() { }
        public Section(string nameofsection, string shelfwithsectionumandcoords)
        {
            var secarray = shelfwithsectionumandcoords.Split('_');
            Name = nameofsection;
            ShelfName = secarray[0];
            Number = Convert.ToInt32(secarray[1]);
            Xcoord = Convert.ToDouble(secarray[2]);
            Ycoord = Convert.ToDouble(secarray[3]);
            Width = Convert.ToDouble(secarray[4]);
            Height = Convert.ToDouble(secarray[5]);
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string ShelfName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Xcoord { get; set; }

        [Required]
        public double Ycoord { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }
    }
}