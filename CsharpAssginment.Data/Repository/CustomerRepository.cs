using CsharpAssginment.Data.Interfaces;
using CsharpAssginment.Data.Models;
using CsharpAssignment.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssginment.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<CustomerViewModel> GetAllCustomers()
        {
            List<CustomerViewModel> customerViews = new List<CustomerViewModel>();
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                List<Customer> customers = db.Customers.ToList() ?? new List<Customer>();
                foreach (Customer c in customers)
                {
                    CustomerViewModel customer = new CustomerViewModel();
                    customer.id = c.id;
                    customer.Name = c.Name;
                    customer.Address_1 = c.Address_1;
                    customer.Address_2 = c.Address_2;
                    customer.City = c.City1.Name;
                    customer.Country = c.Country;
                    customer.Post_Code = c.Post_Code;
                    customer.Email = c.Email;
                    customer.Mobile = c.Mobile;
                    customer.Birth_Date = c.Birth_Date;
                    customer.Active = c.Active;
                    customer.Create_Date = c.Create_Date;
                    customer.Update_Date = c.Update_Date;
                    customerViews.Add(customer);
                }
            }
            return customerViews;
        }

        public CustomerViewModel GetCustomer(int id)
        {
            CustomerViewModel customer = new CustomerViewModel();
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                Customer c = db.Customers.Find(id) ?? new Customer();
                customer.id = c.id;
                customer.Name = c.Name;
                customer.Address_1 = c.Address_1;
                customer.Address_2 = c.Address_2;
                customer.City = c.City1.Name;
                customer.Country = c.Country;
                customer.Post_Code = c.Post_Code;
                customer.Email = c.Email;
                customer.Mobile = c.Mobile;
                customer.Birth_Date = c.Birth_Date;
                customer.Active = c.Active;
                customer.Create_Date = c.Create_Date;
                customer.Update_Date = c.Update_Date;
            }
            return customer;
        }

        public bool InsertCustomer(Customer customer)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                db.Customers.Add(customer);
                if(db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                db.Entry(customer).State = EntityState.Modified;
                if(db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool DeleteCustomer(int id)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                Customer customer = db.Customers.Find(id) ?? new Customer();
                if(customer != null)
                {
                    db.Customers.Remove(customer);
                    if(db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }

        public bool IsEmailExist(string email)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                Customer customer = db.Customers.Where(x => x.Email == email).FirstOrDefault();
                if(customer != null)
                {
                    status = true;
                }
            }
            return status;
        }
    }
}
