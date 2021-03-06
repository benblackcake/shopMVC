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

        //4種方法看到產品列表 1.網址~/shopProduct(GetProduct())  2.上方搜尋(SearchProducts())  
        //                  3.大分類(GetCategoryProduct())(包含特價分類(GetSalesProducts())  4.小分類(GetSubCategoryProduct())
        public ProductListViewModel GetProducts()
        {
            ProductListViewModel result = new ProductListViewModel();
            result.Items = new List<ProductViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> repo = new DbRepository<Product>(contex);
            DbRepository<Product_Detail> repd = new DbRepository<Product_Detail>(contex);
            DbRepository<Sale> res = new DbRepository<Sale>(contex);


            foreach (var item in (repo.GetAll().OrderBy((x) => x.Product_Id)))
            {
                
                if (item.Product_Sale == "1")  //判斷是否為特價商品
                {                                   
                    foreach (var item2 in (res.GetAll().Where((x) => x.Sale_Product == item.Product_Name)))
                    {
                        var pd = repd.GetAll().Where((x) => x.Product_Id == item.Product_Id);
                        ProductViewModel p = new ProductViewModel()
                        {                          
                            Product_Name = item.Product_Name,
                            UnitPrice = item2.Sale_UnPrice,   //更改價格
                            Category_Id = item.Category_Id,
                            Product_Image = item.Product_Image,
                            Product_Detail = pd.ToList()                       
                        };
                        result.Items.Add(p);
                    }
                    
                }
                else
                {
                    var pd = repd.GetAll().Where((x) => x.Product_Id == item.Product_Id);
                    ProductViewModel p = new ProductViewModel()
                    {
                        
                        Product_Name = item.Product_Name,
                        UnitPrice = item.UnitPrice,
                        Category_Id = item.Category_Id,
                        Product_Image = item.Product_Image,
                        Product_Detail = pd.ToList()
                       


                    };
                    result.Items.Add(p);
                }
                   
               
               
            }
            return result;
        }

        public ProductListViewModel GetSalesProducts()
        {
            ProductListViewModel result = new ProductListViewModel();
            result.Items = new List<ProductViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> repo = new DbRepository<Product>(contex);
            DbRepository<Product_Detail> repd = new DbRepository<Product_Detail>(contex);
            DbRepository<Sale> res = new DbRepository<Sale>(contex);

            foreach (var item in (repo.GetAll().OrderBy((x) => x.Product_Id))) 
            {
               
                if (item.Product_Sale == "1")
                {
                    foreach (var item2 in (res.GetAll().Where((x) => x.Sale_Product == item.Product_Name)))
                    {
                        var pd = repd.GetAll().Where((x) => x.Product_Id == item.Product_Id);
                        ProductViewModel p = new ProductViewModel()
                        {
                            Product_Id = item.Product_Id,
                            Product_Name = item.Product_Name,
                            UnitPrice = item2.Sale_UnPrice,
                            Category_Id = item.Category_Id,
                            Product_Image = item.Product_Image,
                            Product_Detail = pd.ToList()
                            
                        };
                        result.Items.Add(p);
                    }
                   
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
            DbRepository<Product_Detail> repd = new DbRepository<Product_Detail>(contex);
            DbRepository<Sale> res = new DbRepository<Sale>(contex);

            foreach (var item in (repo.GetAll().Where((x) => x.Product_Name.Contains(Product_NAME))))
            {
                var pd = repd.GetAll().Where((x) => x.Product_Id == item.Product_Id);
                if (item.Product_Sale == "1")
                {
                    foreach (var item2 in res.GetAll().Where((x) => x.Sale_Product == item.Product_Name))
                    {
                        ProductViewModel p = new ProductViewModel()
                        {
                            Product_Id = item.Product_Id,
                            Product_Name = item.Product_Name,
                            UnitPrice = item2.Sale_UnPrice,
                           
                            Category_Id = item.Category_Id,
                            Product_Image = item.Product_Image,

                            Product_Detail = pd.ToList()
                        };
                        result.Items.Add(p);
                    }
                }
                else
                {
                    ProductViewModel p = new ProductViewModel()
                    {
                        Product_Id = item.Product_Id,
                        Product_Name = item.Product_Name,
                        UnitPrice = item.UnitPrice,

                        Category_Id = item.Category_Id,
                        Product_Image = item.Product_Image,
                        Product_Detail = pd.ToList()

                    };
                    result.Items.Add(p);
                }
               
            }
            return result;
        }

        public ProductListViewModel GetSubCategoryProduct(int categoryId) {
            ProductListViewModel result = new ProductListViewModel();
            result.Items = new List<ProductViewModel>();
            DBModel contex = new DBModel();
            DbRepository<Product> Prepo = new DbRepository<Product>(contex);
            DbRepository<Sub_Categroy> Srepo = new DbRepository<Sub_Categroy>(contex);
            DbRepository<Product_Detail> repd = new DbRepository<Product_Detail>(contex);
            DbRepository<Sale> res = new DbRepository<Sale>(contex);

            foreach (var item in Prepo.GetAll().Where((x)=>x.Category_Id==categoryId))  
            {
                var pd = repd.GetAll().Where((x) => x.Product_Id == item.Product_Id);
                if (item.Product_Sale == "1")
                {
                    foreach (var item2 in res.GetAll().Where((x) => x.Sale_Product == item.Product_Name))
                    {
                        ProductViewModel p = new ProductViewModel()
                        {
                            Product_Id = item.Product_Id,
                            Product_Name = item.Product_Name,
                            UnitPrice = item2.Sale_UnPrice,
                            
                            Category_Id = item.Category_Id,
                            Product_Image = item.Product_Image,

                            Product_Detail = pd.ToList()
                        };
                        result.Items.Add(p);
                    }
                }
                else
                {
                    ProductViewModel p = new ProductViewModel()
                    {
                        Product_Id = item.Product_Id,
                        Product_Name = item.Product_Name,
                        UnitPrice = item.UnitPrice,
                        Category_Id = item.Category_Id,
                        Product_Image = item.Product_Image,

                        Product_Detail = pd.ToList()
                    };
                    result.Items.Add(p);
                }
                
                
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
            DbRepository<Product_Detail> repd = new DbRepository<Product_Detail>(contex);
            DbRepository<Sale> res = new DbRepository<Sale>(contex);




            foreach (var item in Prepo.GetAll())
            {
                foreach (var test in Srepo.GetAll().Where((x) => x.Sub_Category_ID == item.Category_Id && x.Category_ID == categoryId))
                {
                    var pd = repd.GetAll().Where((x) => x.Product_Id == item.Product_Id);
                    if (item.Product_Sale == "1")
                    {
                        foreach(var item2 in res.GetAll().Where((x) => x.Sale_Product == item.Product_Name))
                        {
                            ProductViewModel p = new ProductViewModel()
                            {
                                Product_Id = item.Product_Id,
                                Product_Name = item.Product_Name,
                                UnitPrice = item2.Sale_UnPrice,
                               
                                Category_Id = item.Category_Id,
                                Product_Image = item.Product_Image,

                                Product_Detail = pd.ToList()
                            };
                            result.Items.Add(p);
                        }
                    }
                    else
                    {
                        ProductViewModel p = new ProductViewModel()
                        {
                            Product_Id = item.Product_Id,
                            Product_Name = item.Product_Name,
                            UnitPrice = item.UnitPrice,
                            
                            Category_Id = item.Category_Id,
                            Product_Image = item.Product_Image,

                            Product_Detail = pd.ToList()
                        };
                        result.Items.Add(p);
                    }
                }
               


            }
            return result;

            //var tmp = from p in Prepo.GetAll()
            //          join s in Srepo.GetAll()
            //          on p.Category_Id equals s.Sub_Category_ID
            //          join r in repd.GetAll()
            //          on p.Product_Id equals r.Product_Id
            //          where s.Category_ID == categoryId
            //          //join c in Crepo.GetAll()
            //          //on s.Category_ID equals categoryId
            //          select new ProductViewModel
            //          {
            //              Product_Id = p.Product_Id,
            //              Product_Name = p.Product_Name,
            //              Product_Image = p.Product_Image,
            //              UnitPrice = p.UnitPrice,
            //              Product_Detail = 
                         
            //              //Size = p.Size,
            //              //Stock = p.Stock
            //          };

            //foreach (var item in tmp)
            //{
            //    result.Items.Add(item);
            //}
            //return result;
        }

        public ProductViewModel GetProductDetail(int id) {
            DBModel contex = new DBModel();
            DbRepository<Product> repoProduct = new DbRepository<Product>(contex);
            DbRepository<Product_Detail> repoProductDetail = new DbRepository<Product_Detail>(contex);

            Product p =repoProduct.GetAll().FirstOrDefault((x) => x.Product_Id==id);
            var price = contex.Product.ToList().Join(contex.Sale.ToList(),
                                                     t1 => t1.Product_Name,
                                                     t2 => t2.Sale_Product,
                                                     (t1, t2) => new { pid = t1.Product_Id, t1.Product_Sale, t2.Sale_UnPrice })
                                                     .FirstOrDefault(x => x.pid == id && x.Product_Sale == "1");
            var realprice = p.UnitPrice;
            if (price != null)
            {
                realprice = price.Sale_UnPrice;
            }
            else
            {
                realprice = p.UnitPrice;
            }


            List<string> size = new List<string>();

            var result = repoProduct.GetAll().Join(repoProductDetail.GetAll(),
                                                  t1 => t1.Product_Id,
                                                  t2 => t2.Product_Id,
                                                 (t1, t2) => new { id = t1.Product_Id, size = t2.Size })
                                                 .Where(x=>x.id==id)
                                                 .GroupBy(x => new { x.size });                                                 
            foreach(var i in result)
            {
                size.Add(i.Key.size);
            }
                
            ProductViewModel pro = new ProductViewModel() {
                Product_Id=p.Product_Id,
                Product_Name=p.Product_Name,
                UnitPrice=realprice,
                Product_Image=p.Product_Image,
                Size = size
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
        public void updatesale(string Sale_Product)
        {

            DBModel context = new DBModel();
            var result = context.Product.SingleOrDefault(x => x.Product_Name == Sale_Product && x.Product_Sale == "0");
                result.Product_Sale ="1";
                context.SaveChanges();
        }
        public void updatesale1(string Sale_Product)
        {

            DBModel context = new DBModel();
            var result = context.Product.SingleOrDefault(x => x.Product_Name == Sale_Product && x.Product_Sale == "1");
            result.Product_Sale = "0";
            context.SaveChanges();
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