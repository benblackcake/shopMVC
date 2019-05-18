using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.Service
{
    public class ProductService
    {
        public ProductListViewModel GetProducts()
        {
            ProductListViewModel result = new ProductListViewModel();
            result.Items = new List<ProductViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> repo = new DbRepository<Product>(contex);

            foreach(var item in (repo.GetAll().OrderBy((x) => x.Product_Id))/*.Take(4)*/)    /* 增加 take(4)  --> 首頁取4筆*/
            {
                ProductViewModel p = new ProductViewModel()
                {
                    Product_Id = item.Product_Id,
                    Product_Name = item.Product_Name,
                    UnitPrice = item.UnitPrice,
                    Size = item.Size,
                    Stock = item.Stock,
                    Category_Id = item.Category_Id,
                    Product_Image=item.Product_Image
                    
                };
                result.Items.Add(p);
            }
            return result;
        }
    }
}