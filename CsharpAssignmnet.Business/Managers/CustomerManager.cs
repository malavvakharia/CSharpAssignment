using AutoMapper;
using CsharpAssginment.Data.Interfaces;
using CsharpAssginment.Data.Models;
using CsharpAssignment.Business.Interfaces;
using CsharpAssignment.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment.Business.Managers
{
    public class CustomerManager : ICustomerManager, ICityManager
    {
        private ICustomerRepository _customerRepository;

        private ICityRepository _cityRepository;

        public CustomerManager(ICustomerRepository customerRepository, ICityRepository cityRepository)
        {
            _customerRepository = customerRepository;
            _cityRepository = cityRepository;
        }

        public List<CustomerViewModel> GetAllCustomers()
        {
            List<CustomerViewModel> customers = _customerRepository.GetAllCustomers();
            return customers;
        }

        public CustomerViewModel GetCustomer(int id)
        {
            CustomerViewModel customer = _customerRepository.GetCustomer(id);
            return customer;
        }

        public bool InsertCustomer(CustomerViewModel customerViewModel)
        {
            bool status = false;
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<CustomerViewModel, CustomerViewModel>();
            //});

            //IMapper mapper = config.CreateMapper();
            //Customer customer = mapper.Map<CustomerViewModel, Customer>(customerViewModel);

            Customer cust = new Customer();
            cust.Name = customerViewModel.Name;
            cust.Address_1 = customerViewModel.Address_1;
            cust.Address_2 = customerViewModel.Address_2;
            cust.City = Convert.ToInt32(customerViewModel.City);
            cust.Country = customerViewModel.Country;
            cust.Post_Code = customerViewModel.Post_Code;
            cust.Email = customerViewModel.Email;
            cust.Mobile = customerViewModel.Mobile;
            cust.Birth_Date = customerViewModel.Birth_Date ?? System.DateTime.Now;
            cust.Active = customerViewModel.Active;
            cust.Create_Date = System.DateTime.Now;
            cust.Update_Date = System.DateTime.Now;

            status = _customerRepository.InsertCustomer(cust);
            return status;
        }

        public bool UpdateCustomer(CustomerViewModel customerViewModel)
        {
            bool status = false;
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<CustomerViewModel, CustomerViewModel>();
            //});

            //IMapper mapper = config.CreateMapper();
            //Customer customer = mapper.Map<CustomerViewModel, Customer>(customerViewModel);
            Customer cust = new Customer();
            cust.id = customerViewModel.id;
            cust.Name = customerViewModel.Name;
            cust.Address_1 = customerViewModel.Address_1;
            cust.Address_2 = customerViewModel.Address_2;
            cust.City = Convert.ToInt32(customerViewModel.City);
            cust.Country = customerViewModel.Country;
            cust.Post_Code = customerViewModel.Post_Code;
            cust.Email = customerViewModel.Email;
            cust.Mobile = customerViewModel.Mobile;
            cust.Birth_Date = customerViewModel.Birth_Date ?? System.DateTime.Now;
            cust.Active = customerViewModel.Active;
            cust.Create_Date = customerViewModel.Create_Date;
            cust.Update_Date = customerViewModel.Update_Date;
            status = _customerRepository.UpdateCustomer(cust);
            return status;
        }

        public bool DeleteCustomer(int id)
        {
            bool status = false;
            status = _customerRepository.DeleteCustomer(id);
            return status;
        }

        public List<CityViewModel> GetAllCities()
        {
            List<CityViewModel> cities = _cityRepository.GetAllCities();
            return cities;
        }

        public CityViewModel GetCity(int id)
        {
            CityViewModel city = _cityRepository.GetCity(id);
            return city;
        }

        public bool InsertCity(CityViewModel city)
        {
            bool status = false;
            City c = new City
            {
                Name = city.Name,
                Created_Date = System.DateTime.Now,
                Updated_Date = System.DateTime.Now
            };
            status = _cityRepository.InsertCity(c);
            return status;
        }

        public bool UpdateCity(CityViewModel city)
        {
            bool status = false;
            City c = new City
            {
                id = city.id,
                Name = city.Name,
                Created_Date = city.Created_Date,
                Updated_Date = city.Updated_Date
            };
            status = _cityRepository.UpdateCity(c);
            return status;
        }

        public bool DeleteCity(int id)
        {
            bool status = false;
            status = _cityRepository.DeleteCity(id);
            return status;
        }

        public bool IsEmailExist(string email)
        {
            bool status = _customerRepository.IsEmailExist(email);
            return status;
        }
    }
}
