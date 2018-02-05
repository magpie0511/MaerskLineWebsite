using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLineWebsite.Models;


namespace MaerskLineWebsite.Controllers
{
    public class SchedulesController : Controller
    {

        private ApplicationDbContext _context;

        public SchedulesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        // GET: Schedule

        public ActionResult New()
        {
            return View();
        }

        [HttpPost] //it will straight create and save into the database. Then, a partial view will shown stating the schedules are created successfully.
        public ActionResult Create(Schedule model)
        {
            _context.Schedules.Add(model);
            _context.SaveChanges();

            return View("New");
        }

        public ActionResult Index()
        {
            var schedules = _context.Schedules.ToList();

            return View(schedules);
        }

        public ActionResult Details(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == id);

            if (schedule == null)
            {
                return HttpNotFound();
            }
            
            return View();
        }

        public ActionResult Edit(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(s=>s.ScheduleId==id);

            if (schedule == null)
            {
                return HttpNotFound();
            }

            Schedule scheduleModelSchedule = new Schedule();
            scheduleModelSchedule.ScheduleId = schedule.ScheduleId;
            scheduleModelSchedule.Destination = schedule.Destination;
            scheduleModelSchedule.Origin = schedule.Origin;
            scheduleModelSchedule.DepartureDateTime = schedule.DepartureDateTime;
            scheduleModelSchedule.ArrivalDateTime = schedule.ArrivalDateTime;

            return View(scheduleModelSchedule);
        }

        [HttpPost]
        public ActionResult Update(Schedule schedule)
        {
            var scheDB = _context.Schedules.SingleOrDefault(s => s.ScheduleId == schedule.ScheduleId);

            scheDB.ScheduleId = schedule.ScheduleId;
            scheDB.Destination = schedule.Destination;
            scheDB.Origin = schedule.Origin;
            scheDB.DepartureDateTime = schedule.DepartureDateTime;
            scheDB.ArrivalDateTime = schedule.ArrivalDateTime;
            
            _context.SaveChanges();

            var scheList = _context.Schedules.ToList();

            return View("Index", scheList);
        }
    }
}