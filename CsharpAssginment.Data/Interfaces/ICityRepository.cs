using CsharpAssginment.Data.Models;
using CsharpAssignment.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssginment.Data.Interfaces
{
    public interface ICityRepository
    {
        List<CityViewModel> GetAllCities();
        CityViewModel GetCity(int id);
        bool InsertCity(City city);
        bool UpdateCity(City city);
        bool DeleteCity(int id);
    }
}
