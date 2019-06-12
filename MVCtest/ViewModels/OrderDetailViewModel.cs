using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class OrderDetailViewModel
    {
        public int orderId { get; set; }
        public string productName { get; set; }
        public int? unitPrice { get; set; }
        public int? quantity { get; set; }
        public string size { get; set; }
        public string color { get; set; }
    }
}