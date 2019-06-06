using MVCtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.ViewModels
{
    public class CategoryViewModel
    {
        public int Category_Id { get; set; }

        public string Category_Name { get; set; }

        public virtual ICollection<Sub_Categroy> Sub_Categroy { get; set; }
    }
}