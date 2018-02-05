using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineWebsite.Models
{
    public class Container
    {
        [Key]
        public int ContainerId { get; set; }

        [Display(Name = "Weight (lbs)")]
        public double ContainerWeight { get; set; }

        [Display(Name = "Type")]
        public string ContainerType { get; set; }

        public int BookId { get; set; }
        public Booking Booking { get; set; }
    }
}