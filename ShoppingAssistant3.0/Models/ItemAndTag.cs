﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    public class ItemAndTag
    {
        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}