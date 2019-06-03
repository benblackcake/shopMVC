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
            //var tmp =
            //    from c in Crepo.GetAll()
            //    join s in Srepo.GetAll()
            //    on c.Category_Id equals s.Category_ID
            //    select
            //    new CategoryViewModel
            //    {
            //        Category_Id = c.Category_Id,
            //        Category_Name = c.Category_Name,
            //        Sub_Categroy=c.Sub_Categroy

            //    };
            //result.Items = tmp.ToList();
            foreach (var item in Crepo.GetAll())
            {
                var sub = Srepo.GetAll().Where((x) => x.Category_ID == item.Category_Id);
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

        // -------- add

        public bool Create(CategoryViewModel input)
        {
            DBModel context = new DBModel();
            DbRepository<CategoryGroup> repo = new DbRepository<CategoryGroup>(context);
            if (repo.GetAll().FirstOrDefault((x) => x.Category_Name == input.Category_Name) == null)
            {
                CategoryGroup entity = new CategoryGroup()
                {
                    Category_Id = input.Category_Id,
                    Category_Name = input.Category_Name,
                    
                };
                repo.Create(entity);
                context.SaveChanges();
                return true;
            }
            else return false;

        }
        public bool AddSubCategory(CategoryViewModel input)
        {
            DBModel context = new DBModel();
            DbRepository<Sub_Categroy> Srepo = new DbRepository<Sub_Categroy>(context);
            if (Srepo.GetAll().FirstOrDefault((x) => x.Category_Name == input.Category_Name) == null)
            {
                Sub_Categroy entity = new Sub_Categroy()
                {
                    Sub_Category_ID = input.Category_Id,
                    Category_Name = input.Category_Name,    
                    //Category_ID = 
                    //Customer_Name = input.Customer_Name,
                    //Customer_Email = input.Customer_Email,
                    //Customer_Phone = input.Customer_Phone,
                    //User_Password = input.User_Password
                };
                Srepo.Create(entity);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}