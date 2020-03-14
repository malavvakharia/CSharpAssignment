using CsharpAssignment.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment.Business.Interfaces
{
    public interface ICustomerManager
    {
        List<CustomerViewModel> GetAllCustomers();
        CustomerViewModel GetCustomer(int id);
        bool InsertCustomer(CustomerViewModel customer);
        bool UpdateCustomer(CustomerViewModel customer);
        bool DeleteCustomer(int id);
        bool IsEmailExist(string email);
    }
}
