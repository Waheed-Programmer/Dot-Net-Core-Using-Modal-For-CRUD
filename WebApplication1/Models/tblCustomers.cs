using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class tblCustomers
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(25)]
        public string CustomerName { get; set; }
        [BindProperty , Required]
        public string Genders { get; set; }        
        public string[] ListGender = new[] { "Male", "Female" };
    
        public string Details{get; set;}       

        public DateTime Dated { get; set; } = DateTime.Now;


        [ForeignKey("tblCities")]
        public int? CityId { get; set; }
        public virtual tblCity tblCities { get; set; }

       
    }
}
