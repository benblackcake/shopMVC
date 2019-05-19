using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class CateViewModel
    {
        public int Category_Id { get; set; }

        public string Category_Name { get; set; }

        public int? Sub_Category_ID { get; set; }
    }
}