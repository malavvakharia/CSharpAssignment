using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment.BusinessEntities.ViewModels
{
    public class CityViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime? Updated_Date { get; set; }
    }
}
