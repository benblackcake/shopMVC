using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class SaleViewModel
    {
        public int Sale_ID { get; set; }
        public string Sale_Product { get; set; }
        public string Sale_UnPrice { get; set; }
        public DateTime Sale_FristDate { get; set; }

        public DateTime Sale_LastDate { get; set; }
    }
}