using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLineWebsite.Models;
using MaerskLineWebsite.ViewModel;

namespace MaerskLineWebsite.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext _context;

        public BookingsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }


        //Select schedule 
        public ActionResult SelectSchedule()
        {
            var schedule = _context.Schedules.ToList();
            return View(schedule);
        }

        //Select Ship
        public ActionResult SelectShip(int scheduleid)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == scheduleid);
            var shipList = _context.Ships.ToList();

            var viewModelClass = new ViewModelClass
            {
                Schedule = schedule,
                ShipsList = shipList
            };

            return View(viewModelClass);
        }

        //Select Customer
        public ActionResult SelectCustomer(int scheduleid, int shipid)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == scheduleid);
            var ship = _context.Ships.SingleOrDefault(s => s.ShipId == shipid);
            var customerList = _context.Customers.ToList();

            var viewModel = new ViewModelClass()
            {
                Schedule = schedule,
                Ship = ship,
                CustomersList = customerList

            };

            return View(viewModel);
        }


        //Select Container 
        public ActionResult SelectContainer(int shipid, int scheduleid, int customerid)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == scheduleid);
            var ship = _context.Ships.SingleOrDefault(s => s.ShipId == shipid);
            var customer = _context.Customers.SingleOrDefault(c => c.CId == customerid);
            //var containerList = _context.Containers.ToList();

            var viewModel = new ViewModelClass()
            {
                Schedule = schedule,
                Ship = ship,
                Customer = customer,
                //ContainersList = containerList

            };

            return View(viewModel);
        }

        public ActionResult CreateBooking(ViewModelClass viewmodelclass)
        {
            var booking = new Booking()
            {
                ScheduleId = viewmodelclass.Schedule.ScheduleId,
                ShipId = viewmodelclass.Ship.ShipId,
                Cid = viewmodelclass.Customer.CId,
                AgentBooked = "Seng Yong"
            };

            //_context.Bookings.Add(booking);
            //_context.SaveChanges();

            var container = new Container()
            {
                ContainerId = viewmodelclass.Container.ContainerId,
                ContainerType = viewmodelclass.Container.ContainerType,
                ContainerWeight = viewmodelclass.Container.ContainerWeight,

                BookId = viewmodelclass.Booking.BookId
            };

            _context.Bookings.Add(booking);
            _context.Containers.Add(container);
            _context.SaveChanges();

            //var orderList = _context.Containers.Include(o => o.)

            var orderList = _context.Containers
                .Include(o => o.Booking.Schedule)
                .Include(o => o.Booking.Customer)
                .Include(o => o.Booking.Ship)
                .Include(o => o.Booking)
                .ToList();

            //return View(orderList);
            return View("ViewBooking", orderList);
        }

        public ActionResult ViewBooking()
        {
            var container = _context.Containers
                .Include(c => c.Booking)
                .Include(c => c.Booking.Schedule)
                .Include(c => c.Booking.Customer)
                .Include(c => c.Booking.Ship).ToList();
          
            return View(container);
        }
    }
}