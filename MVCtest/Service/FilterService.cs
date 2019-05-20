using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCtest.Models;
using MVCtest.ViewModels;

namespace MVCtest.Service
{
    public class FilterService 
    {
        private DBModel db;
        private List<ProductViewModel> productList;
        private List<Sub_Categroy> categories;
        private List<Product> products;
        private List<Sub_Categroy> list;

        public FilterService()
        {
            db = new DBModel();
            productList = new List<ProductViewModel>();
            categories = new List<Sub_Categroy>();
            products = new List<Product>();
            products = db.Products.ToList();
            list = new List<Sub_Categroy>();
        }

        public List<ProductViewModel> CategoriesFilter(string value)
        {
            List<string> valueArr = new List<string>();
            valueArr = value.Split(',').ToList();

            foreach(var item in valueArr)
            {
                list = db.Sub_Categroy.Where(x => x.Category_Name == item).ToList();
                categories.AddRange(list);
            }
            var result =
                from c in categories
                join p in products
                on c.Category_ID equals p.Category_Id
                select
                new ProductViewModel
                {
                    Product_Id = p.Product_Id,
                    Product_Name = p.Product_Name,
                    Product_Image = p.Product_Image,
                    Category_Id = c.Category_ID,
                    Size = p.Size,
                    Stock =p.Stock,
                    UnitPrice =p.UnitPrice
                };
            productList = result.ToList();
            return productList;

        }
    }
}