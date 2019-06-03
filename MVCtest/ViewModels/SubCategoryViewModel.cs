using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCtest.Models;

namespace MVCtest.ViewModels
{
    public class SubCategoryViewModel
    {
        public int Sub_Category_ID { get; set; }

        public string Category_Name { get; set; }

        public int Category_Id { get; set; }

        public virtual ICollection<CategoryGroup> CategoryGroups { get; set; }
    }
}