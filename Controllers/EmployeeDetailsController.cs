using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication7.Models;

namespace MvcApplication7.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        //
        // GET: /EmployeeDetails/

        public ActionResult Index()
        {
            Employee_Form_DBEntities eDB = new Employee_Form_DBEntities();
            var data = eDB.Employee_Form_TB.ToList();
            return View(data);
        }    
    }
}
