using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpAssignment.Common;

namespace CsharpAssignment.BusinessEntities.ViewModels
{
    public class CustomerViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = Constants.NameErrorMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = Constants.AddressErrorMessage)]
        [Display(Name="Address1")]
        public string Address_1 { get; set; }

        [Required(ErrorMessage = Constants.AddressErrorMessage)]
        [Display(Name ="Address2")]
        public string Address_2 { get; set; }

        //[Required(ErrorMessage = Constants.CityErrorMessage)]
        public string City { get; set; }

        [Required(ErrorMessage = Constants.CountryErroMessage)]
        public string Country { get; set; }

        [Required(ErrorMessage = Constants.PostCodeErrorMessage)]
        [Display(Name ="PostCode")]
        [DataType(DataType.PostalCode)]
        public string Post_Code { get; set; }

        [Required(ErrorMessage = Constants.EmailErrorMessage)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage =Constants.EmailValidationErrorMessage)]

        public string Email { get; set; }

        [Required(ErrorMessage = Constants.MobileErrorMessage)]
        [RegularExpression("^([+][9][1]|[9][1]|[0]){0,1}([7-9]{1})([0-9]{9})$",ErrorMessage = Constants.MobileValidationErrorMessage)]
        public string Mobile { get; set; }

        //[Required(ErrorMessage = Constants.BirthDateErrorMessage)]
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> Birth_Date { get; set; }
        
        public bool Active { get; set; }

        [Editable(false)]
        [Display(Name ="Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime Create_Date { get; set; }

        [Editable(false)]
        [Display(Name = "Updated Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> Update_Date { get; set; }
    }
}
