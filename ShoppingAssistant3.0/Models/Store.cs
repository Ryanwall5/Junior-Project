using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingAssistant3._0.Models
{
    public class Store
    {

        [Required]
        [Key]
        public int Id { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public int? StoreMapId { get; set; }

        [ForeignKey("StoreMapId")]
        public virtual StoreMap StoreMap { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

   
        public SelectListItem GetListItem()
        {
            return new SelectListItem { Text = Name, Value = Id.ToString() };
        }

    }
}