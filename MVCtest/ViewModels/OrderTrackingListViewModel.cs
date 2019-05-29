using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCtest.Models;

namespace MVCtest.ViewModels
{
    public class OrderTrackingListViewModel
    {
        public List<OrderTrackingViewModel> Items { get; set; }
    }
}