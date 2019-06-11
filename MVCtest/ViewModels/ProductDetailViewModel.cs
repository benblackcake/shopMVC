using MVCtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class ProductDetailViewModel
    {
        
        public int Product_Detail_Id { get; set; }

        public int Product_Id { get; set; }
   
        public string Color { get; set; }
      
        public string Size { get; set; }

        public int? Stock { get; set; }

        public virtual ICollection<Product> Product { get; set; }


        public string Product_Name { get; set; }
        public int? Category_Id { get; set; }
        public string UnitPrice { get; set; }
        public string Product_Image { get; set; }

    }
}