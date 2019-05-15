using MVCtest.Controllers;
using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System.Diagnostics;
using System.Linq;

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

        public CustomerViewModel GetMember(string email,string password) {
            
            DBModel context = new DBModel();
            DbRepository<Customer> repo = new DbRepository<Customer>(context);

            string pwd = Helper.EncodePassword(password);
            Customer customer = repo.GetAll().FirstOrDefault((x) => x.Customer_E_mail == email & x.User_Password == pwd);

            if (customer != null) {
                CustomerViewModel cvm = new CustomerViewModel()
                {
                    Customer_ID = customer.Customer_ID,
                    Customer_Name = customer.Customer_Name,
                    Customer_E_mail = customer.Customer_E_mail,

                };
                return cvm;
            } 
            else return null;
        }
    }
}