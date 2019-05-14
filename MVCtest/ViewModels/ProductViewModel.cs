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
        public int Category_Id { get; set; }
        public string UnitPrice { get; set; }
        public string Stock { get; set; }
        public string Product_Image { get; set; }
        public string Size { get; set; }

        public double Weight { get; set; }

        public int Seller_ID { get; set; }

    }
}