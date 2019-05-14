using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.Service
{
    public class LoginService
    {
        public bool Login(CustomerViewModel input)
        {
            DBModel context = new DBModel();
            DbRepository<Customer> repo = new DbRepository<Customer>(context);

            repo.GetAll();
            Customer c = new Customer();
            if (c.Customer_E_mail == input.Customer_E_mail && c.User_Password == input.User_Password)
            {
                return Convert.ToBoolean("<script>alert('這是一個用 JavaScriptResult 的顯示結果');</script>");
            }
            else
            {
                return false;
            }

        }
    }
}