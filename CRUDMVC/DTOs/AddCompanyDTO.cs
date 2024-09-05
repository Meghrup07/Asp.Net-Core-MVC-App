using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC.DTOs
{
    public class AddCompanyDTO
    {
        [Required(ErrorMessage = "CompanyName is required")]
        public required string CompanyName { get; set; }
        public string? CompanyDiscription { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}