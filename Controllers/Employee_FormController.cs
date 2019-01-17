using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication7.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace MvcApplication7.Controllers
{
    public class Employee_FormController : Controller
    {
        // GET: /Employee_Form/
        public ActionResult Index()
        {
            TempData["SuccessMessage"] = "";

            return View();
        }

        [HttpPost]                                             //for submit//
        public ActionResult Index(Employee_Form emp, HttpPostedFileBase file)
        {

            TryUpdateModel(emp);
            if (ModelState.IsValid) 
            {
                string Employee_Name = emp.Employee_FirstName;
                string Employee_LastName = emp.Employee_LastName;
                int Employee_Id = Convert.ToInt32(emp.Employee_Id);
                string Gender = emp.Gender;
                int Employee_Salary = Convert.ToInt32(emp.Employee_Salary);
                string Employee_Email = emp.Employee_Email;


                Employee_Form_DBEntities eDB = new Employee_Form_DBEntities();         //to check whether the user exists or not//
                var data = eDB.Employee_Form_TB.Where(t => t.Employee_Email == Employee_Email);
                if (data.Count() > 0)
                {
                    TempData["successmessage"] = "user already exists";
                    return View();
                }
                else
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("/Ankz_img"), _FileName);
                    file.SaveAs(_path);
                    string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))                                   //establishing Connection// 
                    {
                        string query = "INSERT INTO Employee_Form_TB(Employee_FirstName, Employee_LastName,Employee_Gender,Employee_Salary,Employee_Email,Image_Path) VALUES('" + Employee_Name + "', '" + Employee_LastName + "','" + Gender + "'," + Employee_Salary + ",'" + Employee_Email + "','" + _path + "')";
                        //string q1 = "select count(*) from Employee_Form_TB where Employee_Email=='" + Employee_Email + "'";
                        //using (SqlCommand cmd = new SqlCommand(q1))
                        //{
                        //    cmd.Connection = con;
                        //    con.Open();
                        //    cmd.ExecuteScalar();
                        //    con.Close();
                        //}

                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        TempData["SuccessMessage"] = "Data Save Successfully";
                    }
                    Response.Redirect("~/EmployeeDetails/Index");
                    return View();
                    
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
    }
}
        
    

