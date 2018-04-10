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
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        [StringLength(255)]
        public string Destination { get; set; }

        [Required]
        public string Origin{ get; set; }

        [Required]
        [Display(Name = "Departure Date & Time")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [Display(Name = "Arrival Date & Time")]
        public DateTime ArrivalDateTime { get; set; }
        
    }
}