using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaerskLineWebsite.Models;

namespace MaerskLineWebsite.ViewModel
{
    public class ViewModelClass
    {
        public Ship Ship { get; set; }

        public List<Ship> ShipsList { get; set; }

        public Schedule Schedule { get; set; }

        public List<Schedule> SchedulesList { get; set; }

        public Customer Customer { get; set; }

        public List<Customer> CustomersList { get; set; }

        public Container Container { get; set; }

        public List<Container> ContainersList { get; set; }

        public Booking Booking { get; set; }

        public List<Booking> BookingsList { get; set; }
       

    }
}