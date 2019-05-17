using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public int ProductNo { get; set; }
        public string Unitprice { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
        public int Sum { get; set; }
        public string ProductImage { get; set; }
    }
}