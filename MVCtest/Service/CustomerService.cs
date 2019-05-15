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

        public bool GetMember(string email,string password) {
            
            DBModel context = new DBModel();
            DbRepository<Customer> repo = new DbRepository<Customer>(context);
            Debug.Print(email);
            Debug.Print(password);
            string pwd = Helper.EncodePassword(password);
            var customer = repo.GetAll().Where((x) => x.Customer_E_mail == email & x.User_Password == pwd);
            if (customer .Count()>0 )return true;
            else return false;
        }
    }
}