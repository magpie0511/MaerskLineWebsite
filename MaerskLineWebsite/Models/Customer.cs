using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineWebsite.Models
{
    public class Customer
    {
        [Key]
        public int CId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
    }
}