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


        public CategoryListViewModel GetAllCategory() {

            DBModel context = new DBModel();
            DbRepository<CategoryGroup> Crepo = new DbRepository<CategoryGroup>(context);
            DbRepository<Sub_Categroy> Srepo = new DbRepository<Sub_Categroy>(context);
            CategoryListViewModel result = new CategoryListViewModel();
            result.Items = new List<CategoryViewModel>();
            

            var listItem = Crepo.GetAll();

            foreach(var item in listItem)
            {
                var sub = Srepo.GetAll().Where((x)=>x.Category_ID == item.Category_Id);
                CategoryViewModel c = new CategoryViewModel()
                {
                    Category_Id = item.Category_Id,
                    Category_Name = item.Category_Name,
                    Sub_Categroy = sub.ToList()
                    
                };
                result.Items.Add(c);
            }
            return result;
        }
        public void GetSingleCategory(int Category_ID)
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
                new CategoryViewModel
                { Category_Id = c.Category_Id, Category_Name = s.Category_Name };
        }
    }
}