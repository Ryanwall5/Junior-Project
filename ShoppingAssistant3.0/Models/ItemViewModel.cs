using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingAssistant3._0.Models
{
    [NotMapped]
    public class ItemViewModel : Item
    {


    
        public string priceformatted
        {
            get
            {
                string price = "$" + Price.ToString("0.##");
                return price;
            }
        }


    
        public string InstockYesOrNo
        {
            get
            {
                if (InStock)
                    return "Yes";
                else
                    return "No";

            }
        }

    }
}