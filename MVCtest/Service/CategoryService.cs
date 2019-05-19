using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.Service
{
    public class CategoryService
    {
        public void GetCate()
        {
            DBModel context = new DBModel();
            DbRepository<CategoryGroup> Crepo = new DbRepository<CategoryGroup>(context);
            DbRepository<Sub_Categroy> Srepo = new DbRepository<Sub_Categroy>(context);
            
            var result =
                from c in Crepo.GetAll()
                join s in Srepo.GetAll()
                on c.Category_Id equals s.Category_ID
                where c.Category_Name == "衣服"
                select
                new CateViewModel
                { Category_Id = c.Category_Id, Category_Name = s.Category_Name };
            
        }
    }
}