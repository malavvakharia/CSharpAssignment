using CsharpAssginment.Data.Models;
using CsharpAssignment.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssginment.Data.Interfaces
{
    public interface ICustomerRepository
    {
        List<CustomerViewModel> GetAllCustomers();
        CustomerViewModel GetCustomer(int id);
        bool InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
        bool IsEmailExist(string email);
    }
}
