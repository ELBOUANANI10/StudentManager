using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LName { get; set; }
        [Required]
        [Display(Name = "CIN")]
        public string cin { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
