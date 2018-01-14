using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace MaerskLineWebsite.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Destination { get; set; }

        public string Origin{ get; set; }

        [Display(Name = "Departure Date & Time")]
        public DateTime DepartureDateTime { get; set; }

        [Display(Name = "Arrival Date & Time")]
        public DateTime ArrivalDateTime { get; set; }
        
    }
}