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
        public bool Create(CustomerViewModel input) {
            DBModel context = new DBModel();
            DbRepository<Customer> repo = new DbRepository<Customer>(context);
            if (repo.GetAll().FirstOrDefault((x) => x.Customer_Email == input.Customer_Email) == null)
            {
                Customer entity = new Customer()
                {
                    Customer_Name = input.Customer_Name,
                    Customer_Email = input.Customer_Email,
                    Customer_BirDate = input.Customer_BirDate,
                    Customer_Phone = input.Customer_Phone,
                    User_Password = input.User_Password
                };
                repo.Create(entity);
                context.SaveChanges();
                return true;
            }
            else return false;

        }

        public CustomerViewModel GetMember(string email,string password) {
            
            DBModel context = new DBModel();
            DbRepository<Customer> repo = new DbRepository<Customer>(context);

            string pwd = Helper.EncodePassword(password);
            Customer entity = repo.GetAll().FirstOrDefault((x) => x.Customer_Email == email & x.User_Password == pwd);

            if (entity != null) {
                CustomerViewModel cvm = new CustomerViewModel()
                {
                    Customer_ID = entity.Customer_ID,
                    Customer_Name = entity.Customer_Name,
                    Customer_Email = entity.Customer_Email,

                };
                return cvm;
            } 
            else return null;

        }
    }
}