using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineWebsite.Models
{
    public class Booking
    {
        [Key]
        public int BookId { get; set; }
        
        [Required]
        [Display (Name = "Booking agent")]
        public string AgentBooked { get; set; }

        public int Cid { get; set; }
        public Customer Customer { get; set; }
       
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int ShipId { get; set; }
        public Ship Ship { get; set; }

    }
}