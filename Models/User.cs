using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public class User
    {
        
        
        [Key]
        public long UserId { get; set; }
        [Required(ErrorMessage = "Username cannot be empty.")]
        [StringLength(20, ErrorMessage = "Username length must be between 3 and 20.", MinimumLength = 3)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be empty.")]
        [StringLength(20, ErrorMessage = "Password length must be between 6 and 20.", MinimumLength = 6)]
        public string UserPassword { get; set; }
    }
}
