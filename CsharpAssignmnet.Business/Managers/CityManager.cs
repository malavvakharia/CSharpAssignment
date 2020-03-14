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
    public class CityManager : ICityManager
    {
        private ICityRepository _cityRepository;

        public CityManager(ICityRepository cityManager)
        {
            _cityRepository = cityManager;
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
    }
}
