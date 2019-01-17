using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication7.Models
{
    public class Employee_Form
    {
       
        [Required(ErrorMessage="Name Required *")]
        public string Employee_FirstName { get; set; }
        [Required(ErrorMessage="Last Required* ")]
        public string Employee_LastName { get; set; }
        [Required(ErrorMessage = "Id Required *")]
       
        public string Employee_Id { get; set; }
        public string Gender { get; set; }
        public int Employee_Salary { get; set; }



        [Required(ErrorMessage = "Email Id Required* ")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Enter a valid email address")]
        public string Employee_Email { get; set; }
       
    }
}