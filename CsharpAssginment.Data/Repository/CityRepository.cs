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
    public class CityRepository : ICityRepository
    {
        public List<CityViewModel> GetAllCities()
        {
            List<CityViewModel> cityViewModels = new List<CityViewModel>();
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                List<City> cities = db.Cities.ToList() ?? new List<City>();
                foreach (City c in cities)
                {
                    CityViewModel city = new CityViewModel();
                    city.id = c.id;
                    city.Name = c.Name;
                    city.Created_Date = c.Created_Date;
                    city.Updated_Date = c.Updated_Date;
                    cityViewModels.Add(city);
                }
            }
            return cityViewModels;
        }

        public CityViewModel GetCity(int id)
        {
            CityViewModel city = new CityViewModel();
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                City c = db.Cities.Find(id);
                city.id = c.id;
                city.Name = c.Name;
                city.Created_Date = c.Created_Date;
                city.Updated_Date = c.Updated_Date;
            }
            return city;
        }

        public bool InsertCity(City city)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                db.Cities.Add(city);
                if (db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool UpdateCity(City city)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                db.Entry(city).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool DeleteCity(int id)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                City city = db.Cities.Find(id) ?? new City();
                if (city != null)
                {
                    db.Cities.Remove(city);
                    if (db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }
    }
}
