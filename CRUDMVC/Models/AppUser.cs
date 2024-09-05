using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public List<Company> Companies { get; set; } = [];
    }
}