using MVCtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class ProductViewModel
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int? Category_Id { get; set; }
        public string UnitPrice { get; set; }
       
        public string Product_Image { get; set; }

        
        public virtual ICollection<Product_Detail> Product_Detail { get; set; }

        //public string Size { get; set; }
        //public string Color { get; set; }
        //public int? Stock { get; set; }
        //public string Product_Detail { get; set; }

        //public double Weight { get; set; }

        public int Seller_ID { get; set; }
        public string CategoryGroup_Name { get; set; }
        public string Sub_Category_Name { get; set; }

    }
}