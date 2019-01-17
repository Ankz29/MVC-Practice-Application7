using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication7.Controllers
{
    public class Detailed_InfoController : Controller
    {
        //
        // GET: /Detailed_Info/

        public ActionResult Index(int id)
        {
            Employee_Form_DBEntities eDB1 = new Employee_Form_DBEntities();
            var data = eDB1.Employee_Form_TB.Where(t => t.Employee_Id == id).FirstOrDefault();
            return View(data);
        }

    }
}
