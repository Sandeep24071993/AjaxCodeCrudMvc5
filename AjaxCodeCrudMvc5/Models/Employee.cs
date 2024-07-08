using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AjaxCodeCrudMvc5.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Your salary")]
        public string State { get; set; }
        [Required]
        public decimal? Salary { get; set; }
    }
}