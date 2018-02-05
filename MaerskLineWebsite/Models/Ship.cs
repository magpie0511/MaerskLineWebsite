using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLineWebsite.Models
{
    public class Ship
    {
        [Key]
        public int ShipId { get; set; }
        [Required]
        [StringLength(255)]

        [Display(Name = "Ship Name")]
        public string Name { get; set; }

        [Display(Name = "No. of Container")]
        public int ContainerNo { get; set; }
    }
}