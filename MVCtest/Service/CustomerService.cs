using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.Service
{
    public class CustomerService{
        /*        DBModel context = new DBModel();
        DbRepository<Customer> repo = new DbRepository<Customer>(context);
        */
        public void Create(CustomerViewModel input) {
            DBModel context = new DBModel();
            DbRepository<Customer> repo = new DbRepository<Customer>(context);
            Customer entity = new Customer()
            {
                //Customer_ID = input.Customer_ID,
                Customer_Name = input.Customer_Name,
                Customer_E_mail = input.Customer_E_mail,
                Customer_BirDate = input.Customer_BirDate,
                Customer_Phone =input.Customer_Phone,
                User_Password=input.User_Password
            };

            repo.Create(entity);
            context.SaveChanges();
            
        }

    }
}