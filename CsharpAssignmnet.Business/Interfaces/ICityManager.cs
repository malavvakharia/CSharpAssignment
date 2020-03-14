using CsharpAssignment.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment.Business.Interfaces
{
    public interface ICityManager
    {
        List<CityViewModel> GetAllCities();
        CityViewModel GetCity(int id);
        bool InsertCity(CityViewModel city);
        bool UpdateCity(CityViewModel city);
        bool DeleteCity(int id);
    }
}
