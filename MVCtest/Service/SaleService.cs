using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
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

    }
}