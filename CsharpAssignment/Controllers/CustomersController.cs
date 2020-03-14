using CsharpAssignment.BusinessEntities.ViewModels;
using CsharpAssignment.Business.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsharpAssignment.Controllers
{
    [RoutePrefix("MyCustomers")]
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class CustomersController : Controller
    {
        private ICustomerManager _customerManager;
        private ICityManager _cityManager;

        public CustomersController(ICustomerManager customerManager, ICityManager cityManager)
        {
            _customerManager = customerManager;
            _cityManager = cityManager;
        }
        [Route("MyIndex")]
        [HttpGet]
        // GET: Customers
        public ActionResult Index(int? page)
        {
            List<CustomerViewModel> customerViews = _customerManager.GetAllCustomers();
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(customerViews.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult GetCustomer(int id)
        {
            CustomerViewModel customer = _customerManager.GetCustomer(id);
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> cities = _cityManager.GetAllCities().Select(x => new SelectListItem() { Text = x.Name, Value = x.id.ToString()}).ToList();
            ViewBag.cities = cities;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            List<SelectListItem> cities = _cityManager.GetAllCities().Select(x => new SelectListItem() { Text = x.Name, Value = x.id.ToString() }).ToList();
            bool check = _customerManager.IsEmailExist(customer.Email);
            if(check == true)
            {
                ViewBag.cities = cities;
                ViewBag.Email = "Email already exists!!!!";
                return View(customer);
            }
            bool status = _customerManager.InsertCustomer(customer);
            if(status == false)
            {
                ViewBag.cities = cities;
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> cities = _cityManager.GetAllCities().Select(x => new SelectListItem() { Text = x.Name, Value = x.id.ToString() }).ToList();
            ViewBag.cities = cities;
            CustomerViewModel customer = _customerManager.GetCustomer(id);
            Session["City"] = cities.Where(x => x.Text == customer.City).Select(x => x.Value).FirstOrDefault();
            Session["CreateDate"] = customer.Create_Date;
            Session["Birthdate"] = customer.Birth_Date;
            ViewBag.cities = cities;
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            List<SelectListItem> cities = _cityManager.GetAllCities().Select(x => new SelectListItem() { Text = x.Name, Value = x.id.ToString() }).ToList();
            ViewBag.cities = cities;
            if (customer.City == null)
            {
                customer.City = Session["City"].ToString();
            }
            customer.Create_Date = Convert.ToDateTime(Session["CreateDate"]);
            customer.Update_Date = System.DateTime.Now;
            customer.Birth_Date = customer.Birth_Date ?? Convert.ToDateTime(Session["Birthdate"]);
            bool status = _customerManager.UpdateCustomer(customer);
            Session["Birthdate"] = null;
            Session["City"] = null;
            Session["CreateDate"] = null;
            if(status == false)
            {
                ViewBag.cities = cities;
                return View(customer);
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
            bool status = _customerManager.DeleteCustomer(id);
            if(status == false)
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