using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCtest.Service
{
    public class SaleService
    {
        public SaleListViewModel GetAllSale()
        {
            SaleListViewModel result = new SaleListViewModel();
            result.data = new List<SaleViewModel>();
            DBModel context = new DBModel();
            DbRepository<Sale> repo = new DbRepository<Sale>(context);
            foreach (var item in repo.GetAll().OrderBy((x) => x.Sale_Product))
            {
                SaleViewModel s = new SaleViewModel()
                {
                    Sale_ID = item.Sale_ID,
                    Sale_Product = item.Sale_Product,
                    Sale_UnPrice = item.Sale_UnPrice,
                    Sale_FristDate = item.Sale_FristDate,
                    Sale_LastDate = item.Sale_LastDate

                };
                result.data.Add(s);
            }
            return result;

        }
        public bool Create(SaleViewModel input)
        {
            DBModel context = new DBModel();
            DbRepository<Sale> repo = new DbRepository<Sale>(context);
            if (repo.GetAll().FirstOrDefault((x) => x.Sale_Product == input.Sale_Product)==null)
            {
                Sale entity = new Sale()
                {
                    Sale_Product = input.Sale_Product,
                    Sale_UnPrice = input.Sale_UnPrice,
                    Sale_FristDate=input.Sale_FristDate,
                    Sale_LastDate = input.Sale_LastDate
                
                };
                repo.Create(entity);
                context.SaveChanges();
                return true;
            }
            else return false;

        }
        public void Delete(int id)
        {
            DBModel context = new DBModel();
            DbRepository<Sale> repo = new DbRepository<Sale>(context);
            Sale cus = repo.GetAll().FirstOrDefault((x) => x.Sale_ID == id);
            repo.Delete(cus);
            context.SaveChanges();
            
        }



    }
}