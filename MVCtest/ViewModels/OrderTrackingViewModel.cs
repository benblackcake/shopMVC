using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class OrderTrackingViewModel
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Price { get; set; }
        public string Payment { get; set; }
        public string OrderState { get; set; } //新資料庫欄位

    }
}