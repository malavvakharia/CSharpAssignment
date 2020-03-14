using System.Web.Mvc;

namespace CsharpAssignment.Areas.City
{
    public class CityAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "City";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "City_default",
                "City/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}