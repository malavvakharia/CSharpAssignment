using CsharpAssignment.Business.Interfaces;
using CsharpAssignment.BusinessEntities.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsharpAssignment.Areas.City.Controllers
{
    [RouteArea("City", AreaPrefix = "MyCity")]
    [RoutePrefix("AllCity")]
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class CitiesController : Controller
    {
        private ICityManager _cityManager;

        public CitiesController(ICityManager cityManager)
        {
            _cityManager = cityManager;
        }

        [Route("MyIndex")]
        [OutputCache(Duration = 30)]
        [HttpGet]
        // GET: Cities
        public ActionResult Index(int? page)
        {
            List<CityViewModel> cities = _cityManager.GetAllCities();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(cities.ToPagedList(pageNumber, pageSize));
        }
        
        [HttpGet]
        public ActionResult GetCity(int id)
        {
            CityViewModel city = _cityManager.GetCity(id);
            return Json(city, JsonRequestBehavior.AllowGet);
        }
        [Route("CreateCity")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Route("CreateCity")]
        [HttpPost]
        public ActionResult Create(CityViewModel city)
        {
            bool status = _cityManager.InsertCity(city);
            if (status == false)
            {
                return View(city);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CityViewModel city = _cityManager.GetCity(id);
            Session["CreateDate"] = city.Created_Date;
            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(CityViewModel city)
        {
            city.Created_Date = Convert.ToDateTime(Session["CreateDate"]);
            city.Updated_Date = System.DateTime.Now;
            bool status = _cityManager.UpdateCity(city);
            Session["CreateDate"] = null;
            if (status == false)
            {
                return View(city);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            bool status = _cityManager.DeleteCity(id);
            if (status == false)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}