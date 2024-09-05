using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "CompanyName is required")]
        public required string CompanyName { get; set; }
        public string? CompanyDiscription { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser? Users { get; set; }
    }
}