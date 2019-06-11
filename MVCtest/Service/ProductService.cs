﻿using MVCtest.Models;
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
            result.test = new List<ProductDetailViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> repo = new DbRepository<Product>(contex);
            DbRepository<Product_Detail> repd = new DbRepository<Product_Detail>(contex);



            foreach (var item in (repo.GetAll().OrderBy((x) => x.Product_Id))/*.Take(4)*/)    /* 增加 take(4)  --> 首頁取4筆*/
            {
                foreach (var item2 in (repd.GetAll().OrderBy((x) => x.Product_Detail_Id)))
                {
                    //var pd = repd.GetAll().Where((x) => x.Product_Id == item.Category_Id);
                    ProductDetailViewModel p = new ProductDetailViewModel()
                    {
                        //Product_Id = item.Product_Id,
                        Product_Name = item.Product_Name,
                        UnitPrice = item.UnitPrice,
                        Category_Id = item.Category_Id,
                        Product_Image = item.Product_Image,
                        //Product_Detail = pd.ToList()
                        Product_Detail_Id = item2.Product_Detail_Id,
                        Product_Id = item2.Product_Id,
                        Color = item2.Color,
                        Size = item2.Size,
                        Stock = item2.Stock
                       

                    };
                    result.test.Add(p);
                }
               
            }
            return result;
        }
        // add for top search
        public ProductListViewModel SearchProducts(string Product_NAME)
        {
            ProductListViewModel result = new ProductListViewModel();
            result.Items = new List<ProductViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> repo = new DbRepository<Product>(contex);

            foreach (var item in (repo.GetAll().Where((x) => x.Product_Name.Contains(Product_NAME))))
            {
                ProductViewModel p = new ProductViewModel()
                {
                    Product_Id = item.Product_Id,
                    Product_Name = item.Product_Name,
                    UnitPrice = item.UnitPrice,
                    //Size = item.Size,
                    //Stock = item.Stock,
                    Category_Id = item.Category_Id,
                    Product_Image = item.Product_Image

                };
                result.Items.Add(p);
            }
            return result;
        }

        public ProductListViewModel GetSubCategoryProduct(int categoryId) {
            ProductListViewModel result = new ProductListViewModel();
            result.Items = new List<ProductViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> Prepo = new DbRepository<Product>(contex);
            DbRepository<Sub_Categroy> Srepo = new DbRepository<Sub_Categroy>(contex);
            foreach (var item in Prepo.GetAll().Where((x)=>x.Category_Id==categoryId))  
            {
                ProductViewModel p = new ProductViewModel()
                {
                    Product_Id = item.Product_Id,
                    Product_Name = item.Product_Name,
                    UnitPrice = item.UnitPrice,
                    //Size = item.Size,
                    //Stock = item.Stock,
                    Category_Id = item.Category_Id,
                    Product_Image = item.Product_Image

                };
                result.Items.Add(p);
                
            }
            return result;
        }

        public ProductListViewModel GetCategoryProduct(int categoryId)
        {
            ProductListViewModel result = new ProductListViewModel();
            result.Items = new List<ProductViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> Prepo = new DbRepository<Product>(contex);
            DbRepository<Sub_Categroy> Srepo = new DbRepository<Sub_Categroy>(contex);

            var tmp = from p in Prepo.GetAll()
                      join s in Srepo.GetAll()
                      on p.Category_Id equals s.Sub_Category_ID
                      where s.Category_ID == categoryId
                      //join c in Crepo.GetAll()
                      //on s.Category_ID equals categoryId
                      select new ProductViewModel
                      {
                          Product_Id = p.Product_Id,
                          Product_Name = p.Product_Name,
                          Product_Image = p.Product_Image,
                          UnitPrice = p.UnitPrice,
                          //Size = p.Size,
                          //Stock = p.Stock
                      };

            foreach (var item in tmp)
            {
                result.Items.Add(item);
            }
            return result;
        }

        public ProductViewModel GetProductDetail(int id) {
            DBModel contex = new DBModel();
            DbRepository<Product> repo = new DbRepository<Product>(contex);

            Product p =repo.GetAll().FirstOrDefault((x) => x.Product_Id==id);
            ProductViewModel pro = new ProductViewModel() {
                Product_Id=p.Product_Id,
                Product_Name=p.Product_Name,
                UnitPrice=p.UnitPrice,
                Product_Image=p.Product_Image
            };
            return pro;
        }

        //API Create Product
        public bool CreatePorduct(Product pvm){
            DBModel contex = new DBModel();
            DbRepository<Product> repo = new DbRepository<Product>(contex);
            string filename = pvm.Product_Image;
            //FileUpload

            try {
                repo.Create(pvm);
                return true;
            } catch {//TODO
                return false;
            }
        }

        //API GetProduct
        public ProductListViewModel GetAllProduct(){
            ProductListViewModel result = new ProductListViewModel();
            result.data = new List<ProductViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> Prepo = new DbRepository<Product>(contex);
            DbRepository<Sub_Categroy> Srepo = new DbRepository<Sub_Categroy>(contex);
            DbRepository<CategoryGroup> Crepo = new DbRepository<CategoryGroup>(contex);

            var tmp = from p in Prepo.GetAll()
                      join s in Srepo.GetAll()
                      on p.Category_Id equals s.Sub_Category_ID
                      join cg in Crepo.GetAll()
                      on s.Category_ID equals cg.Category_Id
                      select new ProductViewModel
                      {
                          Product_Id = p.Product_Id,
                          Product_Name = p.Product_Name,
                          Product_Image = p.Product_Image,
                          UnitPrice = p.UnitPrice,
                          Sub_Category_Name= s.Category_Name,
                          CategoryGroup_Name=cg.Category_Name
                      };

            foreach (var item in tmp ) {
                result.data.Add(item);
            }
            return result;
        }


        public TopSaleListViewModel GetTopSale()
        {
            TopSaleListViewModel result = new TopSaleListViewModel();
            result.Item = new List<TopSaleViewModel>();
            DBModel context = new DBModel();
            //DbRepository<Order> repo = new DbRepository<Order>(context);
            var tmp = context.Database.SqlQuery<TopSaleViewModel>(@"select Product_Name, COUNT(*)Quantity
                                                                         FROM[dbo].[OrderDetail]
                                                                         Group By Product_Name
                                                                         Order By Quantity DESC;"
                                              );
            foreach (var i in tmp) {
                TopSaleViewModel sqv = new TopSaleViewModel()
                {
                    Product_Name = i.Product_Name,
                    Quantity = i.Quantity

                };
                result.Item.Add(sqv);

            }
            return result;

        }

        public List<int> GetTotalSum()
        {
            DBModel context = new DBModel();
            var tmp = context.Database.SqlQuery<int>(@"select SUM(CAST(UnitPrice AS int))Total
                                                                    FROM[dbo].[OrderDetail];"
                                  );


            return tmp.ToList();

        }

    }
}