using MVCtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class ProductListViewModel
    {
        public List<ProductViewModel> Items { get; set; }
        public List<ProductViewModel> data { get; set; }
    }
}